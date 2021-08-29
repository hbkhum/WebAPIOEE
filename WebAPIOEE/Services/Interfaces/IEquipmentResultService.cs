using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIOEE.Infrastructure.Entities;

namespace WebAPIOEE.Services.Interfaces
{
    public interface IEquipmentResultService
    {
        Task<bool> CreateEquipmentResult(EquipmentResult entity);
        Task<bool> DeleteEquipmentResult(Guid id);
        Task<IEnumerable<EquipmentResult>> GetAllEquipmentResults(string whereValue, string orderBy);
        Task<bool> UpdateEquipmentResult(EquipmentResult entity);
        Task<EquipmentResult> GetEquipmentResultById(Guid id);
    }
}