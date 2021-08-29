using System;
using System.Threading.Tasks;
using WebAPIOEE.Infrastructure.Core;
using WebAPIOEE.Infrastructure.Entities;

namespace WebAPIOEE.Infrastructure.Interfaces
{
    public interface ILineRepository : IGenericRepositoryEntities<Line>
    {
        Task<Line> GetById(Guid id);
    }
}