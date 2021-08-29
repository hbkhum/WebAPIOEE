using System;
using System.Threading.Tasks;
using WebAPIOEE.Infrastructure.Core;
using WebAPIOEE.Infrastructure.Entities;

namespace WebAPIOEE.Infrastructure.Interfaces
{
    public interface IEquipmentTypeRepository : IGenericRepositoryEntities<EquipmentType>
    {
        Task<EquipmentType> GetById(Guid id);
    }
}