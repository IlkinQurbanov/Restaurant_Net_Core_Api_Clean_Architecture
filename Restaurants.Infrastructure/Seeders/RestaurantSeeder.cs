using Restaurants.Infrastructure.Persistance;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Seeders
{
    public class RestaurantSeeder : IRestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    await _dbContext.Restaurants.AddRangeAsync(restaurants);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            // Sample data for seeding the database
            return new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "The Gourmet Kitchen",
                    Description = "Fine dining with a modern twist.",
                    Category = "Fine Dining",
                    HasDelivery = true,
                    ContactEmail = "contact@gourmetkitchen.com",
                    ContactNumber = "123-456-7890",
                    Address = new Address
                    {
                        City = "New York",
                        Street = "123 5th Avenue",
                        PostalCode = "10001"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "Lobster Bisque", Description = "Creamy lobster soup with a hint of brandy.", Price = 25.00m },
                        new Dish { Name = "Truffle Pasta", Description = "Pasta with a rich truffle sauce.", Price = 30.00m }
                    }
                },
                new Restaurant
                {
                    Name = "Pizza Heaven",
                    Description = "The best pizza in town.",
                    Category = "Casual Dining",
                    HasDelivery = true,
                    ContactEmail = "info@pizzaheaven.com",
                    ContactNumber = "987-654-3210",
                    Address = new Address
                    {
                        City = "Los Angeles",
                        Street = "456 Sunset Boulevard",
                        PostalCode = "90028"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "Margherita Pizza", Description = "Classic pizza with fresh tomatoes and mozzarella.", Price = 15.00m },
                        new Dish { Name = "Pepperoni Pizza", Description = "Spicy pepperoni with a rich tomato sauce.", Price = 18.00m }
                    }
                }
            };
        }
    }
}
