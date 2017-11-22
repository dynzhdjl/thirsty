using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thirsty.Repositories;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Thirsty
{
    public class HomePageViewModel
    {
        public IEnumerable<Style> Styles { get; set; }
        public IEnumerable<Glass> Glasswares { get; set; }
        public IEnumerable<Available> Availabilities { get; set; }
        public PagedResult<Beer> Beers { get; set; }


        public int GetNextPageIndex()
        {
            if (Beers.TotalPageCount == Page.Value)
            {
                return Page.Value;
            }
            return Page.Value + 1;
        }

        public int GetPrevPageIndex()
        {
            if (Page.Value == 1)
            {
                return Page.Value;
            }
            return Page.Value - 1;
        }

        private List<Object> OrderOptions = new List<Object>
        {
            new { Text="Name", Value="name"},
            new { Text="Descirption", Value="description"},
            new { Text="Abv", Value="abv"},
            new { Text="Ibu", Value="ibu"}
        };

        private List<Object> SortOptions = new List<Object>
        {
            new { Text="Asc", Value="asc"},
            new { Text="Desc", Value="desc"},
        };

        public SelectList GetOrderSelecList(string selectedValue)
        {
            return new SelectList(OrderOptions, "Value", "Text", selectedValue);
        }

        public SelectList GetSortSelecList(string selectedValue)
        {
            return new SelectList(SortOptions, "Value", "Text", selectedValue);
        }

        public int? GlasswareId { get; set; }
        public int? StyleId { get; set; }
        public int? AvailabilityId { get; set; }
        [Display(Name = "Order")]
        public string Order { get; set; }

        [Display(Name = "Sort")]
        public string Sort { get; set; }

        public int? Page { get; set; }

        public IQueryConstraints GetQueryConstraints()
        {
            var constraints = new QueryConstraints();
            if (GlasswareId.HasValue)
            {
                constraints.AddFilter("glasswareId", GlasswareId.Value);
            }
            if (StyleId.HasValue)
            {
                constraints.AddFilter("styleId", StyleId.Value);
            }
            if (AvailabilityId.HasValue)
            {
                constraints.AddFilter("availableId", AvailabilityId.Value);
            }
            if (!String.IsNullOrEmpty(Order))
            {
                constraints.SortBy(Order);
            }
            if (!String.IsNullOrEmpty(Sort))
            {
                if (Sort.ToLower().Equals("desc"))
                {
                    constraints.Descending();
                }
            }
            if (Page.HasValue)
            {
                constraints.Page(Page.Value);
            }
            return constraints;
        }
    }
}