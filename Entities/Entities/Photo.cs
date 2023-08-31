using Entity.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities
{
    public class Photo:IEntity
    {
        public int PhotoId { get; set; }
        public  string PhotoPath { get; set; }
        public Album Album { get; set; }
        [ForeignKey("Album")]
        public int AlbumId { get; set; }

    }
}