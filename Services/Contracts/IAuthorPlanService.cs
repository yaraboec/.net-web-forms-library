using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.Contracts
{
    public interface IAuthorPlanService
    {
        AuthorPlan GetById(Guid id);

        IEnumerable<AuthorPlan> GetAll();

        AuthorPlan Create(AuthorPlan authorPlan);

        AuthorPlan Delete(Guid id);

        AuthorPlan Update(AuthorPlan authorPlan);
    }
}
