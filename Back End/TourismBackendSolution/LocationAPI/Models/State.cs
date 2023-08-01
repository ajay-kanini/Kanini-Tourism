using System;
using System.Collections.Generic;

namespace LocationAPI.Models
{
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CountryId { get; set; }
        public string CountryCode { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public string StateCode { get; set; } = null!;
        public string? Type { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<City> Cities { get; set; }
    }
}
