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

        [BsonElement("Id")]
        public int Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("State")]
        public string State { get; set; }

        [BsonElement("Country")]
        public string Country { get; set; }

        [BsonElement("Coord")]
        public Coord Coord { get; set; }

    }

    [BsonIgnoreExtraElements]
    public class Coord
    {
        [BsonElement("Lon")]
        public Double Lon { get; set; }

        [BsonElement("Lat")]
        public Double Lat { get; set; }


    }
}
