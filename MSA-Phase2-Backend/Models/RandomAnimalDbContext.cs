using Microsoft.EntityFrameworkCore;
using MSA_Phase2_Backend.Models;

namespace MSA_Phase2_Backend.Models
{
    public class RandomAnimalDbContext : DbContext
    {
        public RandomAnimalDbContext(DbContextOptions o) : base(o) { }
        public DbSet<RandomAnimal> RandAnimal { get; set; }
    }
}
