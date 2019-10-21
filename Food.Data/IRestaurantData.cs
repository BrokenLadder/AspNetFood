using Food.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Food.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name ="Scott's Pizza", Location="Scott's House", Cuisine=CuisineType.Italian},
                new Restaurant {Id = 2, Name ="Wendys", Location="Down The Street", Cuisine=CuisineType.None},
                new Restaurant {Id = 3, Name ="Taco Time", Location="Mexico", Cuisine=CuisineType.Mexican},
                new Restaurant {Id = 4, Name ="Taste of India", Location="India", Cuisine=CuisineType.Indian}

            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name 
                   select r;
        }
    }
}
