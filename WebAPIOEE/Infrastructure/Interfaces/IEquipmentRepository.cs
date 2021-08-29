
using System;
using System.Threading.Tasks;
using WebAPIOEE.Infrastructure.Core;
using WebAPIOEE.Infrastructure.Entities;

namespace WebAPIOEE.Infrastructure.Interfaces
{
    public interface IEquipmentRepository : IGenericRepositoryEntities<Equipment>
    {
        Task<Equipment> GetById(Guid id);
    }
}
