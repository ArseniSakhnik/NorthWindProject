using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace NorthWindProject.Application.Features.Account.Command.Register
{
    public class RegisterResultDto
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; }
    }
}