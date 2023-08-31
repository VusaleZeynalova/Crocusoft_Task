using DTOs.BaseDto;
using Entity.MemberShip;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AlbumDtos
{
    public class AlbumToAddDto:IDto
    {
        public string? Title { get; set; }
        public IFormFile CoverImagePath { get; set; }
        [ForeignKey("Photo")]
        public AppUser User { get; set; }
        [ForeignKey("AppUser")]
        public int UserId { get; set; }
    }
}
