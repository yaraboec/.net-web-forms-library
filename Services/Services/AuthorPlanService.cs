using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories.AuthorPlanRepository;

namespace Services.Services
{
    public class AuthorPlanService
    {
        private readonly IAuthorPlanRepository _iAuthorPlanRepository;

        public AuthorPlanService(IAuthorPlanRepository iAuthorPlanRepository)
        {
            _iAuthorPlanRepository = iAuthorPlanRepository;
        }

        public AuthorPlan GetById(Guid id)
        {
            return _iAuthorPlanRepository.GetById(id);
        }

        public IEnumerable<AuthorPlan> GetAll()
        {
            return _iAuthorPlanRepository.GetAll();
        }

        public AuthorPlan Create(AuthorPlan AuthorPlan)
        {
            return _iAuthorPlanRepository.Create(AuthorPlan);
        }

        public AuthorPlan Update(AuthorPlan AuthorPlan)
        {
            return _iAuthorPlanRepository.Update(AuthorPlan);
        }

        public AuthorPlan Delete(Guid id)
        {
            return _iAuthorPlanRepository.Delete(id);
        }
    }
}
