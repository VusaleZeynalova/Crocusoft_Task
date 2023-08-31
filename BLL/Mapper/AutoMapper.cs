using AutoMapper;
using BLL.AuthServices.Abstract;
using BLL.AuthServices.Concrete;
using DTOs.AboutDtos;
using DTOs.AlbumDtos;
using DTOs.PhotoDtos;
using DTOs.UserDtos;
using Entity.Entities;
using Entity.MemberShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<AlbumToAddDto, Album>();
            CreateMap<Album, AlbumToListDto>();

            CreateMap<PhotoToAddDto,Photo>();   
            CreateMap<Photo,PhotoToListDto>();
            
            CreateMap<AboutToAddDto,About>();
            CreateMap<AboutToUpdateDto,About>().ReverseMap();
            CreateMap<About,AboutToListDto>();

            CreateMap<UserUpdateDto, AppUser>().ReverseMap();
            CreateMap<AppUser, UserToListDto>();
        }
    }
}
