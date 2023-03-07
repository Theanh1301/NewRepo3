using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shopee.Data;
using Shopee.Models;
using System.Configuration;
using System.Text;

namespace Shopee
{
    public class Program
    {       
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            #region
            /*  builder.Services.AddDbContext<ShopeeDBContext>(option => {
                  option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
              });*/

            //Add identity
            //builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddDefaultTokenProviders();
            //Token
            /* builder.Services.AddAuthentication(options =>
             {
                 options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  
                 options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme.ToString();
                 options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
             }).AddJwtBearer(options =>
             {
                 options.SaveToken = true;
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidAudience = builder.Configuration["JWT:ValidAudience"],
                     ValidIssuer = builder.Configuration["JWT:Issuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                     .GetBytes(builder.Configuration["JWT:SecretKey"]))
                 };
             });*/
            #endregion

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();            

            builder.Services.AddCors(options => options.AddPolicy(name: "myReactApp", policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();

            }));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("myReactApp");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.MapControllers();

            app.Run();
        }
    }
}