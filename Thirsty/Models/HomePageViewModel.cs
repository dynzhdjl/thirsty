using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thirsty.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<Style> Styles { get; set; }
        public IEnumerable<Glassware> Glasswares { get; set; }
        public IEnumerable<Availability> Availabilities { get; set; }
    }

    public class Style
    {
    }
    public class Glassware
    {
    }

    public class Availability
    {
    }
}