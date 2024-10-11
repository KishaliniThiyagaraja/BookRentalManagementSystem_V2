using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V2
{
    internal class Book
    {

        public string BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal RentalPrice { get; set; }
        public int TotalBooks { get; set; }

        public Book(string bookId, string title, string author, decimal rentalPrice)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            RentalPrice = rentalPrice;
            TotalBooks++;
        }
        public Book() { }

        public override string ToString()
        {
            return $"ID: {BookId}, Title: {Title}, Author: {Author}, RentalPrice: {RentalPrice:C}";
        }
    }

}
}
