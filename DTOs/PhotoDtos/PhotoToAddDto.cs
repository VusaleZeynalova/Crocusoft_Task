using DTOs.AlbumDtos;
using DTOs.BaseDto;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.PhotoDtos
{
    public class PhotoToAddDto:IDto
    {
        public IFormFile PhotoPath { get; set; }
        public AlbumToListDto Album { get; set; }
        [ForeignKey("Album")]
        public int AlbumId { get; set; }
    }
}
