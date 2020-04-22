using OdeToFoodData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFoodData.Services
{
    public class OdeToFoodDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
