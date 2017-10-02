using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models.Scheme
{
    public class CollectionInfo
    {
        public string Name { get; set; }
        public CollectionKind Kind { get; set; }
        public string Url { get; set; }
        public string Param { get; set; }
    }
}
