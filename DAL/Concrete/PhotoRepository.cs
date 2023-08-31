using DAL.Abstract;
using DAL.Context;
using DAL.GenericRepository;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(DataContext context) : base(context)
        {
        }
    }
}
