using ProniaOnionAlpha.Application.Abstractions.Repositories;
using ProniaOnionAlpha.Domain.Entities;
using ProniaOnionAlpha.Persistence.Contexts;
using ProniaOnionAlpha.Persistence.Implementations.Repositories.Generic;

namespace ProniaOnionAlpha.Persistence.Implementations.Repositories
{
    internal class PositionRepository : Repository<Position>,IPositionRepository
    {
        public PositionRepository(AppDbContext context):base(context) 
        {

        }
    }
}
