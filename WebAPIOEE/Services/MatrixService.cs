using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIOEE.Infrastructure.Entities;
using WebAPIOEE.Repositories;
using WebAPIOEE.Services.Interfaces;

namespace WebAPIOEE.Services
{
    public class MatrixService : IMatrixService
    {

        private readonly IDataRepositories _dataRepositories;

        public MatrixService(IDataRepositories dataRepositories)
        {
            _dataRepositories = dataRepositories;
        }

        public async Task<bool> CreateMatrix(Matrix entity)
        {

            try
            {
                var result = false;
                //
                _dataRepositories.MatrixRepository.Add(entity);
                _dataRepositories.MatrixRepository.Save();
                if (entity.MatrixId != Guid.NewGuid()) result = true;
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<bool> DeleteMatrix(Guid id)
        {
            var entity = await _dataRepositories.MatrixRepository.GetById(id);
            try
            {
                _dataRepositories.MatrixRepository.Delete(entity);
                _dataRepositories.MatrixRepository.Save();
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


        public async Task<IEnumerable<Matrix>> GetAllMatrixs(string whereValue, string orderBy)
        {
            var result = await _dataRepositories.MatrixRepository.GetAllAsync(whereValue, orderBy);
            return result;
            //return result.Select(c => new Matrix
            //{
            //    MatrixId = c.MatrixId,
            //    MatrixName = c.MatrixName,
            //});
        }

        public async Task<bool> UpdateMatrix(Matrix entity)
        {
            try
            {
                _dataRepositories.MatrixRepository.Edit(entity);
                _dataRepositories.MatrixRepository.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return await Task.FromResult(true);
        }

        public async Task<Matrix> GetMatrixById(Guid id)
        {
            return await _dataRepositories.MatrixRepository.GetById(id);
        }
    }
}