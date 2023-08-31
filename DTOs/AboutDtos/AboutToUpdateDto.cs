using DTOs.BaseDto;
using Entity.MemberShip;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AboutDtos
{
    public class AboutToUpdateDto:IDto
    {
        public int AboutId { get; set; }
        public string? AboutText { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? Qualification { get; set; }
        public string? Email { get; set; }
        public AppUser User { get; set; }
        [ForeignKey("AppUser")]
        public int UserId { get; set; }
    }
}
