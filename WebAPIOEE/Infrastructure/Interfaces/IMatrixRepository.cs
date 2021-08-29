using System;
using System.Threading.Tasks;
using WebAPIOEE.Infrastructure.Core;
using WebAPIOEE.Infrastructure.Entities;

namespace WebAPIOEE.Infrastructure.Interfaces
{
    public interface IMatrixRepository : IGenericRepositoryEntities<Matrix>
    {
        Task<Matrix> GetById(Guid id);
    }
}