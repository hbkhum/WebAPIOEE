using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebAPIOEE.Infrastructure.Context
{
    public class ApplicationUser : IdentityUser
    {

        //[ForeignKey("EmployeeId")]
        //public virtual Employee Employee { get; set; }
        //[Required]
        //public Guid EmployeeId { get; set; }

        //public virtual IEnumerable<ApplicationUserRole> Role { get; set; }
    }


}
