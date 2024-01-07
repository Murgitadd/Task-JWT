using ProniaOnionAlpha.Application.Abstractions.Repositories;
using ProniaOnionAlpha.Domain.Entities;
using ProniaOnionAlpha.Persistence.Contexts;
using ProniaOnionAlpha.Persistence.Implementations.Repositories.Generic;

namespace ProniaOnionAlpha.Persistence.Implementations.Repositories
{
    internal class TagRepository : Repository<Tag>,ITagRepository
    {
        public TagRepository(AppDbContext context):base(context)
        {

        }
    }
}
