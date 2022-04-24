using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Cars.Query
{
    public class GetCarsQuery : IRequest<IList<CarDto>>
    {
    }

    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, IList<CarDto>>
    {
        private readonly AppDbContext _context;

        public GetCarsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<CarDto>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
            => await _context.Cars
                .Select(car => new CarDto
                {
                    Id = car.Id,
                    Path = car.Path,
                    Title = car.Title,
                    About = car.About,
                    Description = car.Description,
                    CarModels = car.CarModels
                })
                .ToListAsync(cancellationToken);
    }
}