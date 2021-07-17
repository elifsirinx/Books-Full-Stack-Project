using Books.Business;
using Books.Business.Extensions;
using Books.DataAccess.Data;
using Books.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.API
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
            services.AddControllers();
            services.AddMapperConfiguration();

            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IPublisherRepository, EFPublisherRepository>();

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, EFBookRepository>();

            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IGenreRepository, EFGenreRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, FakeUserRepository>();

            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            var connectionString = Configuration.GetConnectionString("db");
            services.AddDbContext<BooksDbContext>(option => option.UseSqlServer(connectionString));

            //Created for swagger UI
            services.AddSwaggerGen(option => option.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Title of the Document",
                Contact = new OpenApiContact
                {
                    Email = "elifsirin42@gmail.com",
                    Name = "Elif "
                    
                },
                Version="v1"
            }));

            //Created for security
            var issuer = Configuration.GetSection("Bearer")["Issuer"];
            var audience = Configuration.GetSection("Bearer")["Audience"];
            var key = Configuration.GetSection("Bearer")["SecurityKey"];

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };
                });

            services.AddCors(opt =>
            {
                opt.AddPolicy("Allow", builder =>
                 {
                     builder.AllowAnyOrigin()
                             .AllowAnyMethod()
                             .AllowAnyHeader();


                 });
            });

            services.AddResponseCaching();

        }
        
// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Books.API"));


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Allow");

            app.UseResponseCaching();

            //Created for security
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
