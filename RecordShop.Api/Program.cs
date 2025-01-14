
using RecordShop.Business.Services;
using RecordShop.DataAccess.Models.Music;
using RecordShop.DataAccess.Repositories;
using RecordShop.DataAccess.Repositories.IRepository;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Dto.Music;
using Microsoft.EntityFrameworkCore;
using RecordShop.DataAccess;
using RecordShop.Business.Mapper;
using Microsoft.AspNetCore.Identity;

namespace RecordShop.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            if (connectionString == "InMemory")
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                           options.UseInMemoryDatabase("Development"));
            }
            else
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                           options.UseSqlServer(builder.Configuration.GetConnectionString(connectionString)));
            }
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);


            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
            builder.Services.AddScoped<IAlbumService, AlbumService>();
            builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
            builder.Services.AddScoped<IArtistService, ArtistService>();
            builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
            builder.Services.AddScoped<IInventoryService, InventoryService>();
            builder.Services.AddScoped<IMusicProductRepository, MusicProductRepository>();
            builder.Services.AddScoped<IMusicProductService, MusicProductService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
