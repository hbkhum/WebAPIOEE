using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebAPIOEE.Infrastructure.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OEEContext>
    {
        public OEEContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<OEEContext>();
            //Database Migrations must use a relational provider. Microsoft.EntityFrameworkCore.InMemory is not a Relational provider and therefore cannot be use with Migrations.
            //builder.UseInMemoryDatabase("EmployeeDB");
            //You can point to use SQLExpress on your local machine
            //builder.UseMySql("Server=192.168.1.113; Port=3306; Database=NAVAContext; Uid=root; Pwd=black; SslMode=Preferred;");
            try
            {
                //builder.UseSqlServer("Data Source=humbertopedraza.dynu.com;Initial Catalog=NAVAContext ;User ID=sa;Password=H1lar10;multipleactiveresultsets=True;");
                //
                //builder.UseMySql(
                //    "server=192.168.2.150;user id=root;password=black;database=navacontext;persistsecurityinfo=True;Port=3306;"); 
                builder.UseMySql(
                    "server=192.168.1.50;user id=root;password=black;database=OEEContext;persistsecurityinfo=True;Port=3306;");

                //builder.UseMySql("Server=192.168.1.200; Port=3306; Database=navacontext; Uid=root; Pwd=black; SslMode=Preferred;");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }

            return new OEEContext(builder.Options);
        }
    }
}
