using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.Contracts
{
    public interface IPublicationPlanService
    {
        PublicationPlan GetById(Guid id);

        IEnumerable<PublicationPlan> GetAll();

        PublicationPlan Create(PublicationPlan publicationPlan);

        PublicationPlan Delete(Guid id);

        PublicationPlan Update(PublicationPlan publicationPlan);
    }
}
