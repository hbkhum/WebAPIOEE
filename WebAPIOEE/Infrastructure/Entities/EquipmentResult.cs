using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIOEE.Infrastructure.Entities
{


	public class EquipmentResult
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EquipmentResultId { get; set; }
        [ForeignKey("MatrixId")]
        public Guid MatrixId { get; set; }
        public string Comments { get; set; }
        public  DateTime EndTime { get; set; }
        public  bool Result { get; set; }
        public DateTime StarTime { get; set; }
        public  decimal TotalTime { get; set; }

        public virtual Matrix Matrix { get; set; }
    }
}

