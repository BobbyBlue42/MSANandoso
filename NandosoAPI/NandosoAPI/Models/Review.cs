using NandosoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NandosoAPI.Models
{
    public class Review
    {
        public int ID { get; set; }
        public string submitter { get; set; }
        public string review { get; set; }
        public DateTime reviewDate { get; set;}

        public bool repliedTo { get; set; }
        public string reply { get; set; }

        public string appliesTo { get; set; }
        public int reviewValue { get; set; }
    }
}