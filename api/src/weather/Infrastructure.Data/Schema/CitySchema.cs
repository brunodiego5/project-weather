using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Schema
{
    [BsonIgnoreExtraElements]
    public class CitySchema
    {
        [BsonId]
        public ObjectId _Id { get; set; }

        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("coord")]
        public Coord Coord { get; set; }

    }

    [BsonIgnoreExtraElements]
    public class Coord
    {
        [BsonElement("lon")]
        public Double Lon { get; set; }

        [BsonElement("lat")]
        public Double Lat { get; set; }


    }
}
