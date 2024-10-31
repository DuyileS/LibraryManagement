
using LibraryMgmt;

int option;
bool active = true;
LibraryManagement libraryManager = new();
libraryManager.LoadFile();

while (active)
{
    Console.WriteLine("\t\t\t*********WELCOME TO LIBRARY MANAGER *********");
    Console.WriteLine("Please select an option:");
    Console.WriteLine("1. View list of books");
    Console.WriteLine("2. Add a new book to the Library");
    Console.WriteLine("3. Edit book details");
    Console.WriteLine("4. Borrow a book");
    Console.WriteLine("5. Return a book");
    Console.WriteLine("6. Filter books");
    Console.WriteLine("7. Sort books");
    Console.WriteLine("8. Load files");
    Console.WriteLine("9. Edit file");
    Console.WriteLine("10. Delete a book");
    Console.WriteLine("11. Save");
    Console.WriteLine("12. Exit");
    Console.Write("Enter Option: ");

    try
    {
        option = Convert.ToInt32(Console.ReadLine());
       switch(option)
        {
            case 1:
                libraryManager.ViewBooks();
                break;
            case 2:
                libraryManager.AddNewBook();
                break;
            case 3:
                libraryManager.EditBook();
                break;
            case 4:
                libraryManager.BorrowBook(); 
                break;
            case 5:
                libraryManager.ReturnBook();
                break;
            case 6:
                libraryManager.FilterBooks();
                break;
            case 7:
                libraryManager.SortBooks();
                break;
            case 8:
                libraryManager.LoadFile();
                break;
            case 9:
                libraryManager.EditFile();
                break;
            case 10:
                libraryManager.RemoveBook();
                break;
            case 11:
                libraryManager.SaveToFile();
                break;
            case 12:
                active = false;
                Console.WriteLine("Exiting Library Manager...");
                break;
            default:
                Console.WriteLine("Invalid Option\nPlease input valid option\n\nPress Enter to reload menu");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid Option\nChoose a valid Option\n\nPress Enter to load menu");
    }
    Console.ReadKey();
}