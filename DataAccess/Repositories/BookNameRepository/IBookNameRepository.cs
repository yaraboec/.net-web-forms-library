using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories.BookNameRepository
{
    public interface IBookNameRepository
    {
        BookName GetById(Guid id);

        IEnumerable<BookName> GetAll();

        BookName Create(BookName bookName);

        BookName Delete(Guid id);

        BookName Update(BookName bookName);
    }
}
