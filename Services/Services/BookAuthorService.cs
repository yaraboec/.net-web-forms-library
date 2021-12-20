using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories;
using Services.Contracts;

namespace Services.Services
{
    public class BookAuthorService : IBookAuthorService
    {
        private readonly ISqlRepository<BookAuthor> _iSqlRepository;

        public BookAuthorService(ISqlRepository<BookAuthor> iSqlRepository)
        {
            _iSqlRepository = iSqlRepository;
        }

        public BookAuthor GetById(Guid id)
        {
            return _iSqlRepository.GetById(id);
        }

        public IEnumerable<BookAuthor> GetAll()
        {
            return _iSqlRepository.GetAll();
        }

        public BookAuthor Create(BookAuthor bookAuthor)
        {
            return _iSqlRepository.Create(bookAuthor);
        }

        public BookAuthor Update(BookAuthor bookAuthor)
        {
            return _iSqlRepository.Update(bookAuthor);
        }

        public BookAuthor Delete(Guid id)
        {
            return _iSqlRepository.Delete(id);
        }
    }
}
