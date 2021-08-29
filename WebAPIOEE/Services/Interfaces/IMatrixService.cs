using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIOEE.Infrastructure.Entities;

namespace WebAPIOEE.Services.Interfaces
{
    public interface IMatrixService
    {
        Task<bool> CreateMatrix(Matrix entity);
        Task<bool> DeleteMatrix(Guid id);
        Task<IEnumerable<Matrix>> GetAllMatrixs(string whereValue, string orderBy);
        Task<bool> UpdateMatrix(Matrix entity);
        Task<Matrix> GetMatrixById(Guid id);
    }
}