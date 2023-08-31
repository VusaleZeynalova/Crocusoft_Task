using Abp.Domain.Uow;
using AutoMapper;
using BLL.Abstract;
using DTOs.AlbumDtos;
using Entity.Entities;
using DAL.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.AlbumServices;

namespace BLL.Concrete
{
    public class AlbumService : IAlbumService
    {
        private readonly DAL.UnitOfWorks.IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AlbumService(DAL.UnitOfWorks.IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(AlbumToAddDto albumToAddDto, string coverImagePath)
        {
            Album album = _mapper.Map<Album>(albumToAddDto);
            album.CoverImagePath = coverImagePath;
            await _unitOfWork.AlbumRepository.AddAsync(album);
            await _unitOfWork.Commit();
        }

        public async Task Delete(int albumId)
        {
            Album album = await _unitOfWork.AlbumRepository.GetAsync(a => a.AlbumId==albumId);
            _unitOfWork.AlbumRepository.Delete(album);
            await _unitOfWork.Commit();

        }

        public async Task<List<AlbumToListDto>> GetAllAsync(int userId)
        {
            List<AlbumToListDto> albumToListDtos = _mapper.Map<List<AlbumToListDto>>(await _unitOfWork.AlbumRepository.GetAllAsync(u=>u.UserId==userId));
            return albumToListDtos;
        }
    }
}
