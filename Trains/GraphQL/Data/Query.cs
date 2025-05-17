using GraphQL.DAO;
using GraphQL.Models;

namespace GraphQL.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Passenger> GetPassengers([Service] IPassengerRepository passengerRepository) =>
        passengerRepository.GetAllPassengers();

        [UseProjection]
        public Task<Passenger> GetPassenger([Service] IPassengerRepository passengerRepository, int id) =>
            passengerRepository.GetPassengerById(id);

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Seller> GetSellers([Service] ISellerRepository sellerRepository) =>
            sellerRepository.GetAllSellers();

        [UseProjection]
        public Task<Seller> GetSeller([Service] ISellerRepository sellerRepository, int id) =>
            sellerRepository.GetSellerById(id);

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Train> GetTrains([Service] ITrainRepository trainRepository) =>
            trainRepository.GetAllTrains();

        [UseProjection]
        public Task<Train> GetTrain([Service] ITrainRepository trainRepository, int id) =>
            trainRepository.GetTrainById(id);

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Carriage> GetCarriages([Service] ICarriageRepository carriageRepository) =>
            carriageRepository.GetAllCarriages();

        [UseProjection]
        public Task<Carriage> GetCarriage([Service] ICarriageRepository carriageRepository, int id) =>
            carriageRepository.GetCarriageById(id);

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Seat> GetSeats([Service] ISeatRepository seatRepository) =>
            seatRepository.GetAllSeats();

        [UseProjection]
        public Task<Seat> GetSeat([Service] ISeatRepository seatRepository, int id) =>
            seatRepository.GetSeatById(id);

        //[UseProjection]
        //[UseFiltering]
        //[UseSorting]
        //public IQueryable<Ticket> GetTickets([Service] ITicketRepository ticketRepository) =>
        //    ticketRepository.GetAllTickets();

        [UseProjection]
        public Task<Ticket> GetTicket([Service] ITicketRepository ticketRepository, int id) =>
            ticketRepository.GetTicketById(id);
    }
}
