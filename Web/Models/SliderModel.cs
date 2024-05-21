using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class SliderModel
    {
        public int Index { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string CssClass { get; set; }
        public bool Active { get; set; }
    }
}
