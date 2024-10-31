using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryMgmt
{
    public class LibraryManagement
    {
        private List<Book> books;

        public LibraryManagement() 
        {
            books = [];
        }
   
        public void LibraryTable(List<Book> books)
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| No  | Title            | Author          | ISBN  | Category  | Publication Date   | Availability Status          |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

            foreach (Book book in books)
            {
                Console.WriteLine($"{book.BookId,-3} {book.GetTitle(),-16}, {book.GetAuthor(),-16}, {book.GetISBN(),-15}, {book.GetCategory(),-10}, {book.GetPublicationDate(),-10}, {book.GetAvailabilityStatus(),-15}\n");
            }
        }

        public void ViewBooks()
        {
            if (books.Count == 0) 
            {
                Console.WriteLine("No books available");
                return;
            }

            LibraryTable(books);
        }

        public void AddNewBook()
        {
            Book book = new Book();

            try
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine();
                title = ValidateInput(title);
                book.SetTitle(title);

                Console.Write("Enter Author: ");
                string author = Console.ReadLine();
                author = ValidateInput(author);
                book.SetAuthor(author);

                Console.Write("Enter ISBN: ");
                string iSBN = Console.ReadLine();
                iSBN = ValidateISBN(iSBN);
                book.SetISBN(iSBN);

                Console.Write("Enter Category : ");
                string category = Console.ReadLine();
                category = ValidateInput(category);
                book.SetCategory(category);

                Console.Write("Enter Publication Date: ");
                string publicationDate = Console.ReadLine();
                publicationDate = ValidatePublicationDate(publicationDate);
                book.SetPublicationDate(publicationDate);

                Console.Write("Enter Availability Status: ");
                string availabilityStatus = Console.ReadLine();
                availabilityStatus = ValidateInput(availabilityStatus);
                book.SetAvailabilityStatus(availabilityStatus);

                books.Add(book);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Data");
            }
        }

        public void EditBook()
        {
            Console.Write("Enter ID of the book you want to edit: ");
            string id = Console.ReadLine();

            Book book = GetBookById(id);

            try
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine();
                title = ValidateInput(title);
                book.SetTitle(title);

                Console.Write("Enter Author: ");
                string author = Console.ReadLine();
                author = ValidateInput(author);
                book.SetAuthor(author);

                Console.Write("Enter ISBN: ");
                string iSBN = Console.ReadLine();
                iSBN = ValidateISBN(iSBN);
                book.SetISBN(iSBN);


                Console.Write("Enter Category : ");
                string category = Console.ReadLine();
                category = ValidateInput(category);
                book.SetCategory(category);

                Console.Write("Enter Publication Date: ");
                string publicationDate = Console.ReadLine();
                publicationDate = ValidatePublicationDate(publicationDate);
                book.SetPublicationDate(publicationDate);

                Console.Write("Enter Availability Status: ");
                string availabilityStatus = Console.ReadLine();
                availabilityStatus = ValidateInput(availabilityStatus);
                book.SetAvailabilityStatus(availabilityStatus);

                books.Add(book);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Data");
            }
        }

        public void RemoveBook()
        {
            Console.Write("Enter ID of the book you want to remove: ");

            string id = Console.ReadLine();
            Book book = GetBookById(id);
            Console.WriteLine("Book removed successfully!");
        }

        public void BorrowBook()
        {
            Console.Write("Enter ID of the book you want to borrow: ");
            string id = Console.ReadLine();
            Book book = GetBookById(id);
            if( book.GetAvailabilityStatus() == "Unavailable")
            {
                Console.WriteLine($"Book {book.BookId} {book.GetTitle()} is currently unavailable");
                return;
            }
            book.SetAvailabilityStatus("Unavailable");
        }

        public void ReturnBook()
        {
            Console.Write("Enter ID of the book you want to return: ");
            string id = Console.ReadLine();
            Book book = GetBookById(id);
            if (book.GetAvailabilityStatus() == "Available")
            {
                Console.WriteLine($"Book {book.BookId} {book.GetTitle()} is already available");
                return;
            }
            book.SetAvailabilityStatus("Available");
            Console.WriteLine("Book returned successfully!");
        }

        public void SortBooks()
        {
            Console.Write("Enter 1 to sort by Publication Date: ");
            Console.Write("Enter 2 to sort by Title: ");
        }

        public void FilterBooks()
        {
            Console.Write("Enter 1 to filter by Category: ");
            Console.Write("Enter 2 to filter by Author: ");
            Console.Write("Enter 3 to filter by Availability: ");
        }

        public void LoadFile()
        {

        }

        public void EditFile()
        {

        }

        public void SaveToFile()
        { 
        
        }

        public Book GetBookById(string id)
        {
            if (id == null) { 
            
                throw new ArgumentNullException("id");
            }

           Book book = books.Single(book => book.BookId == id);

            if (book == null)
            {
                throw new InvalidOperationException("Book not found.");
            }


            return book;
        }

        public static string ValidateInput(string input)
        {
            if (input.Length == 0 || string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Please enter a valid input: ");
               string newInput = Console.ReadLine();
               if (newInput.Length == 0 || string.IsNullOrWhiteSpace(newInput))
                {
                    Console.WriteLine("You entered an invalid input");
                    return "You entered an invalid input";
                }

                ValidateInput(newInput);
            }
   
            return input;
        }

        public static string ValidateISBN(string isbn)
        {
            isbn = isbn.Replace("-", "").Replace(" ", "");
            string validatedIsbn;

            if (isbn.Length == 13 && Regex.IsMatch(isbn, @"^\d{13}$"))
            {
                // Format as ISBN-13 (XXX-X-XXX-XXXXX-X)
                validatedIsbn = $"{isbn.Substring(0, 3)}-{isbn.Substring(3, 1)}-{isbn.Substring(4, 3)}-{isbn.Substring(7, 5)}-{isbn.Substring(12, 1)}";
                return validatedIsbn;
            }
            else if (isbn.Length == 10 && Regex.IsMatch(isbn, @"^\d{9}[\dXx]$"))
            {
                // Format as ISBN-10 (X-XXX-XXXXX-X)
                validatedIsbn = $"{isbn.Substring(0, 1)}-{isbn.Substring(1, 3)}-{isbn.Substring(4, 5)}-{isbn.Substring(9, 1)}";
                return validatedIsbn;
            }
            else
            {
                Console.WriteLine("You entered an invalid input");
                return "You entered an invalid ISBN";
            }

        }

        public static string ValidatePublicationDate(string publicationDate)
        {
            // Remove slashes and spaces
            publicationDate = publicationDate.Replace("/", "").Replace(" ", "");

            if (publicationDate.Length == 8 && Regex.IsMatch(publicationDate, @"^\d{8}$"))
            {
                // Extract day, month, and year
                int day = Convert.ToInt32(publicationDate.Substring(0, 2));
                int month = Convert.ToInt32(publicationDate.Substring(2, 2));
                int year = Convert.ToInt32(publicationDate.Substring(4, 4));

                // Try creating a DateTime to check for a valid date
                if (DateTime.TryParse($"{year}/{month}/{day}", out DateTime validDate) && year <= 2024)
                {
                    // Format as MM/dd/YYYY if valid
                    return validDate.ToString("MM/dd/yyyy");
                }
            }

            Console.WriteLine("You entered an invalid date");
            return "You entered an invalid Publication date";
        }

        public static void ValidateFile() 
        {
        
        }
    }
}
