using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories.PublicationPlanRepository
{
    public interface IPublicationPlanRepository
    {
        PublicationPlan GetById(Guid id);

        IEnumerable<PublicationPlan> GetAll();

        IEnumerable<PublicationPlan> GetAllbyPublicationPlanTableId(Guid id);

        PublicationPlan Create(PublicationPlan publicationPlan);

        PublicationPlan Delete(Guid id);

        PublicationPlan Update(PublicationPlan publicationPlan);
    }
}
