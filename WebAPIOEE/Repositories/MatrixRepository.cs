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
    public class MatrixRepository : GenericRepositoryEntities<Matrix>, IMatrixRepository
    {
        private readonly OEEContext _context;
        public MatrixRepository(OEEContext entities) : base(entities)
        {
            _context = entities;
        }

        public async Task<Matrix> GetById(Guid id)
        {
            return await Dbset
                .Include(x => x.Equipment).ThenInclude(x => x.EquipmentType)
                .Include(x => x.Equipment).ThenInclude(x => x.Line)
                .FirstOrDefaultAsync(c => c.MatrixId == id);
        }

        public new virtual async Task<IEnumerable<Matrix>> GetAllAsync(string whereValue, string orderBy)
        {
            if (whereValue == "") whereValue = "true";
            if (orderBy == "") orderBy = "true";
            var result = await Dbset
                .Include(x => x.Equipment).ThenInclude(x => x.EquipmentType)
                .Include(x => x.Equipment).ThenInclude(x => x.Line)
                .Where(whereValue).OrderBy(orderBy)
                .ToListAsync();
            return result;
        }
    }
}
