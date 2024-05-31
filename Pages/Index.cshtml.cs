using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

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
        public string GenreFilter { get; set; }

        public void OnGet(string? sortBy = null, string? sortAsc = "true", string? genre = null)
        {
            GenreFilter = genre;
            List<Book> books = new List<Book>
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

            if (!string.IsNullOrEmpty(genre))
            {
                books = books.Where(b => b.Genre.ToLower().Contains(genre.ToLower())).ToList();
            }

            if (sortBy == null || sortAsc == null)
            {
                Books = books;
                return;
            }

            bool ascending = sortAsc.ToLower() == "true";

            Books = sortBy.ToLower() switch
            {
                "title" => ascending ? books.OrderBy(b => b.Title).ToList() : books.OrderByDescending(b => b.Title).ToList(),
                "author" => ascending ? books.OrderBy(b => b.Author).ToList() : books.OrderByDescending(b => b.Author).ToList(),
                "genre" => ascending ? books.OrderBy(b => b.Genre).ToList() : books.OrderByDescending(b => b.Genre).ToList(),
                "year" => ascending ? books.OrderBy(b => b.Year).ToList() : books.OrderByDescending(b => b.Year).ToList(),
                _ => books
            };
        }

        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public int Year { get; set; }
        }
    }
}