using GraphQL.DAO;
using GraphQL.Models;

namespace GraphQL.Data
{
    public class Mutation
    {

        [Serial]
        public async Task<Carriage?> AddCarriage(
    [Service] ICarriageRepository carriageRepository, string)
        {
            //await carriageRepository.SaveChanges(); // Сохраняем изменения

            return await carriageRepository.AddCarriage(carriage);// Возвращаем созданный объект
        }


        // Мутация для удаления клиента по ID
        [Serial]
        public async Task<bool> DeleteClient([Service] IPassengerRepository passengerRepository, int id)
        {
            // Вызов метода репозитория для удаления клиента
            return await passengerRepository.DeletePassenger(id);
        }


        [Serial]
        public async Task<Passenger> InsertClient([Service] IPassengerRepository clientRepository, string name, string lastName,
            string email)
        {

            Passenger client = new Passenger()
            {
               FirstName = name,
               LastName = lastName,
               Email = email
            };

            return await clientRepository.AddPassenger(client);
        }
    }
}

