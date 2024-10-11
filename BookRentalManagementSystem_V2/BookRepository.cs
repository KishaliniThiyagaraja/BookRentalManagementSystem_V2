using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V2
{
    internal class BookRepository
    {
        private string connectionString = "server=(localdb)\\MSSQLLocaldb;database=BookManagement; Trusted_Connection=True;TrustServerCertificate=True;";

        public void CreateBook(Books book)
        {
            string title = CapitalizeTitle(book.Title);
            string query = "INSERT INTO Books (Title, Author, RentalPrice) VALUES (@Title, @Author, @RentalPrice)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@RentalPrice", book.RentalPrice);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }

        private string CapitalizeTitle(object title)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            string query = "SELECT * FROM Books";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var book = new Book(
                                    reader.GetString(0), // BookId
                                    reader.GetString(1), // Title
                                    reader.GetString(2), // Author
                                    reader.GetDecimal(3) // RentalPrice
                                );
                                books.Add(book);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
            return books;
        }

        public Book GetBookById(int id)
        {
            Book book = null;
            string query = "SELECT * FROM Books WHERE BookId = @BookId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookId", id);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                book = new Book(
                                    reader.GetString(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetDecimal(3)
                                );
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
            return book;
        }

        public void UpdateBook(Book book)
        {
            string query = "UPDATE Books SET Title = @Title, Author = @Author, RentalPrice = @RentalPrice WHERE BookId = @BookId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", CapitalizeTitle(book.Title));
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@RentalPrice", book.RentalPrice);
                    command.Parameters.AddWithValue("@BookId", book.BookId);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }

        public void DeleteBook(int id)
        {
            string query = "DELETE FROM Books WHERE BookId = @BookId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookId", id);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }

        public string CapitalizeTitle(string title)
        {
            if (string.IsNullOrEmpty(title)) return title;

            var words = title.ToLower().Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            }
            return string.Join("", words);
        }

        internal void CreateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }

    public class Books
    {
        public object Title { get; internal set; }
        public object Author { get; internal set; }
        public object RentalPrice { get; internal set; }
    }
}
