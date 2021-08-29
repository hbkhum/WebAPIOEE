using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIOEE.Infrastructure.Entities;
using WebAPIOEE.Repositories;
using WebAPIOEE.Services.Interfaces;

namespace WebAPIOEE.Services
{
    public class EquipmentService : IEquipmentService
    {

        private readonly IDataRepositories _dataRepositories;

        public EquipmentService(IDataRepositories dataRepositories)
        {
            _dataRepositories = dataRepositories;
        }

        public async Task<bool> CreateEquipment(Equipment entity)
        {

            try
            {
                var result = false;
                //
                _dataRepositories.EquipmentRepository.Add(entity);
                _dataRepositories.EquipmentRepository.Save();
                if (entity.EquipmentId != Guid.NewGuid()) result = true;
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<bool> DeleteEquipment(Guid id)
        {
            var entity = await _dataRepositories.EquipmentRepository.GetById(id);
            try
            {
                _dataRepositories.EquipmentRepository.Delete(entity);
                _dataRepositories.EquipmentRepository.Save();
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


        public async Task<IEnumerable<Equipment>> GetAllEquipments(string whereValue, string orderBy)
        {
            var result = await _dataRepositories.EquipmentRepository.GetAllAsync(whereValue, orderBy);
            return result;
        }

        public async Task<bool> UpdateEquipment(Equipment entity)
        {
            try
            {
                _dataRepositories.EquipmentRepository.Edit(entity);
                _dataRepositories.EquipmentRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return await Task.FromResult(true);
        }

        public async Task<Equipment> GetEquipmentById(Guid id)
        {
            return await _dataRepositories.EquipmentRepository.GetById(id);
        }
    }
}
