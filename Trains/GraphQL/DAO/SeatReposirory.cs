using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DAO
{
    public class SeatRepository : ISeatRepository
    {
        private readonly TrainDbContext _context;

        public SeatRepository(TrainDbContext context)
        {
            _context = context;
        }

        public async Task<Seat> GetSeatById(int id)
        {
            return await _context.Seats.FindAsync(id);
        }

        public IQueryable<Seat> GetAllSeats()
        {
            return _context.Seats.AsQueryable();
        }

        public async Task AddSeat(Seat seat)
        {
            await _context.Seats.AddAsync(seat);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }

}
