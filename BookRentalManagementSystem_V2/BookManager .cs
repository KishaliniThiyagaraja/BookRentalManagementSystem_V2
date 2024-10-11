using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V2
{
    internal class BookManager

    {
        private List<Book> books = new List<Book>();
        private string nextId = 1;
        BookRepository bookRepository = new BookRepository();

        public void CreateBook(string title, string author, decimal rentalPrice)
        {

            if (ValidateBookRentalPrice(ref rentalPrice))
            {
                var book = new Book(nextId++, title, author, rentalPrice);
                //books.Add(book);
                bookRepository.CreateBook(book);
                Console.WriteLine("Book added successfully!");
            }
        }

        public void ReadBooks()
        {
            //if (books.Count == 0)
            //{
            //    Console.WriteLine("No books available.");
            //    return;
            //}

            //foreach (var book in books)
            //{
            //    Console.WriteLine(book);
            //}

            var data = bookRepository.GetAllBooks();
            foreach (var book in data)
            {
                Console.WriteLine($"{book.Title} {book.BookId} {book.RentalPrice} {book.Author}");
            }
        }

        public void UpdateBook(int bookId, string newTitle, string newAuthor, decimal c)
        {
            //var book = books.Find(b => b.BookId == bookId);
            //if (book != null)
            //{
            //    if (ValidateBookRentalPrice(ref newRentalPrice))
            //    {
            //        books.Remove(book);
            //        books.Add(new Book(bookId, newTitle, newAuthor, newRentalPrice));
            //        Console.WriteLine("Book updated successfully!");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Book not found.");
            //}
            var book = bookRepository.GetBookById(bookId);
            if (book != null)
            {
              //  book.BookId = bookId;
                book.Author = newAuthor;
                book.Title = newTitle;
                book.RentalPrice = c;
                bookRepository.UpdateBook(book);
            }

        }

        public void DeleteBook(int bookId)
        {
            //var book = books.Find(b => b.BookId == bookId);
            //if (book != null)
            //{
            //    books.Remove(book);
            //    Console.WriteLine("Book deleted successfully!");
            //}
            //else
            //{
            //    Console.WriteLine("Book not found.");
            //}
            bookRepository.DeleteBook(bookId);
        }

        public bool ValidateBookRentalPrice(ref decimal rentalPrice)
        {
            while (rentalPrice <= 0)
            {
                Console.WriteLine("Rental price must be a positive value. Please enter a valid rental price:");
                if (!decimal.TryParse(Console.ReadLine(), out rentalPrice) || rentalPrice <= 0)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
            return true;
        }
    }
}





