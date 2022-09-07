using Microsoft.EntityFrameworkCore;
using MSA_Phase3_Backend.Domain.Models;

namespace MSA_Phase3_Backend.Dal
{
    public class RandomAnimalDbContext : DbContext
    {
        public RandomAnimalDbContext(DbContextOptions<RandomAnimalDbContext> o) : base(o) { }
        public DbSet<RandomAnimal> RandAnimal { get; set; }
    }
}
