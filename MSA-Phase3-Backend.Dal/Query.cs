using MSA_Phase3_Backend.Domain.Models;

namespace MSA_Phase3_Backend.Dal
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<RandomAnimal> GetAnimals ([Service] RandomAnimalDbContext context) =>
            context.RandAnimal;
        
    }
}
