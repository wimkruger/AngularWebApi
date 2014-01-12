using AutoMapper;
using DataAccess.Dtos;
using Domain;
using Profile = Domain.Profile;

namespace DataAccess.Task
{
    public static class DtoMapping
    {
         static DtoMapping()
         {
             Mapper.CreateMap<Profile, ProfileDto>();
             Mapper.CreateMap<ProfileDto, Profile>();
             Mapper.CreateMap<MapService, MapServiceDto>();
             Mapper.CreateMap<MapServiceDto, MapService>();
             Mapper.CreateMap<ActiveDirectoryGroup, ActiveDirectoryGroupDto>();
             Mapper.CreateMap<ActiveDirectoryGroupDto, ActiveDirectoryGroup>();
             Mapper.CreateMap<Permission, PermissionDto>();
             Mapper.CreateMap<PermissionDto, Permission>();
             Mapper.CreateMap<Menu, MenuDto>();
         }
    }
}