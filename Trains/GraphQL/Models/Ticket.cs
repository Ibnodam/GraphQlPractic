using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{


    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Уникальный идентификатор билета

        [ForeignKey("PassengerId")]
        public int PassengerId { get; set; } // Внешний ключ на пассажира

        public Passenger Passenger { get; set; } // Пассажир, купивший билет

        [ForeignKey("SellerId")]
        public int SellerId { get; set; } // Внешний ключ на продавца

        public Seller Seller { get; set; } // Продавец, продавший билет

        [ForeignKey("SeatId")]
        public int SeatId { get; set; } // Внешний ключ на место

        public Seat Seat { get; set; } // Место, на которое куплен билет

        [Required]
        public DateTime PurchaseDate { get; set; } // Дата покупки

        [ForeignKey("TrainId")]
        public int TrainId { get; set; } // Внешний ключ на поезд

        public Train Train { get; set; } // Поезд, к которому относится билет
    }
}
