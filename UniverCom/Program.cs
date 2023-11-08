using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using UniverCom.Domain;
using UniverCom.Domain.Entities;
using UniverCom.Service;

namespace UniverCom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.Bind("Project", new Config());

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();

            builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(setup => { })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Config.ConnectionString));

            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateAudience = false,
                        ValidateIssuer = false,
                    };
                });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }

    public class AuthOptions
    {
        public const string ISSUER = "CSEON";
        public const string AUDIENCE = "VolgaItClients";
        const string KEY = "UltimasecretKeyFor123_111!@#----12sadOHijidbsajKJBNDkjbsadkjabsdkjBJHDBjsbdkajdbkJBDjsbdkj^*7687264";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.UTF8.GetBytes(KEY));
    }

}