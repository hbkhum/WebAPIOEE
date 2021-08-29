using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIOEE.Infrastructure.Interfaces;

namespace WebAPIOEE.Repositories
{
    public interface IDataRepositories
    {
        EquipmentRepository EquipmentRepository { get; set; }
        EquipmentResultRepository EquipmentResultRepository { get; set; }
        EquipmentTypeRepository EquipmentTypeRepository { get; set; }
        LineRepository LineRepository { get; set; }
        MatrixRepository MatrixRepository { get; set; }

    }
    public class DataRepositories: IDataRepositories
    {
        public DataRepositories(
            IEquipmentRepository equipmentRepository, 
            IEquipmentResultRepository equipmentResultRepository, 
            IEquipmentTypeRepository equipmentTypeRepository, 
            ILineRepository lineRepository, 
            IMatrixRepository matrixRepository)
        {
            EquipmentRepository = (EquipmentRepository) equipmentRepository;
            EquipmentResultRepository = (EquipmentResultRepository) equipmentResultRepository;
            EquipmentTypeRepository = (EquipmentTypeRepository) equipmentTypeRepository;
            LineRepository = (LineRepository) lineRepository;
            MatrixRepository = (MatrixRepository) matrixRepository;
        }

        public EquipmentRepository EquipmentRepository { get; set; }
        public EquipmentResultRepository EquipmentResultRepository { get; set; }
        public EquipmentTypeRepository EquipmentTypeRepository { get; set; }
        public LineRepository LineRepository { get; set; }
        public MatrixRepository MatrixRepository { get; set; }
    }
}
