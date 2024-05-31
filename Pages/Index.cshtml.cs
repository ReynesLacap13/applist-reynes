using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace applist_reynes.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Book> Books { get; set; }

        public void OnGet()
        {
            Books = new List<Book>
            {
                new Book {
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Genre = "Fiction",
                    Year = 1960 },

                new Book {
                    Title = "1984",
                    Author = "George Orwell",
                    Genre = "Dystopian",
                    Year = 1949 },

                new Book {
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    Genre = "Fiction",
                    Year = 1925 },

                new Book {
                    Title = "Moby Dick",
                    Author = "Herman Melville",
                    Genre = "Adventure",
                    Year = 1851 },

                new Book {
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    Genre = "Romance",
                    Year = 1813 },

                new Book {
                    Title = "War and Peace",
                    Author = "Leo Tolstoy",
                    Genre = "Historical",
                    Year = 1869 },

                new Book {
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    Genre = "Fiction",
                    Year = 1951 },

                new Book { Title = "The Lord of the Rings",
                    Author = "J.R.R. Tolkien",
                    Genre = "Fantasy",
                    Year = 1954 },

                new Book {
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    Genre = "Fantasy",
                    Year = 1937 },

                new Book {
                    Title = "Ulysses",
                    Author = "James Joyce",
                    Genre = "Modernist",
                    Year = 1922 }

            };
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
    }
}