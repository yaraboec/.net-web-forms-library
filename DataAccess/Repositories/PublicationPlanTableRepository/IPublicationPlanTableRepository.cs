using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories.PublicationPlanTableRepository
{
    public interface IPublicationPlanTableRepository
    {
        PublicationPlanTable GetById(Guid id);

        IEnumerable<PublicationPlanTable> GetAll();

        PublicationPlanTable Create(PublicationPlanTable publicationPlanTable);

        PublicationPlanTable Delete(Guid id);

        PublicationPlanTable Update(PublicationPlanTable publicationPlanTable);
    }
}
