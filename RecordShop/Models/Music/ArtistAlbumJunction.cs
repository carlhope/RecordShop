using RecordShop.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Models.Music
{
    public class ArtistAlbumJunction:IEntity
    {
        public int Id { get; set; }
        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
        [ForeignKey("Album")]
        public int AlbumId { get; set; }
        //navigation properties
        public Artist Artist { get; set; }
        public Album Album { get; set; }
    }
}
