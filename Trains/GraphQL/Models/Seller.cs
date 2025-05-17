using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    public class Seller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Уникальный идентификатор продавца

        [Required]
        public string Name { get; set; } // Имя продавца

        [Required]
        public string PhoneNumber { get; set; } // Номер телефона продавца

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>(); // Список проданных билетов
    }

}
