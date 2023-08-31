using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using DAL.UnitOfWorks;
using DTOs.AboutDtos;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AboutService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(AboutToAddDto aboutToAddDto)
        {
            About about = _mapper.Map<About>(aboutToAddDto);
            await _unitOfWork.AboutRepository.AddAsync(about);
            await _unitOfWork.Commit();
        }

        public async Task<AboutToListDto> GetAsync(int userId)
        {
            AboutToListDto aboutToListDto = _mapper.Map<AboutToListDto>(await _unitOfWork.AboutRepository.GetAsync(u => u.UserId == userId));
            return aboutToListDto;
        }

        public async Task<AboutToUpdateDto> GetByAboutId(int aboutId)
        {
            AboutToUpdateDto aboutToUpdateDto = _mapper.Map<AboutToUpdateDto>(await _unitOfWork.AboutRepository.GetInclude(a => a.AboutId == aboutId));
            return aboutToUpdateDto;
        }

        public async Task Update(AboutToUpdateDto aboutToUpdateDto)
        {
            About about = _mapper.Map<About>(aboutToUpdateDto);
            _unitOfWork.AboutRepository.Update(about);
            await _unitOfWork.Commit();
        }
    }
}
