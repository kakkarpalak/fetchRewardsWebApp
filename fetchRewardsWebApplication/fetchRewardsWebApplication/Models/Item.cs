using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fetchRewardsWebApplication.Models
{
    public class Item
    {
        public int id { get; set; }

        public int listId { get; set; }

        public string name { get; set; }

        public int nameId { get; set; }
    }
}