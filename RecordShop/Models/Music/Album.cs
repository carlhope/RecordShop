using RecordShop.Common.Enums;
using RecordShop.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Models.Music
{
    public class Album:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ArtistAlbumJunction>? Artist { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
