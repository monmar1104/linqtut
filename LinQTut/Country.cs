using System;
using System.Collections.Generic;

namespace LinQTut
{
    public class Country
    {
        public int Id  { get; set; }
        public string Name { get; set; }

        public static List<Country> GetAllCountries()
        {
            return new List<Country>()
            {
                    new Country {Id = 1, Name = "Poland" },
                    new Country {Id = 2, Name = "Germany" },
                    new Country {Id = 3, Name = "USA" },
                    new Country {Id = 4, Name = "Canada" }
            };
        }
    }
}
