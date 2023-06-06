using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SinFTE.Data;
using SinFTE.Repositorios;
using SinFTE.Repositorios.Interfaces;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace SinFTE
{
   
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddAuthentication(); //verificar se precisa mesmo


            builder.Services.AddCors();
            

            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<SinFTEDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));


            builder.Services.AddScoped<ILogRepositorio, LogRepositorio>();
            builder.Services.AddScoped<IUserRepositorio, UserRepositorio>();
            builder.Services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();

            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SinFTEDBContext>()
                .AddDefaultTokenProviders();

            //JWT
            var appSettingsSection = builder.Configuration.GetSection("AppSettings"); 
            builder.Services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddCookie(x =>
            {
                x.Cookie.Name = "token";

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.ValidoEm,
                    ValidIssuer = appSettings.Emissor
                };
                x.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["token"];
                        return Task.CompletedTask;
                    }
                };
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else if (app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x =>
            {
                x.AllowAnyMethod();
                x.AllowAnyHeader();
                x.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.MapControllers();
            app.Run();
        }
        

    }
}
