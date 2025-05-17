using GraphQL.Models;

namespace GraphQL.DAO
{
    public interface ICarriageRepository
    {
        IQueryable<Carriage> GetAllCarriages();
        Task<Carriage> GetCarriageById(int id);
        Task AddCarriage(Carriage carriage);
        Task SaveChanges();
    }

}
