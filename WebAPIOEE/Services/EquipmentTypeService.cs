using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIOEE.Infrastructure.Entities;
using WebAPIOEE.Repositories;
using WebAPIOEE.Services.Interfaces;

namespace WebAPIOEE.Services
{
    public class EquipmentTypeService : IEquipmentTypeService
    {

        private readonly IDataRepositories _dataRepositories;

        public EquipmentTypeService(IDataRepositories dataRepositories)
        {
            _dataRepositories = dataRepositories;
        }

        public async Task<bool> CreateEquipmentType(EquipmentType entity)
        {

            try
            {
                var result = false;
                //
                _dataRepositories.EquipmentTypeRepository.Add(entity);
                _dataRepositories.EquipmentTypeRepository.Save();
                if (entity.EquipmentTypeId != Guid.NewGuid()) result = true;
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<bool> DeleteEquipmentType(Guid id)
        {
            var entity = await _dataRepositories.EquipmentTypeRepository.GetById(id);
            try
            {
                _dataRepositories.EquipmentTypeRepository.Delete(entity);
                _dataRepositories.EquipmentTypeRepository.Save();
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


        public async Task<IEnumerable<EquipmentType>> GetAllEquipmentTypes(string whereValue, string orderBy)
        {
            var result = await _dataRepositories.EquipmentTypeRepository.GetAllAsync(whereValue, orderBy);
            return result;
            //return result.Select(c => new EquipmentType
            //{
            //    EquipmentTypeId = c.EquipmentTypeId,
            //    EquipmentTypeName = c.EquipmentTypeName,
            //});
        }

        public async Task<bool> UpdateEquipmentType(EquipmentType entity)
        {
            try
            {
                _dataRepositories.EquipmentTypeRepository.Edit(entity);
                _dataRepositories.EquipmentTypeRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return await Task.FromResult(true);
        }

        public async Task<EquipmentType> GetEquipmentTypeById(Guid id)
        {
            return await _dataRepositories.EquipmentTypeRepository.GetById(id);
        }
    }
}