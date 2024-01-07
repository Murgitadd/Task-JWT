using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnionAlpha.Application.Abstractions.Repositories;
using ProniaOnionAlpha.Application.Abstractions.Services;
using ProniaOnionAlpha.Application.DTOs.Department;
using ProniaOnionAlpha.Application.DTOs.Position;
using ProniaOnionAlpha.Application.DTOs.Positions;
using ProniaOnionAlpha.Application.DTOs.Tag;
using ProniaOnionAlpha.Domain.Entities;

namespace ProniaOnionAlpha.Persistence.Implementations.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _repository;
        private readonly IMapper _mapper;

        public PositionService(IPositionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(PositionCreateDto positionCreateDto)
        {
            await _repository.AddAsync(_mapper.Map<Position>(positionCreateDto));

            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<PositionItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Position> positions = await _repository.GetAllAsync(skip: (page - 1) * take, take: take, IsTracking: false, IsDeleted:true).ToListAsync();

            ICollection<PositionItemDto> positionItemDtos = _mapper.Map<ICollection<PositionItemDto>>(positions);

            return positionItemDtos;
        }
        public async Task UpdateAsync(int id, PositionUpdateDto positionUpdateDto)
        {
            Position position = await _repository.GetByIdAsync(id);

            if (position is null) throw new Exception("Not found");

            position.Name = positionUpdateDto.Name;

            _repository.Update(position);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Position position = await _repository.GetByIdAsync(id);

            if (position is null) throw new Exception("Not found");

            _repository.Delete(position);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            Position position = await _repository.GetByIdAsync(id);
            if (position is null) throw new Exception("Not found");
            _repository.SoftDelete(position);
            await _repository.SaveChangesAsync();
        }

        public async Task<PositionGetDto> GetAsync(int id)
        {
            Position position = await _repository.GetByIdAsync(id);
            if (position is null) throw new Exception("Not found");

            var dto= _mapper.Map<PositionGetDto>(position);

            return dto;
        }
    }
}
