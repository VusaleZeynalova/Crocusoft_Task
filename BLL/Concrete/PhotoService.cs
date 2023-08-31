using Abp.Domain.Uow;
using AutoMapper;
using BLL.Abstract;
using DTOs.PhotoDtos;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class PhotoService : IPhotoService
    {
        private readonly DAL.UnitOfWorks.IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PhotoService(DAL.UnitOfWorks.IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(PhotoToAddDto photoToAddDto, string photoPath)
        {
            Photo photo = _mapper.Map<Photo>(photoToAddDto);
            photo.PhotoPath = photoPath;
            await _unitOfWork.PhotoRepository.AddAsync(photo);
            await _unitOfWork.Commit();
        }

        public async Task Delete(int photoId)
        {
            Photo photo = await _unitOfWork.PhotoRepository.GetAsync(p => p.PhotoId == photoId);
            _unitOfWork.PhotoRepository.Delete(photo);
            await _unitOfWork.Commit();

        }

        public async Task<List<PhotoToListDto>> GetAllAsync(int albumId)
        {
            List<PhotoToListDto> photoToListDtos = _mapper.Map<List<PhotoToListDto>>(await _unitOfWork.PhotoRepository.GetAllAsync(a=>a.AlbumId==albumId));
            return photoToListDtos;
        }
    }
}
