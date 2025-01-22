using RecordShop.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Models.Music
{
    public class Artist:IEntity
    {
        public int Id { get; set; }
        [MinLength(5)]
        public string Name { get; set; }
        //navigation properties
        public List<ArtistAlbumJunction> AlbumJunction { get; set; }
    }
}
