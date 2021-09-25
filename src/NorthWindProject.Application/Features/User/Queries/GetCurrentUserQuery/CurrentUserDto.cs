using System.Collections.Generic;

namespace NorthWindProject.Application.Features.User.Queries.GetCurrentUserQuery
{
    public class CurrentUserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public bool IsAuthenticated { get; set; }

        public IEnumerable<RoleDto> Roles { get; set; }
    }
}