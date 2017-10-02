using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models.Scheme
{
    public class StorageInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public ItemTypeInfo ItemType { get; set; }
        public IEnumerable<CollectionInfo> Collections { get; set; }
    }
}
