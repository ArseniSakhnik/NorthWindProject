using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Enums;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;
using NorthWindProject.Application.Features.Contract.Events;

namespace NorthWindProject.Application.Features.Contract.Services.ContractService
{
    public interface IContractService
    {
        public Task CreateContractAsync<TData, TContract>(
            Func<TData, TContract> contractFactory,
            TData contractData,
            ServicesEnum serviceTypeId,
            CancellationToken cancellationToken)
            where TContract : NorthWind.Core.Entities.Contracts.BaseContract.Contract
            where TData : BaseCreateContractCommand;
    }

    public class ContractService : IContractService
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IEncryptionService _encryptionService;
        private readonly IMediator _mediator;

        public ContractService(IMediator mediator,
            AppDbContext context,
            ICurrentUserService currentUserService,
            IEncryptionService encryptionService)
        {
            _mediator = mediator;
            _context = context;
            _currentUserService = currentUserService;
            _encryptionService = encryptionService;
        }

        public async Task CreateContractAsync<TData, TContract>(
            Func<TData, TContract> contractFactory,
            TData contractData,
            ServicesEnum serviceTypeId,
            CancellationToken cancellationToken)
            where TContract : NorthWind.Core.Entities.Contracts.BaseContract.Contract
            where TData : BaseCreateContractCommand

        {
            var currentUser = await _context.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(user => user.Id == _currentUserService.UserId, cancellationToken);

            var service = await _context.Services
                .Include(service => service.DocumentServices)
                .AsNoTracking()
                .SingleOrDefaultAsync(service => service.Id == serviceTypeId, cancellationToken);

            var currentDate = DateTime.Now;

            var contract = contractFactory(contractData);

            contract.Day = currentDate.Day.ToString();
            contract.Month = currentDate.Month.ToString();
            contract.Year = currentDate.Year.ToString();

            contract.UserId = currentUser.Id;
            contract.ServiceId = service.Id;
            contract.DocumentServiceId = service.DocumentServices.First().Id;

            if (contract is IEncryptObject contractEncrypt) contractEncrypt.EncryptObject(_encryptionService);

            contract.DomainEvents.Add(new SendEmailContractAlertEvent
            {
                Email = contractData.Email,
                Contract = contract
            });
            currentUser.Contracts.Add(contract);

            await _context.Contracts.AddAsync(contract, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}