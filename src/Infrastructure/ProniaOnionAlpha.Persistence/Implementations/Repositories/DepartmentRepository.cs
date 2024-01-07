using ProniaOnionAlpha.Application.Abstractions.Repositories;
using ProniaOnionAlpha.Domain.Entities;
using ProniaOnionAlpha.Persistence.Contexts;
using ProniaOnionAlpha.Persistence.Implementations.Repositories.Generic;

namespace ProniaOnionAlpha.Persistence.Implementations.Repositories
{
    public class DepartmentRepository:Repository<Department>,IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context):base(context)
        {

        }
    }
}
