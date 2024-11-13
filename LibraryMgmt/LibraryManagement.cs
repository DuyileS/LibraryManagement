using System;
using System.Collections.Generic;
using System.Globalization;
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

        private void LibraryTable(List<Book> books)
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| No   | Title            | Author          | ISBN           | Publication Date    | Category | Availability Status |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

            foreach (Book book in books)
            {
                Console.WriteLine($"| {book.BookId,-4} | {book.GetTitle().ToUpper(),-15} | {book.GetAuthor().ToUpper(),-15} | {book.GetISBN(),-14} | {book.GetPublicationDate(),-16}  | {book.GetCategory().ToUpper(),-12} | {book.GetAvailabilityStatus().ToUpper(),-20} |");
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
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

                if (title == null)
                {
                    Console.WriteLine("Try adding a book to the library again\nPress Enter to see menu");
                    return;
                }

                book.SetTitle(title);

                Console.Write("Enter Author: ");
                string author = Console.ReadLine();
                author = ValidateInput(author);

                if (author == null)
                {
                    Console.WriteLine("Try adding a book to the library again\nPress Enter to see menu");
                    return;
                }
                book.SetAuthor(author);

                Console.Write("Enter ISBN: ");
                string iSBN = Console.ReadLine();
                iSBN = ValidateISBN(iSBN);

                if (iSBN == null)
                {
                    Console.WriteLine("Try adding a book to the library again\nPress Enter to see menu");
                    return;
                }

                book.SetISBN(iSBN);

                Console.Write("Enter Publication Date(MM/DD/YYYY): ");
                string publicationDate = Console.ReadLine();
                DateOnly? convertedDate = ValidatePublicationDate(publicationDate);

                if (convertedDate == null)
                {
                    Console.WriteLine("Try adding a book to the library again\nPress Enter to see menu");
                    return;
                }

                book.SetPublicationDate(convertedDate);

                Console.Write("Enter Category : ");
                string category = Console.ReadLine();
                category = ValidateCategory(category);

                if (category==null)
                {
                    Console.WriteLine("Try adding a book to the library again\nPress Enter to see menu");
                    return;
                }

                book.SetCategory(category);

                Console.Write("Enter Availability Status(Available/Unavailable/Pending/Reserved): ");
                string availabilityStatus = Console.ReadLine();
                availabilityStatus = ValidateAvailability(availabilityStatus);

                if (availabilityStatus == null)
                {
                    Console.WriteLine("Try adding a book to the library again\nPress Enter to see menu");
                    return;
                }

                book.SetAvailabilityStatus(availabilityStatus);

                books.Add(book);
                Console.WriteLine("Book added to Library successfully\nPress Enter to see menu");
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


            if (book == null)
            {
                return;
            }

            Console.WriteLine("Choose the property to edit:");
            Console.WriteLine("1 to edit Title");
            Console.WriteLine("2 to edit Author");
            Console.WriteLine("3 to edit ISBN");
            Console.WriteLine("4 to edit Category");
            Console.WriteLine("5 to edit Publication Date");
            Console.WriteLine("6 to edit Availability Status");

            try {
                Console.Write("Enter Option: ");
                int editOption = Convert.ToInt32(Console.ReadLine());

                switch (editOption)
                {
                    case 1:
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();
                        title = ValidateInput(title);

                        if (title == null)
                        {
                            Console.WriteLine("Try adding a book to the library again\nPress Enter to see menu");
                            return;
                        }

                        book.SetTitle(title);
                        break;
                    case 2:
                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();
                        author = ValidateInput(author);

                        if (author == null)
                        {
                            Console.WriteLine("Try adding a book to the library again\nPress Enter to see menu");
                            return;
                        }
                        book.SetAuthor(author);
                        break;
                    case 3:
                        Console.Write("Enter ISBN: ");
                        string iSBN = Console.ReadLine();
                        iSBN = ValidateISBN(iSBN);

                        if (iSBN == null)
                        {
                            Console.WriteLine("Try adding a book to the library again\nPress Enter to see menu");
                            return;
                        }

                        book.SetISBN(iSBN);
                        break;
                    case 4:
                        Console.Write("Enter Publication Date(MM/DD/YYYY): ");
                        string publicationDate = Console.ReadLine();
                        DateOnly? convertedDate = ValidatePublicationDate(publicationDate);

                        if (convertedDate == null)
                        {
                            Console.WriteLine("Try adding a book to the library again\nPress Enter to see menu");
                            return;
                        }

                        book.SetPublicationDate(convertedDate);
                        break;
                    case 5:
                        Console.Write("Enter Category : ");
                        string category = Console.ReadLine();
                        category = ValidateCategory(category);

                        if (category == null)
                        {
                            Console.WriteLine("Try adding a book to the library again\nPress Enter to see menu");
                            return;
                        }

                        book.SetCategory(category);
                        break;
                    case 6:
                        Console.Write("Enter Availability Status: ");
                        string availabilityStatus = Console.ReadLine();
                        availabilityStatus = ValidateAvailability(availabilityStatus);

                        if (availabilityStatus == null)
                        {
                            Console.WriteLine("Try adding a book to the library again\nPress Enter to see menu");
                            return;
                        }

                        book.SetAvailabilityStatus(availabilityStatus);
                        break;

                }  
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Option\nChoose a valid Option\n\nPress Enter to load menu");
            }
        }

        public void RemoveBook()
        {
            Console.Write("Enter ID of the book you want to remove: ");

            string id = Console.ReadLine();
            Book book = GetBookById(id);


            if (book == null)
            {
                return;
            }

            try
            {
                books.Remove(book);
            }
            catch (Exception)
            {
                Console.WriteLine("Error occured while trying to remove book from the library");
            }
            Console.WriteLine("Book removed successfully!");
        }

        public void BorrowBook()
        {
            Console.Write("Enter ID of the book you want to borrow: ");
            string id = Console.ReadLine();

            Book book = GetBookById(id);

            if (book == null)
            {
                return;
            }

            if (book.GetAvailabilityStatus() == "Unavailable")
            {
                Console.WriteLine($"Book {book.BookId} {book.GetTitle()} is currently unavailable");
                return;
            }
            book.SetAvailabilityStatus("Unavailable");
            Console.WriteLine("Book successfully borrowed\nHave a good read!");
        }

        public void ReturnBook()
        {
            Console.Write("Enter ID of the book you want to return: ");
            string id = Console.ReadLine();

            Book book = GetBookById(id);

            if (book == null)
            {
                return;
            }

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
            List<Book> sortedBooks;
            int option;

            if (books.Count == 0) 
            {
                Console.WriteLine("No books available");
                return;
            }

            Console.Write("Enter 1 to sort by Publication Date: ");
            Console.Write("Enter 2 to sort by Title: ");
           
            try
            {
               option = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("You entered an invalid option. Try again");
                return;
            }

            if (option == 1)
            {
                sortedBooks = books.OrderBy(x => x.GetPublicationDate()).ToList();
                LibraryTable(sortedBooks);
            }
            else if (option == 2)
            {
                sortedBooks = books.OrderBy(x => x.GetTitle()).ToList();
                LibraryTable(sortedBooks);
            }
            else 
            {
                Console.WriteLine("You entered an invalid option");
            }
        }

        public void FilterBooks()
        {
            List<Book> filteredBooks;
            int option;

            if (books.Count == 0)
            {
                Console.WriteLine("No books available");
                return;
            }

            Console.WriteLine("Enter 1 to filter by Category");
            Console.WriteLine("Enter 2 to filter by Author");
            Console.WriteLine("Enter 3 to filter by Availability");
            Console.Write("Enter Option: ");

            try
            {
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("You entered an invalid option. Try again");
                return;
            }

            if (option == 1)
            {
                Console.Write("Enter Category to filter by: ");
                string category = Console.ReadLine();

                category = ValidateCategory(category);

                try
                {
                    filteredBooks = books.Where(x => string.Equals(x.GetCategory(), category, StringComparison.OrdinalIgnoreCase)).ToList();

                    if (!filteredBooks.Any())
                    {
                        Console.WriteLine($"No books found for category '{category}'.");
                        return;
                    }

                    LibraryTable(filteredBooks);
                }
                catch (Exception)
                {

                    Console.WriteLine($"Category {category} not found!\n Input a valid category");
                }
            }
            else if (option == 2)
            {
                Console.Write("Enter Author to filter by: ");
                string author = Console.ReadLine();
                author = ValidateInput(author);
                try
                {
                    filteredBooks = books.Where(x => string.Equals(x.GetAuthor(), author, StringComparison.OrdinalIgnoreCase)).ToList();

                    if (!filteredBooks.Any())
                    {
                        Console.WriteLine($"No books found for author '{author}'.");
                        return;
                    }

                    LibraryTable(filteredBooks);
                }
                catch (Exception)
                {

                    Console.WriteLine($"Author {author} not found!\n Input a valid author");
                }
            }
            else if (option == 3) 
            {
                Console.Write("Enter Availability Status to filter by: ");
                string availability = Console.ReadLine();
                availability = ValidateAvailability(availability);

                try
                {
                    filteredBooks = books.Where(x => string.Equals(x.GetAvailabilityStatus(), availability, StringComparison.OrdinalIgnoreCase)).ToList();

                    if (!filteredBooks.Any())
                    {
                        Console.WriteLine($"No books found as '{availability}'.");
                        return;
                    }

                    LibraryTable(filteredBooks);
                }
                catch (Exception)
                {

                    Console.WriteLine($"Input a valid availability");
                }

                
            }
            else
            {
                Console.WriteLine("You entered an invalid option");
            }
        }

        public void LoadFile()
        {
            books.Clear();

            if(File.Exists("books.txt"))
            {
                using (StreamReader streamReader = new StreamReader("books.txt"))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string[] data = streamReader.ReadLine().Split(",");
                        Book book = new Book();
                        book.SetTitle(data[0]);
                        book.SetAuthor(data[1]);
                        book.SetISBN(data[2]);
                        book.SetPublicationDate(DateOnly.ParseExact(data[3].Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None));
                        book.SetCategory(data[4]);
                        book.SetAvailabilityStatus(data[5]);

                        books.Add(book);
                    }
                }
            }

          
        }

        public void SaveToFile()
        {
            using (StreamWriter streamWriter = new StreamWriter("books.txt"))
            {
                foreach (Book book in books) 
                {
                    streamWriter.WriteLine($"{book.GetTitle()},{book.GetAuthor()},{book.GetISBN()},{book.GetPublicationDate()},{book.GetCategory()},{book.GetAvailabilityStatus()}");
                }
            }
        }

        private Book GetBookById(string id)
        {
            if (id == null) {

                Console.WriteLine("Invalid Book ID provided.");
                return null;
            }

            try
            {
                Book book = books.Single(book => book.BookId == id);

                return book;
            }
            catch (Exception)
            {
                Console.WriteLine($"Book with ID {id} not found");
                return null;
            } 
        }

        private static string? ValidateInput(string input)
        {
            int attempts = 0;

            while (input.Length == 0 || string.IsNullOrWhiteSpace(input))
            {
                if (attempts == 5)
                {
                    Console.WriteLine("You entered an invalid input 5 times");
                    return null;
                }

                Console.Write("Please enter a valid input: ");
                input = Console.ReadLine();
                attempts++;
            }
   
            return input;
        }

        private static string? ValidateCategory(string category)
        {
            int attempts = 0;

            while (category.Length == 0 || string.IsNullOrWhiteSpace(category) || !IsValidCategory(category))
            {
                if (attempts == 5)
                {
                    Console.WriteLine("You entered an invalid category 5 times");
                    return null;
                }

                Console.Write("Category for a book in this library must belong to one of the standard 21 categories for books in a library\n\nPlease enter a valid category: ");
                category = Console.ReadLine();
                attempts++;
            }

            return category;
        }

        private static string? ValidateAvailability(string availability)
        {
            int attempts = 0;

            while (availability.Length == 0 || string.IsNullOrWhiteSpace(availability) || !IsValidAvailabilityStatus(availability))
            {
                if (attempts == 5)
                {
                    Console.WriteLine("You entered an invalid availability status 5 times");
                    return null;
                }

                Console.Write("Please enter a valid availability status: ");
                availability = Console.ReadLine();
                attempts++;
            }

            return availability;
        }

        private static string? ValidateISBN(string isbn)
        {
            isbn = isbn.Replace("-", "").Replace(" ", "");
            string validatedIsbn;
            int attempts = 0;

            while (isbn.Length != 10 && isbn.Length != 13 || string.IsNullOrWhiteSpace(isbn))
            {
                if (attempts == 5)
                {
                    Console.WriteLine("You entered an invalid ISBN 5 times.");
                    return null;
                }

                Console.Write("Please enter a valid ISBN: ");
                isbn = Console.ReadLine();
                attempts++;
            }

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

            // If it reaches here, it means the input did not match any format
            Console.WriteLine("The ISBN format is invalid.");
            return null;

        }

        private static DateOnly? ValidatePublicationDate(string publicationDate)
        {
            int attempts = 0;
            var datePattern = @"^\d{2}/\d{2}/\d{4}$"; // MM/dd/yyyy format

            // Continue to prompt the user if the format is incorrect or the input is empty

            while (!Regex.IsMatch(publicationDate, datePattern) || publicationDate.Length <10 || string.IsNullOrWhiteSpace(publicationDate))
            {
                if (attempts == 5)
                {
                    Console.WriteLine("You entered an invalid date 5 times.");
                    return null;
                }

                Console.Write("Please enter a valid date(MM/dd/yyyy): ");
                publicationDate = Console.ReadLine();
                attempts++;
            }

            bool successfulParse = false;

            int parseAttempts = 0;

            DateOnly? validDate;

            while (!successfulParse)
            {
                // Remove slashes and spaces
                publicationDate = publicationDate.Replace("/", "").Replace(" ", "");

                int month = Convert.ToInt32(publicationDate.Substring(0, 2));
                int day = Convert.ToInt32(publicationDate.Substring(2, 2));
                int year = Convert.ToInt32(publicationDate.Substring(4, 4));

                if (DateOnly.TryParseExact($"{month:D2}/{day:D2}/{year}", "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly date) 
                    && date <= DateOnly.FromDateTime(DateTime.Today))
                {
                    validDate = date;
                    successfulParse = true;
                    return validDate;
                }

                if (parseAttempts == 5)
                {
                    Console.WriteLine("You entered an invalid date 5 times.");
                    return null;
                }

                Console.Write("Please enter a valid date(MM/dd/yyyy): ");
                publicationDate = Console.ReadLine();
                parseAttempts++;
            }

            return null;
        }

        private static bool IsValidCategory(string category)
        {
             List<string> Categories =
            [
                "Fiction",
                "Non-Fiction",
                "Science",
                "Mathematics",
                "History",
                "Biography",
                "Children's Books",
                "Poetry",
                "Philosophy",
                "Psychology",
                "Religion",
                "Self-Help",
                "Science Fiction",
                "Fantasy",
                "Mystery",
                "Romance",
                "Horror",
                "Graphic Novels/Comics",
                "Art",
                "Travel",
                "Technology"
            ];

           return Categories.Exists(x => x.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        private static bool IsValidAvailabilityStatus(string availability)
        {
             List<string> Availability =
             [
            "Available",
            "Unavailable",
            "Pending",
            "Reserved"
             ];

           return Availability.Exists(status => status.Equals(availability, StringComparison.OrdinalIgnoreCase));
        }

    }
}