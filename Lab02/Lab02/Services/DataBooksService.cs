using Lab02.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02.Services
{
    public class DataBooksService : IBooksService
    {
        private readonly BooksContext _booksContext;

        public DataBooksService(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            _booksContext.Books.Add(book);
            await _booksContext.SaveChangesAsync();
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _booksContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await _booksContext.Books.FindAsync(id);
            return book;
        }
    }
}
