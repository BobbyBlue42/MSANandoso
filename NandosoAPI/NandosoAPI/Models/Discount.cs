using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NandosoAPI.Models
{
    public class Discount
    {
        public int ID { get; set; }
        public double percentage { get; set; }

        [JsonIgnore]
        public virtual ICollection<Item> item { get; set; }
    }
}