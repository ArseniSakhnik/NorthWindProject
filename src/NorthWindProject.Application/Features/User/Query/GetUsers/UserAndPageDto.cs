using System.Collections.Generic;

namespace NorthWindProject.Application.Features.User.Query.GetUsers
{
    public class UserAndPageDto
    {
        public IList<UserDto> Users { get; set; }
        public int PagesCount { get; set; }
    }
}