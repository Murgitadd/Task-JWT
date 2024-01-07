using ProniaOnionAlpha.Application.DTOs.Author;
using ProniaOnionAlpha.Application.DTOs.Authors;

namespace ProniaOnionAlpha.Application.Abstractions.Services
{
    public interface IAuthorService
    {
        Task<ICollection<AuthorItemDto>> GetAllAsync(int page, int take);
        Task<AuthorGetDto> GetAsync(int id);
        Task CreateAsync(AuthorCreateDto authorCreateDto);
        Task UpdateAsync(int id, AuthorUpdateDto authorUpdateDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
