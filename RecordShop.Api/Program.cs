
using RecordShop.Business.Services;
using RecordShop.DataAccess.Models.Music;
using RecordShop.DataAccess.Repositories;
using RecordShop.DataAccess.Repositories.IRepository;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Dto.Music;
using Microsoft.EntityFrameworkCore;
using RecordShop.DataAccess;
using RecordShop.Business.Mapper;

namespace RecordShop.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddAutoMapper
                (
                //typeof(GenericMapperProfile<MediaType, RecordPriceDto>).Assembly,
                typeof(MapperProfile).Assembly
                );


            builder.Services.AddScoped<IGenericRepository<Album>, AlbumRepository>();
            builder.Services.AddScoped<IGenericService<Album, AlbumDto>, AlbumService>();
            builder.Services.AddScoped<IGenericRepository<Artist>, ArtistRepository>();
            builder.Services.AddScoped<IGenericService<Artist, ArtistDto>, ArtistService>();

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
