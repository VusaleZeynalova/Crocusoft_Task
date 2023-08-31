using DAL.Abstract;
using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IAlbumRepository AlbumRepository { get; set; }

        public UnitOfWork(DataContext context, IAlbumRepository albumRepository)
        {
            _context = context;
            AlbumRepository = albumRepository;
        }


        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
