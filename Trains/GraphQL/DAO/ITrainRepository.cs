using GraphQL.Models;

namespace GraphQL.DAO
{
    public interface ITrainRepository
    {
        Task<Train> GetTrainById(int id);
        IQueryable<Train> GetAllTrains();
        Task AddTrain(Train train);
        Task SaveChanges();
    }
}
