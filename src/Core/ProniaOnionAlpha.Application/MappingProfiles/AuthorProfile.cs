using AutoMapper;
using ProniaOnionAlpha.Application.DTOs.Author;
using ProniaOnionAlpha.Application.DTOs.Authors;
using ProniaOnionAlpha.Domain.Entities;

namespace ProniaOnionAlpha.Application.MappingProfiles
{
    public class AuthorProfile:Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorItemDto>();
            CreateMap<Author, AuthorGetDto>();
            CreateMap<AuthorCreateDto, Author>();
        }
    }
}
