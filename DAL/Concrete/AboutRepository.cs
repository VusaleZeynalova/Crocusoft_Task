using DAL.Abstract;
using DAL.Context;
using DAL.GenericRepository;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class AboutRepository : Repository<About>, IAboutRepository
    {
        private readonly DataContext _context;
        public AboutRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<About> GetInclude(Expression<Func<About, bool>>? filter)
        {
            About about = await _context.Abouts.Include(u => u.User).FirstOrDefaultAsync(filter);
            return about;
        }
    }
}
