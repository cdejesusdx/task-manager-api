using AutoMapper;

using InsolTech.TaskManager.Domain.Entities;
using InsolTech.TaskManager.Application.DTOs;

namespace InsolTech.TaskManager.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, TaskDto>().ReverseMap();
        }
    }
}