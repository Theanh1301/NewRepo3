using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shopee.Data;
using Shopee.Models;
using Shopee.Responsitories;
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
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authoriztion header using the Bearer scheme"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                    }
                });
            });

            builder.Services.AddCors(options => options.AddPolicy(name: "myReactApp", policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();

            }));

            builder.Services.AddDbContext<ShopeeDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                    (builder.Configuration["JWT:SecretKey"]))
                };
            });
            /*builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Authorization", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    //policy.RequireClaim("Role", "api1"); // Only users with "api1" scope can access
                });
            });*/
            builder.Services.AddScoped<IAccountResponsitory, AccountRespository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("myReactApp");

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.MapControllers();

            app.Run();
        }
    }
}