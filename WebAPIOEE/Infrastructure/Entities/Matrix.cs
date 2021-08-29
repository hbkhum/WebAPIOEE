using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIOEE.Infrastructure.Entities
{


	public class Matrix
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MatrixId { get; set; }
        [ForeignKey("EquipmentId")]
        public  Guid EquipmentId { get; set; }
        public  int Next { get; set; }
        public  int State { get; set; }

        public virtual Equipment Equipment { get; set; }



    }
}

