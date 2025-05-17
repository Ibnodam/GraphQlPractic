using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    public class Passenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Уникальный идентификатор пассажира

        [Required]
        public string FirstName { get; set; } // Имя пассажира

        [Required]
        public string LastName { get; set; } // Фамилия пассажира

        [Required]
        public string Email { get; set; } // Электронная почта пассажира

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>(); // Список билетов
    }

}
