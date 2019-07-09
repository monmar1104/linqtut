using System;
using System.Collections.Generic;

namespace LinQTut
{
    public class City
    {
        public int Id  { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public static List<City> GetAllCities()
        {
            return new List<City>()
            {
                    new City {Id = 1, Name = "Gdańsk", CountryId = 1 },
                    new City {Id = 2, Name = "Kościerzyna", CountryId = 1 },
                    new City {Id = 3, Name = "Dortmund", CountryId = 2 },
                    new City {Id = 4, Name = "Hanover", CountryId = 2 },
                    new City {Id = 5, Name = "New York", CountryId = 3 },
                    new City {Id = 6, Name = "Los Angeles", CountryId = 3 },
                    new City {Id = 7, Name = "Toronto", CountryId = 4 }
            };
        }
    }
}
