using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIOEE.Infrastructure.Entities;

namespace WebAPIOEE.Services.Interfaces
{
    public interface IEquipmentTypeService
    {
        Task<bool> CreateEquipmentType(EquipmentType entity);
        Task<bool> DeleteEquipmentType(Guid id);
        Task<IEnumerable<EquipmentType>> GetAllEquipmentTypes(string whereValue, string orderBy);
        Task<bool> UpdateEquipmentType(EquipmentType entity);
        Task<EquipmentType> GetEquipmentTypeById(Guid id);
    }
}