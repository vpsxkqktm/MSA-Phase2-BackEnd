using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MSA_Phase3_Backend.Domain.Models
{
    public class RandomAnimalDbContext : DbContext
    {
        public RandomAnimalDbContext(DbContextOptions<RandomAnimalDbContext> o) : base(o) { }
        public DbSet<RandomAnimal> RandAnimal { get; set; }
    }
}
