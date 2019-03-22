using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CrawlerDemo
{
    [DebuggerDisplay("{Model}, {Price}")]
    internal class Car
    {
        public string Model { get; set; }
        public string Price { get; set; }
        public string Link { get; set; }
        public string ImageUrl { get; set; }
    }
}