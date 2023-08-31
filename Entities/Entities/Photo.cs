using Entity.BaseEntity;

namespace Entity.Entities
{
    public class Photo:IEntity
    {
        public int PhotoId { get; set; }
        public  string PhotoPath { get; set; }
    }
}