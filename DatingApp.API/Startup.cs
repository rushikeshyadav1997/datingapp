﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using DatingApp.API.Helpers;
using DatingApp.API.Helper;

namespace DatingApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Datacontext> (x=>x.UseSqlite("Filename=MyDatabase.db"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddJsonOptions(opt =>{
                opt.SerializerSettings.ReferenceLoopHandling=
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
           services.AddCors();
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
           services.AddAutoMapper(typeof(DatingRepository).Assembly);
           services.AddScoped<IAuthRepository,AuthRepository>();
           services.AddScoped<IDatingRepository,DatingRepository>();
           services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>{
               options.TokenValidationParameters=new TokenValidationParameters
               {
                   ValidateIssuerSigningKey=true,
                   IssuerSigningKey=new SymmetricSecurityKey(Encoding.ASCII
                   .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                   ValidateIssuer=false,
                   ValidateAudience=false

               };
           });
           services.AddScoped<LogUserActivity>();
     
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
               // app.UseHsts();
            }

            //app.UseHttpsRedirection();
           

           app.UseCors(x=>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); 
           app.UseAuthentication();
            app.UseMvc();
        }
    }
}
