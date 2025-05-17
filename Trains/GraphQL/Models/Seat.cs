using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Уникальный идентификатор места

        [ForeignKey("CarriageId")]
        public int CarriageId { get; set; } // Внешний ключ на вагон

        public Carriage Carriage { get; set; } // Вагон, к которому принадлежит место

        [Required]
        public decimal Price { get; set; } // Цена места

        [Required]
        public bool IsAvailable { get; set; } // Доступность места

        public Ticket Ticket { get; set; } // Билет, если место занято
    }
}