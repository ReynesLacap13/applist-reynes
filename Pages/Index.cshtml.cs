using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        [BindProperty]
        public SearchParameters? SearchParams { get; set; }

        public void OnGet(string? keyword = "", string? searchBy = "", string? sortBy = null, string? sortAsc = "true", int pageSize = 5, int pageIndex = 1)
        {
            if (SearchParams == null)
            {
                SearchParams = new SearchParameters()
                {
                    SortBy = sortBy,
                    SortAsc = sortAsc == "true",
                    SearchBy = searchBy,
                    Keyword = keyword,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
            }

            List<Book> books = new List<Book>()
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

            if (!string.IsNullOrEmpty(SearchParams.SearchBy) && !string.IsNullOrEmpty(SearchParams.Keyword))
            {
                if (SearchParams.SearchBy.ToLower() == "title")
                {
                    books = books.Where(b => b.Title.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "author")
                {
                    books = books.Where(b => b.Author.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "genre")
                {
                    books = books.Where(b => b.Genre.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "year")
                {
                    books = books.Where(b => b.Year.ToString().Contains(SearchParams.Keyword)).ToList();
                }
            }
            else if (string.IsNullOrEmpty(SearchParams.SearchBy) && !string.IsNullOrEmpty(SearchParams.Keyword))
            {
                books = books.Where(b => b.Title.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
            }

            if (SearchParams.SortBy == null || SearchParams.SortAsc == null)
            {
                Books = books;
                goto page;
            }

            if (SearchParams.SortBy.ToLower() == "title" && SearchParams.SortAsc == true)
            {
                Books = books.OrderBy(b => b.Title).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "title" && SearchParams.SortAsc == false)
            {
                Books = books.OrderByDescending(b => b.Title).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "author" && SearchParams.SortAsc == true)
            {
                Books = books.OrderBy(b => b.Author).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "author" && SearchParams.SortAsc == false)
            {
                Books = books.OrderByDescending(b => b.Author).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "genre" && SearchParams.SortAsc == true)
            {
                Books = books.OrderBy(b => b.Genre).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "genre" && SearchParams.SortAsc == false)
            {
                Books = books.OrderByDescending(b => b.Genre).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "year" && SearchParams.SortAsc == true)
            {
                Books = books.OrderBy(b => b.Year).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "year" && SearchParams.SortAsc == false)
            {
                Books = books.OrderByDescending(b => b.Year).ToList();
            }
            else
            {
                Books = books;
            }

        page:
            // Paging
            int totalPages = (int)Math.Ceiling((double)Books.Count / SearchParams.PageSize.Value);
            int skip = (SearchParams.PageIndex.Value - 1) * SearchParams.PageSize.Value;
            Books = Books.Skip(skip).Take(SearchParams.PageSize.Value).ToList();
            SearchParams.PageCount = totalPages;
        }

        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public int Year { get; set; }
        }

        public class SearchParameters
        {
            public string? SearchBy { get; set; }
            public string? Keyword { get; set; }
            public string? SortBy { get; set; }
            public bool? SortAsc { get; set; }
            public int? PageSize { get; set; }
            public int? PageIndex { get; set; }
            public int? PageCount { get; set; }
        }
    }
}