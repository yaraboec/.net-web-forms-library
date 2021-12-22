using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.BookNameRepository
{
    public class BookNameRepository : IBookNameRepository
    {
        private readonly DbSet<BookName> _dbSet;
        private readonly XaiBibleContext _context;

        public BookNameRepository(XaiBibleContext context)
        {
            _dbSet = context.Set<BookName>();
            _context = context;
        }

        public BookName Create(BookName bookName)
        {
            _dbSet.Add(bookName);
            _context.SaveChanges();

            return bookName;
        }

        public BookName Delete(Guid id)
        {
            BookName bookName = _dbSet.AsNoTracking().FirstOrDefault(record => record.Id == id);

            if (bookName != null)
            {
                _dbSet.Remove(bookName);
                _context.SaveChanges();
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
            BookName currentBookName = _dbSet.Where(val => val.Id == bookName.Id).AsNoTracking().FirstOrDefault();

            if (currentBookName != null)
            {
                _dbSet.Update(bookName);
                _context.SaveChanges();

                return bookName;
            }

            return null;
        }
    }
}

