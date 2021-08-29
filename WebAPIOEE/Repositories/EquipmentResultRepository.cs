using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIOEE.Infrastructure.Context;
using WebAPIOEE.Infrastructure.Core;
using WebAPIOEE.Infrastructure.Entities;
using WebAPIOEE.Infrastructure.Interfaces;

namespace WebAPIOEE.Repositories
{
    public class EquipmentResultRepository : GenericRepositoryEntities<EquipmentResult>, IEquipmentResultRepository
    {
        private readonly OEEContext _context;
        public EquipmentResultRepository(OEEContext entities) : base(entities)
        {
            _context = entities;
        }

        public async Task<EquipmentResult> GetById(Guid id)
        {
            return await Dbset.FirstOrDefaultAsync(c => c.EquipmentResultId == id);
        }
    }
}