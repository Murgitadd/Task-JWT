using ProniaOnionAlpha.Application.DTOs.Department;
using ProniaOnionAlpha.Application.DTOs.Departments;

namespace ProniaOnionAlpha.Application.Abstractions.Services
{
    public interface IDepartmentService
    {
        Task<ICollection<DepartmentItemDto>> GetAllAsync(int page, int take);
        Task<DepartmentGetDto> GetAsync(int id);
        Task CreateAsync(DepartmentCreateDto departmentCreateDto);
        Task UpdateAsync(int id, DepartmentUpdateDto departmentUpdateDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
