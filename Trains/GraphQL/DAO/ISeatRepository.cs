using GraphQL.Models;

namespace GraphQL.DAO
{
    public interface ISeatRepository
    {
        Task<Seat> GetSeatById(int id);
        IQueryable<Seat> GetAllSeats();
        Task AddSeat(Seat seat);
        Task SaveChanges();
    }
}
