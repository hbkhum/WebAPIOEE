using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIOEE.Infrastructure.Entities
{


	public class EquipmentType
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  Guid EquipmentTypeId { get; set; }
        public  string EquipmentTypeName { get; set; }


    }
}

