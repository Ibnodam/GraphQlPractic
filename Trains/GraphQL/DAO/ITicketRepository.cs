using GraphQL.Models;

namespace GraphQL.DAO
{
    public interface ITicketRepository
    {
            Task<Ticket> GetTicketById(int id);
            Task AddTicket(Ticket ticket);
            Task SaveChanges();
    }
}
