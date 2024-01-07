using AutoMapper;
using ProniaOnionAlpha.Application.DTOs.Department;
using ProniaOnionAlpha.Application.DTOs.Departments;
using ProniaOnionAlpha.Domain.Entities;

namespace ProniaOnionAlpha.Application.MappingProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentItemDto>();
            CreateMap<Department, DepartmentGetDto>();
            CreateMap<DepartmentCreateDto, Department>();
        }
    }
}
