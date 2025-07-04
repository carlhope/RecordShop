using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecordShop.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum Genre
    {
        Pop,
        Rock,
        Country,
        RandB,
        Rap,
        Soul,
        HipHop,
        Reggae,
        Folk,
        Punk

    }
}
