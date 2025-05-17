using GraphQL.Models;

namespace GraphQL.DAO
{
    public interface ISellerRepository
    {
        Task<Seller> GetSellerById(int id);
        IQueryable<Seller> GetAllSellers();
        Task AddSeller(Seller seller);
        Task SaveChanges();
    }
}
