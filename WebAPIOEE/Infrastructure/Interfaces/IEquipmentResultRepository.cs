using System;
using System.Threading.Tasks;
using WebAPIOEE.Infrastructure.Core;
using WebAPIOEE.Infrastructure.Entities;

namespace WebAPIOEE.Infrastructure.Interfaces
{
    public interface IEquipmentResultRepository : IGenericRepositoryEntities<EquipmentResult>
    {
        Task<EquipmentResult> GetById(Guid id);
    }
}