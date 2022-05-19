using System;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Entities.Common;
using NorthWind.Core.Entities.Contracts.BaseContract;
using NorthWind.Core.Entities.Contracts.KgoYurContract;
using NorthWind.Core.Entities.Contracts.VacuumTruckFizContract;
using NorthWind.Core.Entities.Contracts.VacuumTruckYurContract;
using NorthWind.Core.Enums;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;
using NorthWindProject.Application.Features.Contract.Events;
using NorthWindProject.Application.Features.Contract.Query.BaseDto;
using NorthWindProject.Application.Services.PurchaseService;
using Org.BouncyCastle.Ocsp;

namespace NorthWindProject.Application.Services.ContractService
{
    public interface IContractService
    {
        void FillContract(BaseCreateContractCommand command, Contract contract);
        void FillFizContract(BaseCreateFizContractCommand command, FizContract fizContract);
        void FillYurContract(BaseCreateYurContractCommand command, YurContract yurContract);
        void FillContractDto(Contract contract, dynamic baseContractDto);
        void FillFizContractDto(FizContract fizContract, dynamic baseFizContractDto);
        void FillYurContractDto(YurContract yurContract, dynamic baseYurContractDto);
        Task<dynamic> GetContract(int contractId, CancellationToken cancellationToken);

        Task CreateContractAsync(Contract contract,
            ServicesRequestTypeEnum servicesRequestTypeId,
            CancellationToken cancellationToken);
    }

    public class ContractService : IContractService
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IEncryptionService _encryptionService;

        public ContractService(AppDbContext context,
            ICurrentUserService currentUserService,
            IEncryptionService encryptionService)
        {
            _context = context;
            _currentUserService = currentUserService;
            _encryptionService = encryptionService;
        }

        public void FillContract(BaseCreateContractCommand command, Contract contract)
        {
            var currentDate = DateTime.Now;

            contract.Day = currentDate.Day.ToString();
            contract.Month = currentDate.Month.ToString();
            contract.Year = currentDate.Year.ToString();
            contract.PhoneNumber = command.PhoneNumber;
            contract.PlaceName = command.PlaceName;
            contract.Email = command.Email;
        }

        public void FillFizContract(BaseCreateFizContractCommand command, FizContract fizContract)
        {
            fizContract.IndividualFullName = command.IndividualFullName;
        }

        public void FillYurContract(BaseCreateYurContractCommand command, YurContract yurContract)
        {
            yurContract.INN = command.INN;
            yurContract.KPP = command.KPP;
            yurContract.OGRN = command.OGRN;
            yurContract.OKPO = command.OKPO;
            yurContract.YurAddress = command.YurAddress;
            yurContract.CustomerShortName = command.CustomerShortName;
            yurContract.IEShortName = command.IEShortName;
            yurContract.OperatesOnBasis = command.OperatesOnBasis;
        }

        public void FillContractDto(Contract contract, dynamic baseContractDto)
        {
            baseContractDto.day = contract.Day;
            baseContractDto.month = contract.Month;
            baseContractDto.year = contract.Year;
            baseContractDto.phoneNumber = contract.PhoneNumber;
            baseContractDto.placeName = contract.PlaceName;
            baseContractDto.email = contract.Email;

            baseContractDto.serviceRequestTypeId = contract switch
            {
                VacuumTruckYurContract => ServicesRequestTypeEnum.АссенизаторЮр,
                VacuumTruckFizContract => ServicesRequestTypeEnum.АссенизаторФиз,
                KGOYurContract => ServicesRequestTypeEnum.КГОЮр,
                _ => throw new NotImplementedException()
            };
        }

        public void FillFizContractDto(FizContract fizContract, dynamic baseFizContractDto)
        {
            baseFizContractDto.individualFullName = fizContract.IndividualFullName;
        }

        public void FillYurContractDto(YurContract yurContract, dynamic baseYurContractDto)
        {
            baseYurContractDto.iNN = yurContract.INN;
            baseYurContractDto.kPP = yurContract.KPP;
            baseYurContractDto.oGRN = yurContract.OGRN;
            baseYurContractDto.oKPO = yurContract.OKPO;
            baseYurContractDto.yurAddress = yurContract.YurAddress;
            baseYurContractDto.customerShortName = yurContract.CustomerShortName;
            baseYurContractDto.iEShortName = yurContract.IEShortName;
            baseYurContractDto.operatesOnBasis = yurContract.OperatesOnBasis;
        }

        public async Task<dynamic> GetContract(int contractId, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts
                .Where(contract => contract.Id == contractId)
                .SingleOrDefaultAsync(cancellationToken);

            if (contract is IEncryptObject encryptionContract)
            {
                encryptionContract.DecryptObject(_encryptionService);
            }

            dynamic contractDto = new ExpandoObject();

            FillContractDto(contract, contractDto);

            switch (contract)
            {
                case YurContract yurContract:
                    FillYurContractDto(yurContract, contractDto);
                    break;
                case FizContract fizContract:
                    FillFizContractDto(fizContract, contractDto);
                    break;
            }


            if (contract is KGOYurContract kgoYurContract)
            {
                contractDto.overload = kgoYurContract.Overload;
                contractDto.volume = kgoYurContract.Volume;
            }

            return contractDto;
        }

        public async Task CreateContractAsync(
            Contract contract,
            ServicesRequestTypeEnum servicesRequestTypeId,
            CancellationToken cancellationToken)
        {
            var currentUserId = await _context.Users
                .Where(user => user.Id == _currentUserService.UserId)
                .Select(user => user.Id)
                .SingleOrDefaultAsync(cancellationToken);

            var documentService = await _context.DocumentServices
                .Where(documentService => documentService.Id == servicesRequestTypeId)
                .SingleOrDefaultAsync(cancellationToken);

            contract.UserId = currentUserId;
            contract.ServiceId = documentService.ServiceId;
            contract.DocumentServiceId = documentService.Id;

            if (contract is IEncryptObject contractEncrypt)
                contractEncrypt.EncryptObject(_encryptionService);

            contract.DomainEvents.Add(new SendEmailContractAlertEvent
            {
                Email = contract.Email,
                ServicesRequestTypeId = servicesRequestTypeId,
                Contract = contract
            });
            
            AuditableEntityFill(contract);
            await _context.Contracts.AddAsync(contract, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        private void AuditableEntityFill(AuditableEntity contract)
        {
            contract.CreatedByUsername = _currentUserService.UserName;
            contract.CreatedByUserId = _currentUserService.UserId == 0
                ? null
                : _currentUserService.UserId;
            contract.Created = DateTime.Now;
        }
    }
}