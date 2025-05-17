using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DAO
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly TrainDbContext _context;


        // Удаление пассажира
        public async Task<bool> DeletePassenger(int id)
        {

            //var cl = await db.Clients.Where(s => s.ClientId == Id).FirstOrDefaultAsync();
            //if (cl != null)
            //{
            //    db.Clients.Remove(cl);
            //    db.SaveChangesAsync();
            //    return true;
            //}
            //return false;

            var ps = await _context.Passengers.Where(s => s.Id == id).FirstOrDefaultAsync();
            if (ps != null)
            { 
                _context.Passengers.Remove(ps);
                _context.SaveChangesAsync();
                return true;
            }
            return false;

            //var passenger = await GetPassengerById(id);

            //if (passenger == null)
            //    throw new Exception("Passenger not found.");

            //// Если пассажир связан с билетами или другими сущностями, можно решить, что делать:
            //// Например, можно удалить связанные билеты перед удалением пассажира
            //if (passenger.Tickets.Any())
            //{
            //    // Логика удаления связанных объектов (например, билетов)
            //    _context.Tickets.RemoveRange(passenger.Tickets);
            //}

            //// Удаляем пассажира из контекста
            //_context.Passengers.Remove(passenger);

            //await SaveChanges(); // Сохраняем

            //return true;
        }
        public PassengerRepository(TrainDbContext context)
        {
            _context = context;
        }

        public async Task<Passenger> GetPassengerById(int id)
        {
            return await _context.Passengers.FindAsync(id);
        }

        public IQueryable<Passenger> GetAllPassengers()
        {
            return  _context.Passengers.AsQueryable();
        }

        public async Task<Passenger> AddPassenger(Passenger passenger)
        {
            await _context.Passengers.AddAsync(passenger);
            await _context.SaveChangesAsync();
            return passenger;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}