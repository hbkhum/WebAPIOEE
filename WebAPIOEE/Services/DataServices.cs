using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIOEE.Services.Interfaces;

namespace WebAPIOEE.Services
{
    public interface IDataServices
    {
        EquipmentService EquipmentService { get; set; }
        EquipmentResultService EquipmentResultService { get; set; }
        EquipmentTypeService EquipmentTypeService { get; set; }
        LineService LineService { get; set; }
        MatrixService MatrixService { get; set; }
    }
    public class DataServices: IDataServices
    {
        public DataServices(
            IEquipmentService equipmentService, 
            IEquipmentResultService equipmentResultService, 
            IEquipmentTypeService equipmentTypeService, 
            ILineService lineService, 
            IMatrixService matrixService)
        {
            EquipmentService = (EquipmentService) equipmentService;
            EquipmentResultService = (EquipmentResultService) equipmentResultService;
            EquipmentTypeService = (EquipmentTypeService) equipmentTypeService;
            LineService = (LineService) lineService;
            MatrixService = (MatrixService) matrixService;
        }

        public EquipmentService EquipmentService { get; set; }
        public EquipmentResultService EquipmentResultService { get; set; }
        public EquipmentTypeService EquipmentTypeService { get; set; }
        public LineService LineService { get; set; }
        public MatrixService MatrixService { get; set; }
    }
}
