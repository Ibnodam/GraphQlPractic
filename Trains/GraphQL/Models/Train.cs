using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Models
{
    public class Train
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Уникальный идентификатор поезда

        [Required]
        public string TrainNumber { get; set; } // Номер поезда

        public ICollection<Carriage> Carriages { get; set; } = new List<Carriage>(); // Список вагонов
                                                                                     // Добавляем коллекцию билетов, ссылающихся на этот поезд
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>(); // Коллекция билетов для поезда

    }
}