using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIOEE.Infrastructure.Context;
using WebAPIOEE.Infrastructure.Core;
using WebAPIOEE.Infrastructure.Entities;
using WebAPIOEE.Infrastructure.Interfaces;

namespace WebAPIOEE.Repositories
{
    public class EquipmentTypeRepository : GenericRepositoryEntities<EquipmentType>, IEquipmentTypeRepository
    {
        private readonly OEEContext _context;
        public EquipmentTypeRepository(OEEContext entities) : base(entities)
        {
            _context = entities;
        }

        public async Task<EquipmentType> GetById(Guid id)
        {
            return await Dbset.FirstOrDefaultAsync(c => c.EquipmentTypeId == id);
        }
    }
}