using System.Collections.Generic;

namespace NorthWindProject.Application.Features.Account.Query.GetCurrentUserInfo
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Email { get; set; } = "";
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; } = "";
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string FullName { get; set; } = "";
        public List<int> Roles { get; set; } = new();
    }
}