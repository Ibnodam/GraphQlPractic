using GraphQL.Models;

namespace GraphQL.DAO
{
    public interface IPassengerRepository
    {
        Task<Passenger> GetPassengerById(int id);
        IQueryable<Passenger> GetAllPassengers();
        Task<Passenger> AddPassenger(Passenger passenger);
        Task<bool> DeletePassenger(int id);
        Task SaveChanges();
    }
}
