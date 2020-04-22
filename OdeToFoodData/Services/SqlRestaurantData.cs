using OdeToFoodData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFoodData.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
       
        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants.OrderBy(r => r.Id);
        }
        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public void Update(Restaurant restaurant)
        {
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }
    }
}
