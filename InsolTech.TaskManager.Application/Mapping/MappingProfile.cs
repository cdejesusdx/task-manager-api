using AutoMapper;

using InsolTech.TaskManager.Domain.Entities;
using InsolTech.TaskManager.Application.DTOs;

namespace InsolTech.TaskManager.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Para listar
            CreateMap<TaskItem, TaskDto>().ReverseMap();

            // Para crear
            CreateMap<TaskCreateDto, TaskItem>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            // Para actualizar
            CreateMap<TaskUpdateDto, TaskItem>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()); // no sobrescribir
        }
    }
}