using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.BookNameRepository
{
    public class BookNameRepository : IBookNameRepository
    {
        private readonly DbSet<BookName> _dbSet;
        private readonly XaiBibleContext _context;
        public BookName Create(BookName bookName)
        {
            _dbSet.Add(bookName);
            _context.SaveChanges();

            return bookName;
        }

        public BookName Delete(Guid id)
        {
            BookName bookName = _dbSet.FirstOrDefault(record => record.Id == id);

            if (bookName != null)
            {
                _dbSet.Remove(bookName);
                _context.SaveChangesAsync();
            }

            return bookName;
        }

        public IEnumerable<BookName> GetAll()
        {
            return _dbSet.Include(bookType => bookType.BookType)
                .AsNoTracking()
                .ToList();
        }

        public BookName GetById(Guid id)
        {
            return _dbSet.Where(record => record.Id == id)
                .Include(bookType => bookType.BookType)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public BookName Update(BookName bookName)
        {
            BookName _bookName = _dbSet.FirstOrDefault(record => record.Id == bookName.Id);

            if (_bookName != null)
            {
                _dbSet.Update(_bookName);
                _context.SaveChangesAsync();

                return _bookName;
            }

            return null;
        }
    }
}

