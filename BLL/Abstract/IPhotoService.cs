using DTOs.PhotoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IPhotoService
    {
        Task AddAsync(PhotoToAddDto photoToAddDto,string photoPath);
        Task<List<PhotoToListDto> > GetAllAsync(int albumId);
        Task Delete(int photoId);
    }
}
