using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    public class Carriage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Уникальный идентификатор вагона

        [ForeignKey("TrainId")]
        public int TrainId { get; set; } // Внешний ключ на поезд

        public Train Train { get; set; } // Поезд, к которому принадлежит вагон

        [Required]
        public string CarriageType { get; set; } // Тип вагона

        public ICollection<Seat> Seats { get; set; } = new List<Seat>(); // Список мест в вагоне
    }

}
