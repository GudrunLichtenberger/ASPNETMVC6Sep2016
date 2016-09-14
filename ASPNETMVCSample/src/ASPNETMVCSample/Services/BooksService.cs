using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETMVCSample.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCSample.Services
{
    public class BooksService : IBooksService
    {
        private readonly BooksContext _context;
        public BooksService(BooksContext context)
        {
            _context = context;
        }

        public async Task AddBookAsync(Book book)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Book book)
        {
            Book b = await GetBookByIdAsync(book.BookId);
            _context.Books.Remove(b);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToArrayAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        private async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.SingleOrDefaultAsync(
              b => b.BookId == id);
        }
    }
}
