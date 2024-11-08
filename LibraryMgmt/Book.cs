using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgmt
{
    public class Book
    {
        private static int _bookCounter = 0;

        public Book() 
        {
            this.BookId = GenerateBookId();
        }

        public string BookId {get;}
        private string Title;
        private string Author;
        private string ISBN;
        private DateOnly? PublicationDate;
        private string Category;
        private string AvailabilityStatus;

        public string GetTitle()
        {
           return this.Title;
        }

        public void SetTitle(string title)
        {
            this.Title = title;
        }

        public string GetAuthor()
        {
            return this.Author;
        }

        public void SetAuthor(string author)
        {
            this.Author = author;
        }

        public string GetISBN()
        {
            return this.ISBN;
        }

        public void SetISBN(string iSBN)
        {
            this.ISBN = iSBN;
        }

        public DateOnly? GetPublicationDate()
        {
            return this.PublicationDate;
        }

        public void SetPublicationDate(DateOnly? convertedDate)
        {
            this.PublicationDate = convertedDate;
        }

        public string GetCategory()
        {
            return this.Category;
        }

        public void SetCategory(string category)
        {
            this.Category = category;
        }

        public string GetAvailabilityStatus()
        {
            return this.AvailabilityStatus;
        }

        public void SetAvailabilityStatus(string availabilityStatus)
        {
            this.AvailabilityStatus = availabilityStatus;
        }

        public static string GenerateBookId()
        {
            int id = ++_bookCounter;
            string generatedId = $"LIB00{id}";

            return generatedId;
        }
    }
}