using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnionAlpha.Application.Abstractions.Repositories;
using ProniaOnionAlpha.Application.Abstractions.Services;
using ProniaOnionAlpha.Application.DTOs.Author;
using ProniaOnionAlpha.Application.DTOs.Authors;
using ProniaOnionAlpha.Domain.Entities;

namespace ProniaOnionAlpha.Persistence.Implementations.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(AuthorCreateDto authorCreateDto)
        {

            await _repository.AddAsync(_mapper.Map<Author>(authorCreateDto));

            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<AuthorItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Author> authors = await _repository.GetAllAsync(skip: (page - 1) * take, take: take, IsTracking: false, IsDeleted: true).ToListAsync();

            ICollection<AuthorItemDto> authorItemDtos = _mapper.Map<ICollection<AuthorItemDto>>(authors);

            return authorItemDtos;
        }
        public async Task UpdateAsync(int id, AuthorUpdateDto authorUpdateDto)
        {
            Author author = await _repository.GetByIdAsync(id);

            if (author is null) throw new Exception("Not found");

            author.Name = authorUpdateDto.Name;

            _repository.Update(author);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Author author = await _repository.GetByIdAsync(id);

            if (author is null) throw new Exception("Not found");

            _repository.Delete(author);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            Author author = await _repository.GetByIdAsync(id);
            if (author is null) throw new Exception("Not found");
            _repository.SoftDelete(author);
            await _repository.SaveChangesAsync();
        }

        public async Task<AuthorGetDto> GetAsync(int id)
        {
            Author author = await _repository.GetByIdAsync(id);
            if (author is null) throw new Exception("Not found");
            var dto=_mapper.Map<AuthorGetDto>(author);

            return dto;
        }
    }
}
