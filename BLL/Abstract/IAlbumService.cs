using DTOs.AlbumDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AlbumServices
{
    public interface IAlbumService
    {
        Task AddAsync(AlbumToAddDto albumToAddDto,string coverImagePath);
        Task<List<AlbumToListDto>> GetAllAsync(int userId);
        Task Delete(int albumId);
    }
}
