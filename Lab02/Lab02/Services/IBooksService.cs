using System.Collections.Generic;
using System.Threading.Tasks;
using Lab02.Models;

namespace Lab02.Services
{
    public interface IBooksService
    {
        Task<Book> AddBookAsync(Book book);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
    }
}