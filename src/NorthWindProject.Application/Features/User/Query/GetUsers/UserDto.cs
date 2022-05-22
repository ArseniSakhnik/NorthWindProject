using System.Collections.Generic;
using NorthWind.Core.Enums;

namespace NorthWindProject.Application.Features.User.Query.GetUsers
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public IList<RolesEnum> Roles { get; set; }
        public string RoleNames { get; set; }
    }
}