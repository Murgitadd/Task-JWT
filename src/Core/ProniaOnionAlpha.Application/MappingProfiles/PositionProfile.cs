using AutoMapper;
using ProniaOnionAlpha.Application.DTOs.Author;
using ProniaOnionAlpha.Application.DTOs.Position;
using ProniaOnionAlpha.Application.DTOs.Positions;
using ProniaOnionAlpha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionAlpha.Application.MappingProfiles
{
    public class PositionProfile:Profile
    {
        public PositionProfile()
        {
            CreateMap<Position, PositionItemDto>();
            CreateMap<Position, PositionGetDto>();
            CreateMap<PositionCreateDto, Position>();
        }
    }
}
