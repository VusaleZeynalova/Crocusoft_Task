using DAL.GenericRepository;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IAboutRepository:IRepository<About>
    {
        Task<About> GetInclude(Expression<Func<About, bool>>? filter);

    }
}
