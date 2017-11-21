using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirsty.Repositories
{
    public class Beer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameDisplay { get; set; }
        public string Description { get; set; }
        public string Abv { get; set; }
        public int GlasswareId { get; set; }
        public int SrmId { get; set; }
        public int StyleId { get; set; }
        public string IsOrganic { get; set; }
        public string Status { get; set; }
        public string StatusDisplay { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public Glass Glass { get; set; }
        public Srm Srm { get; set; }
        public Style Style { get; set; }
        public string Ibu { get; set; }
        public int? AvailableId { get; set; }
        public Available Available { get; set; }
        public Labels Labels { get; set; }
        public string OriginalGravity { get; set; }
        public string ServingTemperature { get; set; }
        public string ServingTemperatureDisplay { get; set; }
    }

    public class RootObject<TEntity> where TEntity : class
    {
        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }
        public int TotalResults { get; set; }
        public List<TEntity> Data { get; set; }
        public string Status { get; set; }
    }
}
