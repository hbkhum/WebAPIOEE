using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIOEE.Infrastructure.Context;
using WebAPIOEE.Infrastructure.Core;
using WebAPIOEE.Infrastructure.Entities;
using WebAPIOEE.Infrastructure.Interfaces;

namespace WebAPIOEE.Repositories
{
    public class LineRepository : GenericRepositoryEntities<Line>, ILineRepository
    {
        private readonly OEEContext _context;
        public LineRepository(OEEContext entities) : base(entities)
        {
            _context = entities;
        }

        public async Task<Line> GetById(Guid id)
        {
            return await Dbset.FirstOrDefaultAsync(c => c.LineId == id);
        }
    }
}