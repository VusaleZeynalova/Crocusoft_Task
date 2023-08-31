using DTOs.BaseDto;
using Entity.MemberShip;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.UserDtos
{
    public class UserToListDto:IDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<AppRole>? Roles { get; set; }=new List<AppRole>();
        [ForeignKey("Role")]
        public int? RoleId { get; set; }
        public List<AppRoleClaim>? RoleClaims { get; set; } = new List<AppRoleClaim>();
        [ForeignKey("AppRoleClaim")]
        public int? RoleClaimId { get; set; }
    }
}
