using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Entities.Contracts.BaseContract;
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
        void FillContractDto(Contract contract, BaseContractDto baseContractDto);
        void FillFizContractDto(FizContract fizContract, BaseFizContractDto baseFizContractDto);
        void FillYurContractDto(YurContract yurContract, BaseYurContractDto baseYurContractDto);
        Task CreateContractAsync(Contract contract, ServiceViewEnum serviceTypeId, CancellationToken cancellationToken);
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

        public void FillContractDto(Contract contract, BaseContractDto baseContractDto)
        {
            baseContractDto.Day = contract.Day;
            baseContractDto.Month = contract.Month;
            baseContractDto.Year = contract.Year;
            baseContractDto.PhoneNumber = contract.PhoneNumber;
            baseContractDto.PlaceName = contract.PlaceName;
        }

        public void FillFizContractDto(FizContract fizContract, BaseFizContractDto baseFizContractDto)
        {
            baseFizContractDto.IndividualFullName = fizContract.IndividualFullName;
        }

        public void FillYurContractDto(YurContract yurContract, BaseYurContractDto baseYurContractDto)
        {
            baseYurContractDto.INN = yurContract.INN;
            baseYurContractDto.KPP = yurContract.KPP;
            baseYurContractDto.OGRN = yurContract.OGRN;
            baseYurContractDto.OKPO = yurContract.OKPO;
            baseYurContractDto.YurAddress = yurContract.YurAddress;
            baseYurContractDto.CustomerShortName = yurContract.CustomerShortName;
            baseYurContractDto.IEShortName = yurContract.IEShortName;
            baseYurContractDto.OperatesOnBasis = yurContract.OperatesOnBasis;
        }

        public async Task CreateContractAsync(
            Contract contract,
            ServiceViewEnum serviceTypeId,
            CancellationToken cancellationToken)
        {
            var currentUserId = await _context.Users
                .Where(user => user.Id == _currentUserService.UserId)
                .Select(user => user.Id)
                .SingleOrDefaultAsync(cancellationToken);

            var serviceInfo = await _context.Services
                .AsNoTracking()
                .Where(service => service.ServiceViewId == serviceTypeId)
                .Select(service => new
                    {ServiceId = service.Id, DocumentServiceId = service.DocumentServices.First().Id})
                .SingleOrDefaultAsync(cancellationToken);

            contract.UserId = currentUserId;
            contract.ServiceId = serviceInfo.ServiceId;
            contract.DocumentServiceId = serviceInfo.DocumentServiceId;

            if (contract is IEncryptObject contractEncrypt) contractEncrypt.EncryptObject(_encryptionService);

            contract.DomainEvents.Add(new SendEmailContractAlertEvent
            {
                Email = contract.Email,
                Contract = contract
            });

            await _context.Contracts.AddAsync(contract, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}