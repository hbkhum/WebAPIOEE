using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPIOEE.Infrastructure.Entities;

namespace WebAPIOEE.Infrastructure.Context
{
    public class OEEContext : IdentityDbContext<
        ApplicationUser, ApplicationRole, string>

    {
        public OEEContext(DbContextOptions<OEEContext> options) : base(options)

        {
            //this.
        }

        public static string ConnectionString { get; set; }

        //public DbSet<RefreshToken> RefreshTokens { get; set; }



        //public DbSet<Client> Clients { get; set; }
        //public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Employee> employees { get; set; }
        //public DbSet<TimeSheet> TimeSheets { get; set; }
        //public DbSet<ActivityReport> ActivityReports { get; set; }
        //public DbSet<Vehicle> Vehicles { get; set; }

        //public DbSet<VehicleReport> VehicleReports { get; set; }

        //public DbSet<County> Counties { get; set; }
        //public DbSet<Invoice> Invoices { get; set; }

        //public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        //public DbSet<Position> Positions { get; set; }
        //public DbSet<Location> Locations { get; set; }
        //public DbSet<TimeOff> TimeOffs { get; set; }
        //public DbSet<TimeOffDetail> TimeOffDetails { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<PaymentDetail> PaymentDetail { get; set; }
        //public DbSet<Document> Documents { get; set; }
        //public DbSet<DocumentFile> DocumentFiles { get; set; }
        //public DbSet<DocumentCategory> DocumentCategories { get; set; }
        //public DbSet<Notification> Notifications { get; set; }
        //public DbSet<NotificationType> NotificationTypes { get; set; }
        //public DbSet<RecipientNotification> RecipientNotifications { get; set; }
        //TimeSheetEmployee

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentResult> EquipmentResult { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Matrix> Matrixs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //new DbContextOptionsBuilder<NavaContext>().UseSqlServer("YourConnectionString").Options
            //When creating an instance of the DbContext, you use this check to ensure that if you're not passing any Db Options to always use SQL. 
            //if (!optionsBuilder.IsConfigured)
            //{
            //    var connectingstring = ConfigurationManager.ConnectionStrings["NAVAContexts"].ConnectionString;
            //    optionsBuilder.UseSqlServer(connectingstring);
            //}
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Shorten key length for Identity 


            //modelBuilder.Entity<ActivityReport>()
            //    .HasKey(c => new { c.TimeSheetId,c.EmployeeId });


            //modelBuilder.Entity<TimeSheet>()
            //    .HasMany(c => c.VehicleReport);

            //modelBuilder.Entity<VehicleReport>()
            //.HasMany(c => c.Vehicle).WithOne(v => v)

            //modelBuilder.Entity<TimeSheet>()
            //    .HasMany(vr => vr.VehicleReport)
            //    .WithOne();
            //.HasForeignKey(s => new {s.Vehicle});

            //modelBuilder.Entity<TimeSheet>()
            //    .HasMany(vr => vr.ActivityReport)
            //    .WithOne();
            //modelBuilder.Entity<Employee>()
            //    .HasKey(c => new { c.EmployeeId });

            //modelBuilder.Entity<Vehicle>()
            //    .HasKey(c => new { c.VehicleId })
            //    .HasAnnotation()

            //modelBuilder.Entity<VehicleReport>()
            //    .HasKey(c => new { c.VehicleReportId });



            //modelBuilder.Entity<Employee>()
            //    .HasOne(v => v.Vehicle)
            //    .WithOne(e => e.Employee)
            //    .HasForeignKey<Vehicle>(v => v.EmployeeId);
                

            //modelBuilder.Entity<TimeSheet>()

            //    .HasMany( s => s.VehicleReport)
            //    .WithOne()
            //    .HasForeignKey(s => new { s.VehicleId, });

            //modelBuilder.Entity<Client>()
            //    .HasOne<Contact>()
            //    .WithMany()
            //    .HasForeignKey(p => p.ClientId);

            //modelBuilder.Entity<Employee>()
            //    .HasOne<Vehicle>()
            //    .WithMany()
            //    .HasForeignKey(p => p.EmployeeId);
            //.HasOne(c => new { c.TimeSheetId });

            //modelBuilder.Entity<County>().HasOne(a => a.CountyId).WithOne(b => b)
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(127);
                entity.Property(m => m.Email).HasMaxLength(127);
                entity.Property(m => m.NormalizedEmail).HasMaxLength(127);
                entity.Property(m => m.NormalizedUserName).HasMaxLength(127);
                entity.Property(m => m.UserName).HasMaxLength(127);
            });

            modelBuilder.Entity<ApplicationUserRole>(entity =>
            {
                entity.Property(m => m.RoleId).HasMaxLength(127);
                entity.Property(m => m.UserId).HasMaxLength(127);
            });

            //modelBuilder.Entity<ApplicationUserRole>(userRole =>
            //{
            //    userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

            //    userRole.HasOne(ur => ur.RoleId)
            //        .WithMany(r => r.)
            //        .HasForeignKey(ur => ur.RoleId)
            //        .IsRequired();

            //    userRole.HasOne(ur => ur.UserId)
            //        .WithMany(r => r.UserRoles)
            //        .HasForeignKey(ur => ur.UserId)
            //        .IsRequired();
            //});
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.Property(m => m.RoleId).HasMaxLength(127);
                entity.Property(m => m.Id).HasMaxLength(127);
            });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(127);
                entity.Property(m => m.Id).HasMaxLength(127);
            });

            modelBuilder.Entity<ApplicationRole>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(127);
                entity.Property(m => m.Name).HasMaxLength(127);
                entity.Property(m => m.NormalizedName).HasMaxLength(127);
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.Property(m => m.LoginProvider).HasMaxLength(127);
                entity.Property(m => m.ProviderKey).HasMaxLength(127);
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(127);
                entity.Property(m => m.LoginProvider).HasMaxLength(127);
                entity.Property(m => m.Name).HasMaxLength(127);

            });
        }
    }
}
