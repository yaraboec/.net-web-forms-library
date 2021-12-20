using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories;
using Services.Contracts;

namespace Services.Services
{
    public class BookTypeService : IBookTypeService
    {
        private readonly ISqlRepository<BookType> _iSqlRepository;

        public BookTypeService(ISqlRepository<BookType> iSqlRepository)
        {
            _iSqlRepository = iSqlRepository;
        }

        public BookType GetById(Guid id)
        {
            return _iSqlRepository.GetById(id);
        }

        public IEnumerable<BookType> GetAll()
        {
            return _iSqlRepository.GetAll();
        }

        public BookType Create(BookType bookType)
        {
            return _iSqlRepository.Create(bookType);
        }

        public BookType Update(BookType bookType)
        {
            return _iSqlRepository.Update(bookType);
        }

        public BookType Delete(Guid id)
        {
            return _iSqlRepository.Delete(id);
        }
    }
}
