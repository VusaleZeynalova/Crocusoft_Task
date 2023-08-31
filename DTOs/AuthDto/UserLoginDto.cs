using DTOs.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AuthDto
{
    public class UserLoginDto : IDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
