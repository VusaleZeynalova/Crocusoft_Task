using DTOs.AboutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IAboutService
    {
        Task AddAsync(AboutToAddDto aboutToAddDto);
        Task Update(AboutToUpdateDto aboutToUpdateDto);
        Task<AboutToListDto> GetAsync(int userId);
        Task<AboutToUpdateDto> GetByAboutId(int aboutId);
        
    }
}
