using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DAO
{

    public class TicketRepository : ITicketRepository
    {
        private readonly TrainDbContext _context;

        public TicketRepository(TrainDbContext context)
        {
            _context = context;
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task AddTicket(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}