using System.Collections.Generic;

namespace Signicat
{
    public class CollectionWithPaging<T>
    {
        public int? Offset { get; set; }

        public int? Limit { get; set; }

        public long? Size { get; set; }

        public Links Links { get; set; }

        public List<T> Data { get; set; }
    }
}