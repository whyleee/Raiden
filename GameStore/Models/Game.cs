using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Rest.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json;

namespace GameStore.Models
{
    public class Game
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Edition { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required, DataType(DataType.Date)]
        [JsonConverter(typeof(DateJsonConverter))]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public IEnumerable<Platform> Platforms { get; set; }
        [Required, Range(0, 18)]
        public int AgeRating { get; set; }
        [Required, Range(0, 10000)]
        public decimal Price { get; set; }
        [Range(0, 5)]
        public double Rating { get; set; }
        public bool Multiplayer { get; set; }
    }
}
