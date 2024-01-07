using ProniaOnionAlpha.Application.DTOs.Position;
using ProniaOnionAlpha.Application.DTOs.Positions;
using ProniaOnionAlpha.Application.DTOs.Tag;

namespace ProniaOnionAlpha.Application.Abstractions.Services
{
    public interface IPositionService
    {
        Task<ICollection<PositionItemDto>> GetAllAsync(int page, int take);
        Task<PositionGetDto> GetAsync(int id);
        Task CreateAsync(PositionCreateDto positionCreateDto);
        Task UpdateAsync(int id, PositionUpdateDto positionUpdateDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
