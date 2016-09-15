using System.Collections.Generic;
using ASPNETMVCSample.Models;

namespace ASPNETMVCSample.Services
{
    public interface IBookChaptersService
    {
        void Add(BookChapter chapter);
        BookChapter Find(string id);
        IEnumerable<BookChapter> GetAll();
        BookChapter Remove(string id);
        void Update(BookChapter chapter);
    }
}