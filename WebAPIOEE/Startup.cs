using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebAPIOEE.DependencyInjection;
using WebAPIOEE.Infrastructure.Context;

namespace WebAPIOEE
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();

            //var s = new CamelCasePropertyNamesContractResolver
            //{
            //    NamingStrategy = new CamelCaseNamingStrategy {ProcessExtensionDataNames = true}
            //};
            //services.AddSignalR().AddJsonProtocol(options =>
            //{
            //    options.PayloadSerializerSettings.ContractResolver = s;
            //});

            services.AddSignalR().AddJsonProtocol(options =>
            {
                options.PayloadSerializerSettings.ContractResolver = new DefaultContractResolver();
            });
            //services.AddSignalR();


            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .AllowCredentials()
            //            //.WithOrigins("http://localhost:4200")
            //            .AllowAnyOrigin()
            //            );
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed((host) => true));
            });

            //services.Configure<MvcOptions>(options =>
            //{
            //    options.Filters.Add(new CorsAuthorizationFilterFactory("CorsPolicy"));
            //});

            /* services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddEntityFrameworkStores<NavaContext>()
                 .AddDefaultTokenProviders();*/

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Stores.MaxLengthForKeys = 128;
                //options.SignIn.RequireConfirmedEmail = true;
                //options.SignIn.RequireConfirmedPhoneNumber = false;
                options.Lockout.AllowedForNewUsers = true;
            })
                .AddEntityFrameworkStores<OEEContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<OEEContext>(
                options =>
                {
                    options.UseMySql(Configuration.GetConnectionString("OEEContexts"));
                });
            //services.AddDbContext<OEEContext>(
            //    options =>
            //    {
            //        options.UseMySql("server=192.168.2.200;user id=root;password=black;database=OEEContext;persistsecurityinfo=True;Port=3306;");
            //    });
            //
            //services.AddDbContext<NavaContext>(options => options.UseMySql("Server=192.168.1.200; Port=3306; Database=ncscontext; Uid=root; Pwd=black; SslMode=Preferred;"));

            //services.AddDbContext<NavaContext>(options => options.UseMySql("server=ncs-database.mysql.database.azure.com;user id=ncs;password=Talikajoer1;database=NAVAContext;persistsecurityinfo=True;Port=3306;"));
            //services.AddDbContext<NavaContext>(options => options.UseMySql("Server=ncs-database.mysql.database.azure.com; Port=3306; Database=NAVAContext; Uid=ncs@ncs-database; Pwd=Talikajoer1; SslMode=Preferred;"));

            //"server=192.168.1.214;user id=root;password=black;database=NAVAContext;persistsecurityinfo=True;Port=3306;"
            services.RegisterRepositories();
            services.RegisterServices();
            services.RegisterDataRepositories();
            services.RegisterDataServices();



            services.AddMvc()
                .AddJsonOptions(jsonOptions =>
                {
                    jsonOptions.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    jsonOptions.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    jsonOptions.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });


            //services.AddMvc()
            //JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //    ContractResolver = new DefaultContractResolver(),
            //    NullValueHandling = NullValueHandling.Ignore,
            //    //PreserveReferencesHandling = PreserveReferencesHandling.Objects
            //};

            // Configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication((option =>
            {
                //option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }))
                .AddJwtBearer(options =>
                {

                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        //ValidateIssuer = true,
                        //ValidateAudience = true,
                        //ValidateLifetime = true,
                        //ValidateIssuerSigningKey = true,
                        //ValidIssuer = "yourdomain.com",
                        //ValidAudience = "yourdomain.com",
                        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey")),
                        //ClockSkew = TimeSpan.Zero

                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = appSettings.Site,
                        ValidAudience = appSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ClockSkew = TimeSpan.Zero,


                    };
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSignalR(routes =>
            {
                //routes.MapHub<StationHub>("/hubs/station");
                //routes.MapHub<CategoryHub>("/hubs/category");
                //routes.MapHub<EquipmentHub>("/hubs/equipment");
                //routes.MapHub<EquipmentDetailHub>("/hubs/equipmentdetail");
                //routes.MapHub<EquipmentTestResultHub>("/hubs/equipmenttestresult");
                //routes.MapHub<InputOutputSignalHub>("/hubs/inputoutputsignal");
                //routes.MapHub<ProtocolHub>("/hubs/protocol");
                //routes.MapHub<TelemetryResultHub>("/hubs/telemetryResult");
                //routes.MapHub<UnitTypeHub>("/hubs/unittype");
                //routes.MapHub<TypeHub>("/hubs/type");
            });

            //app.UseSpaStaticFiles();

            app.UseMvc();

        }
    }
}
