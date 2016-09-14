using ASPNETMVCSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETMVCSample.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetBooksAsync();

        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Book book);
    }
}
