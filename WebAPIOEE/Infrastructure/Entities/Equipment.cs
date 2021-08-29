using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIOEE.Infrastructure.Entities
{

	public class Equipment
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EquipmentId { get; set; }
        [ForeignKey("EquipmentTypeId")]
        public Guid EquipmentTypeId { get; set; }
        [ForeignKey("LineId")]
        public Guid LineId { get; set; }
        public bool Active { get; set; }
        public Decimal Availability { get; set; }
        public string EquipmentName { get; set; }
        public Decimal TotalUnit { get; set; }
        public Decimal Velocity { get; set; }

        public virtual EquipmentType EquipmentType { get; set; }
        public virtual Line Line { get; set; }


    }
}

