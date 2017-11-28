using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Models.Scheme.DataAnnotations;
using Microsoft.Rest.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json;

namespace GameStore.Models
{
    public class Game
    {
        [ReadOnly(true)]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        [ReadOnly(true)]
        [Required]
        public string Locale { get; set; }

        [Required]
        public string Title { get; set; }

        public string Edition { get; set; }

        [Required]
        public string Genre { get; set; }

        [Display(Name = "Image URL")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Display(Name = "Wiki URL")]
        [DataType(DataType.Url)]
        public string WikiUrl { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Display(Name = "Release date")]
        [Required, DataType(DataType.Date)]
        [JsonConverter(typeof(DateJsonConverter))]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [SelectOptions(typeof(PlatformOptions))]
        public IEnumerable<Platform> Platforms { get; set; }

        [Display(Name = "Age rating")]
        [Required, Range(0, 18)]
        public int AgeRating { get; set; }

        [Required, DataType(DataType.Currency), Range(0, 10000)]
        public decimal Price { get; set; }

        [Range(0, 5)]
        public double Rating { get; set; }

        public bool Multiplayer { get; set; }

        [Required]
        [SelectOptions(typeof(GameLanguageSelectOptions))]
        public IEnumerable<string> Languages { get; set; }
    }

    public class GameLanguageSelectOptions : ISelectOptionProvider
    {
        public IEnumerable<SelectOption> GetOptions()
        {
            return new[]
            {
                new SelectOption("Chinese", "zh"),
                new SelectOption("English", "en"),
                new SelectOption("French", "fr"),
                new SelectOption("German", "de"),
                new SelectOption("Italian", "it"),
                new SelectOption("Japanese", "ja"),
                new SelectOption("Spanish", "es")
            };
        }
    }
}
