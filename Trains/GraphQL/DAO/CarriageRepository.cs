using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DAO
{
    public class CarriageRepository : ICarriageRepository
    {
        private readonly TrainDbContext _context;

        public CarriageRepository(TrainDbContext context)
        {
            _context = context;
        }

        public async Task<Carriage> GetCarriageById(int id)
        {
            var carriage = await _context.Carriages.Where(p => p.Id == id).FirstOrDefaultAsync();
            if(carriage!=null) return carriage;
            return null!;
        }

        public IQueryable<Carriage> GetAllCarriages()
        {
            return _context.Carriages.AsQueryable();
        }

        public async Task AddCarriage(Carriage carriage)
        {
            await _context.Carriages.AddAsync(carriage);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }

}
