using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Extensions;

namespace NorthWindProject.Application.Features.RequestCall.Query
{
    public class GetRequestCallsQuery : IRequest<RequestCallAndPageDto>
    {
        public int Page { get; set; }
        public string SearchName { get; set; }
    }
    
    public class GetRequestCallsQueryHandler : IRequestHandler<GetRequestCallsQuery, RequestCallAndPageDto>
    {
        private readonly AppDbContext _context;

        public GetRequestCallsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RequestCallAndPageDto> Handle(GetRequestCallsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.RequestCalls.AsNoTracking();

            if (request.SearchName != null && request.SearchName.Trim().Length > 0)
            {
                query = query
                    .Where(call => call.Name.ToLower().Trim().Contains(request.SearchName.ToLower().Trim()));
            }

            var calls = await query
                .Skip((request.Page - 1) * 10)
                .Take(10)
                .OrderBy(requestCall => requestCall.Created)
                .Select(requestCall => new RequestCallDto
                {
                    Id = requestCall.Id,
                    Name = requestCall.Name,
                    PhoneNumber = requestCall.PhoneNumber,
                    Comment = requestCall.Comment,
                    Created = requestCall.Created.ToIsoString()
                })
                .ToListAsync(cancellationToken);

            var pagesCount = await query.CountAsync(cancellationToken);

            return new RequestCallAndPageDto
            {
                RequestCalls = calls,
                PagesCount = (int) Math.Ceiling((decimal) pagesCount / 10)
            };
        }
    }
}