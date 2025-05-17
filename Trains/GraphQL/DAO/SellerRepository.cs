using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DAO
{
    public class SellerRepository : ISellerRepository
    {
        private readonly TrainDbContext _context;

        public SellerRepository(TrainDbContext context)
        {
            _context = context;
        }

        public async Task<Seller> GetSellerById(int id)
        {
            return await _context.Sellers.FindAsync(id);
        }

        public IQueryable<Seller> GetAllSellers()
        {
            return  _context.Sellers.AsQueryable();
        }

        public async Task AddSeller(Seller seller)
        {
            await _context.Sellers.AddAsync(seller);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}