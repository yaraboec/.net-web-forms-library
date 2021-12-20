using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories.BookNameRepository;
using Services.Contracts;

namespace Services.Services
{
    public class BookNameService : IBookNameService
    {
        private readonly IBookNameRepository _iBookNameRepository;

        public BookNameService(IBookNameRepository iBookNameRepository)
        {
            _iBookNameRepository = iBookNameRepository;
        }

        public BookName GetById(Guid id)
        {
            return _iBookNameRepository.GetById(id);
        }

        public IEnumerable<BookName> GetAll()
        {
            return _iBookNameRepository.GetAll();
        }

        public BookName Create(BookName bookName)
        {
            return _iBookNameRepository.Create(bookName);
        }

        public BookName Update(BookName bookName)
        {
            return _iBookNameRepository.Update(bookName);
        }

        public BookName Delete(Guid id)
        {
            return _iBookNameRepository.Delete(id);
        }
    }
}
