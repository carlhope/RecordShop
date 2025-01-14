using RecordShop.Common.Enums;
using RecordShop.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Models.Music
{
    public class AlbumGenre : IEntity
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public Genre Genre { get; set; }
    }
}
