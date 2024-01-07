using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnionAlpha.Application.Abstractions.Repositories;
using ProniaOnionAlpha.Application.Abstractions.Services;
using ProniaOnionAlpha.Application.DTOs.Author;
using ProniaOnionAlpha.Application.DTOs.Authors;
using ProniaOnionAlpha.Application.DTOs.Department;
using ProniaOnionAlpha.Application.DTOs.Departments;
using ProniaOnionAlpha.Application.DTOs.Position;
using ProniaOnionAlpha.Domain.Entities;

namespace ProniaOnionAlpha.Persistence.Implementations.Services
{
    public class DepartmentService:IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(DepartmentCreateDto departmentCreateDto)
        {
            
            await _repository.AddAsync(_mapper.Map<Department>(departmentCreateDto));
            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<DepartmentItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Department> departments = await _repository.GetAllAsync(skip: (page - 1) * take, take: take, IsTracking: false, IsDeleted: true).ToListAsync();

            ICollection<DepartmentItemDto> departmentItemDtos = _mapper.Map<ICollection<DepartmentItemDto>>(departments);

            return departmentItemDtos;
        }
        public async Task UpdateAsync(int id, DepartmentUpdateDto departmentUpdateDto)
        {
            Department department = await _repository.GetByIdAsync(id);

            if (department is null) throw new Exception("Not found");

            department.Name = departmentUpdateDto.Name;

            _repository.Update(department);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Department department = await _repository.GetByIdAsync(id);

            if (department is null) throw new Exception("Not found");

            _repository.Delete(department);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            Department department = await _repository.GetByIdAsync(id);
            if (department is null) throw new Exception("Not found");
            _repository.SoftDelete(department);
            await _repository.SaveChangesAsync();
        }
        public async Task<DepartmentGetDto> GetAsync(int id)
        {
            Department department = await _repository.GetByIdAsync(id);
            if (department is null) throw new Exception("Not found");
            var dto = _mapper.Map<DepartmentGetDto>(department);

            return dto;
        }
    }
}
