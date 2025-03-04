using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Entites.Models
{
    public class LibraryBooks
    {
        [Key]
        public int BookId { get; set; }

        public string BookName { get; set; }

        public string Author {  get; set; }

        public int BookCode { get; set; }

        public int AvailableCopies { get; set; }
        public ICollection<LibraryTransactions>? LibraryTransactions { get; set; }

    }
}
