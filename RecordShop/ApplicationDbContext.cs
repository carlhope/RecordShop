using Microsoft.EntityFrameworkCore;
using RecordShop.DataAccess.Models.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        internal DbSet<MusicProduct> MusicProducts { get; set; }
        internal DbSet<Album> Albums { get; set; }
        internal DbSet<Artist> Artists { get; set; }
        internal DbSet<ArtistAlbumJunction> ArtistAlbumJunctions { get; set; }
    }
}
