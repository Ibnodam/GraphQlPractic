using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DAO
{
    public class TrainRepository : ITrainRepository
    {
        private readonly TrainDbContext _context;

        public TrainRepository(TrainDbContext context)
        {
            _context = context;
        }

        public async Task<Train> GetTrainById(int id)
        {
            return await _context.Trains.FindAsync(id);
        }

        public IQueryable<Train> GetAllTrains()
        {
            return  _context.Trains.AsQueryable();
        }

        public async Task AddTrain(Train train)
        {
            await _context.Trains.AddAsync(train);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}