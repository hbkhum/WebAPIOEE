using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIOEE.Infrastructure.Entities
{

	public class Line
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  Guid LineId { get; set; }

        public string LineName { get; set; }


	}
}

