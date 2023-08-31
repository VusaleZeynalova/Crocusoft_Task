using DTOs.AlbumDtos;
using DTOs.BaseDto;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.PhotoDtos
{
    public class PhotoToListDto:IDto
    {
        public int PhotoId { get; set; }
        public string PhotoPath { get; set; }
        public AlbumToListDto Album { get; set; }
        [ForeignKey("Album")]
        public int AlbumId { get; set; }
    }
}
