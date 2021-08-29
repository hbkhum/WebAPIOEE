using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIOEE.Infrastructure.Entities;
using WebAPIOEE.Repositories;
using WebAPIOEE.Services.Interfaces;

namespace WebAPIOEE.Services
{
    public class EquipmentResultService : IEquipmentResultService
    {

        private readonly IDataRepositories _dataRepositories;

        public EquipmentResultService(IDataRepositories dataRepositories)
        {
            _dataRepositories = dataRepositories;
        }

        public async Task<bool> CreateEquipmentResult(EquipmentResult entity)
        {

            try
            {
                var result = false;
                //
                _dataRepositories.EquipmentResultRepository.Add(entity);
                _dataRepositories.EquipmentResultRepository.Save();
                if (entity.EquipmentResultId != Guid.NewGuid()) result = true;
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<bool> DeleteEquipmentResult(Guid id)
        {
            var entity = await _dataRepositories.EquipmentResultRepository.GetById(id);
            try
            {
                _dataRepositories.EquipmentResultRepository.Delete(entity);
                _dataRepositories.EquipmentResultRepository.Save();
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


        public async Task<IEnumerable<EquipmentResult>> GetAllEquipmentResults(string whereValue, string orderBy)
        {
            var result = await _dataRepositories.EquipmentResultRepository.GetAllAsync(whereValue, orderBy);
            return result;
            //return result.Select(c => new EquipmentResult
            //{
            //    EquipmentResultId = c.EquipmentResultId,
            //    EquipmentResultName = c.EquipmentResultName,
            //});
        }

        public async Task<bool> UpdateEquipmentResult(EquipmentResult entity)
        {
            try
            {
                _dataRepositories.EquipmentResultRepository.Edit(entity);
                _dataRepositories.EquipmentResultRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return await Task.FromResult(true);
        }

        public async Task<EquipmentResult> GetEquipmentResultById(Guid id)
        {
            return await _dataRepositories.EquipmentResultRepository.GetById(id);
        }
    }
}