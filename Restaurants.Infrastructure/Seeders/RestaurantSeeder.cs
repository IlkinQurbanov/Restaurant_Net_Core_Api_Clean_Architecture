using Restaurants.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Seeders
{
    public class RestaurantSeeder(RestaurantDbContext dbContext)
    {
        public async Task Seed()
        {
            if(await dbContext.Database.CanConnectAsync())
            {
                if(!dbContext.Restaurants.Any()) 
                {
                    var restaurants = GetRestaurants();
                }

            }
        }

        private object GetRestaurants()
        {
            throw new NotImplementedException();
        }
    }
}
