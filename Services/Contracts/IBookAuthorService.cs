
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.Contracts
{
    public interface IBookAuthorService
    {
        BookAuthor GetById(Guid id);

        IEnumerable<BookAuthor> GetAll();

        BookAuthor Create(BookAuthor bookAuthor);

        BookAuthor Delete(Guid id);

        BookAuthor Update(BookAuthor bookAuthor);
    }
}
