﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thirsty.Repositories;
using System.ComponentModel;

namespace Thirsty
{
    public class FilterParameters
    {
        public int? GlasswareId { get; set; }
        public int? StyleId { get; set; }
        public int? AvailabilityId { get; set; }
        public string Order { get; set; }
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
            if(!String.IsNullOrEmpty(Order))
            {
                constraints.SortBy(Order);
            }
            if(!String.IsNullOrEmpty(Sort))
            {
                if(Sort.ToLower().Equals("desc"))
                {
                    constraints.Descending();
                }
            }
            if(Page.HasValue)
            {
                constraints.Page(Page.Value);
            }
            return constraints;
        }
    }
}