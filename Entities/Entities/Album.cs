using Entity.BaseEntity;
using Entity.MemberShip;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Album:IEntity
    {
        [Key]
        public int AlbumId { get; set; }
        public string? Title { get; set; }
        public  string CoverImagePath { get; set; }
        public  AppUser User { get; set; }
        [ForeignKey("AppUser")]
        public int UserId { get; set; }
    }
}
