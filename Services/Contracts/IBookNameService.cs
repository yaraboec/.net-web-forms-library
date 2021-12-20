using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.Contracts
{
    public interface IBookNameService
    {
        BookName GetById(Guid id);

        IEnumerable<BookName> GetAll();

        BookName Create(BookName bookName);

        BookName Delete(Guid id);

        BookName Update(BookName bookName);
    }
}
