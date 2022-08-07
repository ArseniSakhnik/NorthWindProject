using System.Threading.Tasks;
using Hangfire.States;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Services.BotService;

namespace NorthWindProject.Application.Services.RecurringJobService
{
    public class RecurringJobService
    {
        private readonly AppDbContext _context;
        private readonly BotService.BotService _botService;

        public RecurringJobService(AppDbContext context, BotService.BotService botService)
        {
            _context = context;
            _botService = botService;
        }

        public async Task SendRequestFailedRequestCalls()
        {
            var failedTasks = await _context.FailedRequestCalls
                .ToListAsync();

            foreach (var failedTask in failedTasks)
            {
                var isSucceed = await _botService.SendRequestCall(new SendRequestCallDto
                {
                    name = failedTask.Name,
                    number = failedTask.PhoneNumber,
                    text_data = failedTask.Comment
                });

                if (isSucceed)
                {
                    _context.FailedRequestCalls.Remove(failedTask);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}