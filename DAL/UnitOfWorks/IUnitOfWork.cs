using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public IAlbumRepository AlbumRepository { get; set; }
        public IPhotoRepository PhotoRepository { get; set; }
        public IAboutRepository AboutRepository { get; set; }
        Task Commit();
    }
}
