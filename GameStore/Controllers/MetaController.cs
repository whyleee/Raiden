using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GameStore.Models;
using GameStore.Models.Scheme;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class MetaController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var gamesApiUrl = "/games";

            var meta = new StorageInfo
            {
                Name = "Games",
                Url = gamesApiUrl,
                ItemType = GetTypeInfo<Game>(),
                Collections = new []
                {
                    new CollectionInfo
                    {
                        Name = "Platform",
                        Kind = CollectionKind.Filter,
                        Url = $"{gamesApiUrl}/platforms",
                        Param = "platform"
                    },
                    new CollectionInfo
                    {
                        Name = "Genre",
                        Kind = CollectionKind.Filter,
                        Url = $"{gamesApiUrl}/genres",
                        Param = "genre"
                    },
                    new CollectionInfo
                    {
                        Name = "Language",
                        Kind = CollectionKind.Filter,
                        Url = $"{gamesApiUrl}/languages",
                        Param = "language"
                    },
                    new CollectionInfo
                    {
                        Name = "Locale",
                        Kind = CollectionKind.Selector,
                        Url = $"{gamesApiUrl}/locales",
                        Param = "locale"
                    }
                }
            };

            return Ok(meta);
        }

        private ItemTypeInfo GetTypeInfo<T>()
        {
            var type = typeof(T);

            return new ItemTypeInfo
            {
                Name = type.Name,
                Fields = type.GetProperties().Select(GetTypeFieldInfo).ToList()
            };
        }

        private ItemFieldInfo GetTypeFieldInfo(PropertyInfo prop)
        {
            var field = new ItemFieldInfo
            {
                Name = char.ToLower(prop.Name.First()) + prop.Name.Substring(1),
                Type = GetTypeName(prop.PropertyType),
                Kind = GetFieldKind(prop),
                Attributes = GetAttributes(prop)
            };

            return field;
        }

        public IDictionary<string, object> GetAttributes(PropertyInfo prop)
        {
            var attrs = prop.GetCustomAttributes();
            var dict = new Dictionary<string, object>();

            foreach (var attr in attrs)
            {
                if (attr is ReadOnlyAttribute)
                {
                    dict.Add("readonly", true);
                }
                if (attr is RequiredAttribute)
                {
                    dict.Add("required", true);
                }
                if (attr is RangeAttribute)
                {
                    var range = (RangeAttribute) attr;
                    dict.Add("range", new { Min = range.Minimum, Max = range.Maximum });
                }
                if (attr is DisplayAttribute)
                {
                    var display = (DisplayAttribute) attr;
                    dict.Add("displayName", display.Name);
                }
            }

            return dict;
        }

        private string GetFieldKind(PropertyInfo prop)
        {
            var dataTypeAttr = prop.GetCustomAttribute<DataTypeAttribute>();
            return dataTypeAttr?.DataType.ToString();
        }

        private string GetTypeName(Type type)
        {
            if (type == typeof(string))
            {
                return "string";
            }
            if (type == typeof(bool))
            {
                return "bool";
            }
            if (type == typeof(int))
            {
                return "integer";
            }
            if (type == typeof(double) || type == typeof(decimal))
            {
                return "number";
            }
            if (type == typeof(DateTime))
            {
                return "datetime";
            }
            if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                return "array";
            }

            return type.Name;
        }
    }
}
