using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasteFoodItx.Entities
{
    public class Slider
    {
        public int SliderId { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public string Subheader { get; set; }
        public string ImageUrl { get; set; }
    }
}