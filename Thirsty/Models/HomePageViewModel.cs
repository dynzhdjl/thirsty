using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thirsty.Repositories;
namespace Thirsty.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<Style> Styles { get; set; }
        public IEnumerable<Glass> Glasswares { get; set; }
        public IEnumerable<Available> Availabilities { get; set; }
    }
}