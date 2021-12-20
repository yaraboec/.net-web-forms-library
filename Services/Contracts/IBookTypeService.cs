using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.Contracts
{
    public interface IBookTypeService
    {
        BookType GetById(Guid id);

        IEnumerable<BookType> GetAll();

        BookType Create(BookType bookType);

        BookType Delete(Guid id);

        BookType Update(BookType bookType);
    }
}
