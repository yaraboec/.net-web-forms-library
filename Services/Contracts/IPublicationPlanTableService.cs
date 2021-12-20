using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.Contracts
{
    public interface IPublicationPlanTableService
    {
        PublicationPlanTable GetById(Guid id);

        IEnumerable<PublicationPlanTable> GetAll();

        PublicationPlanTable Create(PublicationPlanTable publicationPlanTable);

        PublicationPlanTable Delete(Guid id);

        PublicationPlanTable Update(PublicationPlanTable publicationPlanTable);
    }
}
