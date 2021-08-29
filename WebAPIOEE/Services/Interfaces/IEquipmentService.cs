using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIOEE.Infrastructure.Entities;

namespace WebAPIOEE.Services.Interfaces
{
    public interface IEquipmentService
    {
        Task<bool> CreateEquipment(Equipment entity);
        Task<bool> DeleteEquipment(Guid id);
        Task<IEnumerable<Equipment>> GetAllEquipments(string whereValue, string orderBy);
        Task<bool> UpdateEquipment(Equipment entity);
        Task<Equipment> GetEquipmentById(Guid id);
    }
}
