using AutoMapper;
using ProniaOnionAlpha.Application.DTOs.Tag;
using ProniaOnionAlpha.Application.DTOs.Tags;
using ProniaOnionAlpha.Domain.Entities;

namespace ProniaOnionAlpha.Application.MappingProfiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagItemDto>();
            CreateMap<Tag, TagGetDto>();
            CreateMap<TagCreateDto, Tag>();
        }
    }
}
