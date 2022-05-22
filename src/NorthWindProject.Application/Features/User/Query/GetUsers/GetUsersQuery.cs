using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.Internal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.User.Query.GetUsers
{
    public class GetUsersQuery : IRequest<UserAndPageDto>
    {
        public int Page { get; set; }
        public string SearchName { get; set; }
        public RolesEnum RoleTypeId { get; set; } = RolesEnum.Все;
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UserAndPageDto>
    {
        private readonly AppDbContext _context;

        public GetUsersQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserAndPageDto> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Users.AsNoTracking();

            if (request.RoleTypeId != RolesEnum.Все)
            {
                var searchRoles = await _context.UserRoles
                    .Where(ur => ur.RoleId == (int) request.RoleTypeId)
                    .Select(ur => ur.UserId)
                    .ToListAsync(cancellationToken);

                query = query
                    .Where(user => searchRoles.Contains(user.Id));
            }

            if (request.SearchName != null && request.SearchName.Trim().Length > 0)
            {
                query = query
                    .Where(user => user.FullName.ToLower().Trim().Contains(request.SearchName.ToLower().Trim()));
            }

            var usersCount = await query.CountAsync(cancellationToken);

            var users = await query
                .Skip((request.Page - 1) * 10)
                .Take(10)
                .OrderBy(user => user.UserName)
                .Select(user => new UserDto
                {
                    UserId = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    MiddleName = user.MiddleName,
                    FullName = user.FullName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    PhoneNumber = user.PhoneNumber,
                })
                .ToListAsync(cancellationToken);

            foreach (var userDto in users)
            {
                var roles = await _context.UserRoles
                    .Where(ur => ur.UserId == userDto.UserId)
                    .Select(ur => (RolesEnum) ur.RoleId)
                    .ToListAsync(cancellationToken);

                userDto.Roles = roles;
                userDto.RoleNames = roles.Count > 0
                    ? roles
                        .Select(role => role.ToString())
                        .Aggregate((str1, str2) => $"{str1}, {str2}")
                    : "";
            }

            return new UserAndPageDto
            {
                Users = users,
                PagesCount = (int) Math.Ceiling((decimal) usersCount / 10)
            };
        }
    }
}