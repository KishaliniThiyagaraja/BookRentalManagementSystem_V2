using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookManager bookManager = new BookManager();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Book Rental Management System:");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Update a Book");
                Console.WriteLine("4. Delete a Book");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Enter Title: ");
                            string title = Console.ReadLine();
                            Console.Write("Enter Author: ");
                            string author = Console.ReadLine();
                            Console.Write("Enter Rental Price: ");
                            decimal rentalPrice = decimal.Parse(Console.ReadLine());
                            bookManager.CreateBook(title, author, rentalPrice);
                            Console.WriteLine("\npress enter to continue");
                            Console.ReadLine();

                            break;

                        case 2:
                            Console.Clear();
                            bookManager.ReadBooks();
                            Console.WriteLine("\npress enter to continue");
                            Console.ReadLine();

                            break;

                        case 3:
                            Console.Clear();
                            Console.Write("Enter Book ID to update: ");
                            int bookIdToUpdate = int.Parse(Console.ReadLine());
                            Console.Write("Enter New Title: ");
                            string newTitle = Console.ReadLine();
                            Console.Write("Enter New Author: ");
                            string newAuthor = Console.ReadLine();
                            Console.Write("Enter New Rental Price: ");
                            decimal newRentalPrice = decimal.Parse(Console.ReadLine());
                            bookManager.UpdateBook(bookIdToUpdate, newTitle, newAuthor, newRentalPrice);
                            Console.WriteLine("\npress enter to continue");
                            Console.ReadLine();

                            break;

                        case 4:
                            Console.Clear();
                            Console.Write("Enter Book ID to delete: ");
                            int bookIdToDelete = int.Parse(Console.ReadLine());
                            bookManager.DeleteBook(bookIdToDelete);
                            Console.WriteLine("\npress enter to continue");
                            Console.ReadLine();

                            break;

                        case 5:
                            Console.Clear();
                            Console.WriteLine("Exiting the system.");
                            Console.WriteLine("\npress enter to continue");
                            Console.ReadLine();

                            return;

                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid option. Please try again.");
                            Console.WriteLine("\npress enter to continue");
                            Console.ReadLine();

                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.WriteLine("\npress enter to continue");
                    Console.ReadLine();

                }
            }
        }
    }

}
    
