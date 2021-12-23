using System;
using System.Collections.Generic;
using DataAccess.Entities;
using DataAccess.Repositories.PublicationPlanRepository;
using Services.Contracts;

namespace Services.Services
{
    public class PublicationPlanService : IPublicationPlanService
    {
        private readonly IPublicationPlanRepository _iPublicationPlanRepository;

        public PublicationPlanService(IPublicationPlanRepository iPublicationPlanRepository)
        {
            _iPublicationPlanRepository = iPublicationPlanRepository;
        }

        public PublicationPlan GetById(Guid id)
        {
            return _iPublicationPlanRepository.GetById(id);
        }

        public IEnumerable<PublicationPlan> GetAll()
        {
            return _iPublicationPlanRepository.GetAll();
        }

        public IEnumerable<PublicationPlan> GetAllbyPublicationPlanTableId(Guid id)
        {
            return _iPublicationPlanRepository.GetAllbyPublicationPlanTableId(id);
        }

        public PublicationPlan Create(PublicationPlan publicationPlan)
        {
            return _iPublicationPlanRepository.Create(publicationPlan);
        }

        public PublicationPlan Update(PublicationPlan publicationPlan)
        {
            return _iPublicationPlanRepository.Update(publicationPlan);
        }

        public PublicationPlan Delete(Guid id)
        {
            return _iPublicationPlanRepository.Delete(id);
        }
    }
}
