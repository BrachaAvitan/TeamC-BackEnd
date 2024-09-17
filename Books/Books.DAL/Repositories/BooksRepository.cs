using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DAL.Repositories
{
    public class BooksRepository
    {
        private BooksContext _BContext;

        public BooksRepository(BooksContext bContext)
        {
            _BContext = bContext;
        }

        public async Task<List<Book>> getAllBooks()
        {
            try
            {
                return await _BContext.Books.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Book> getBookById(Guid id)
        {
            try
            {
                return await _BContext.Books.SingleOrDefaultAsync(b => b.Id == id); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            try
            {
                await _BContext.Books.AddAsync(book);
                await _BContext.SaveChangesAsync();
                return book;
            }
            catch (Exception)
            {
                throw; 
            }
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            try
            {
                _BContext.Books.Update(book);
                await _BContext.SaveChangesAsync();
                return book;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteBookAsync(Guid id)
        {
            try
            {
                Book bookToDelete = await _BContext.Books.SingleOrDefaultAsync(b => b.Id == id);
                if (bookToDelete != null)
                {
                    _BContext.Books.Remove(bookToDelete);
                    await _BContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
