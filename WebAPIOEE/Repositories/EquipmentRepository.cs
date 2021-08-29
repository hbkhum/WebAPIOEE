using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIOEE.Infrastructure.Context;
using WebAPIOEE.Infrastructure.Core;
using WebAPIOEE.Infrastructure.Entities;
using WebAPIOEE.Infrastructure.Interfaces;

namespace WebAPIOEE.Repositories
{
    public class EquipmentRepository : GenericRepositoryEntities<Equipment>, IEquipmentRepository
    {
        private readonly OEEContext _context;
        public EquipmentRepository(OEEContext entities) : base(entities)
        {
            _context = entities;
        }

        public async Task<Equipment> GetById(Guid id)
        {
            return await Dbset.FirstOrDefaultAsync(c => c.EquipmentId == id);
        }
        public new virtual async Task<IEnumerable<Equipment>> GetAllAsync(string whereValue, string orderBy)
        {
            if (whereValue == "") whereValue = "true";
            if (orderBy == "") orderBy = "true";
            var result = await Dbset
                .Include(x => x.EquipmentType)
                .Include(x => x.Line)
                .Where(whereValue).OrderBy(orderBy)
                .ToListAsync();
            return result;
        }
    }
}