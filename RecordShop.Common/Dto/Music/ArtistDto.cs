﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.Common.Dto.Music
{
    public class ArtistDto
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        //navigation properties
        public List<ArtistAlbumJunctionDto> MusicRecords { get; set; } = [];
    }
}
