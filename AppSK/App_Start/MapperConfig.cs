﻿using AppSK.DAL.Entities;
using AppSK.Models.Identity;
using AppSK.Models.Managers;
using AppSK.Models.Projects;
using AutoMapper;

namespace AppSK.App_Start
{
    public static class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Project, ProjectModel>();
                config.CreateMap<ProjectModel, Project>();

                config.CreateMap<Manager, ManagerItemModel>();

                config.CreateMap<RegisterModel, User>()
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            });
        }
    }
}