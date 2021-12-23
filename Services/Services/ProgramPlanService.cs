using System;
using System.Collections.Generic;
using DataAccess.Entities;
using DataAccess.Repositories.ProgramPlanRepository;
using Services.Contracts;

namespace Services.Services
{
    public class ProgramPlanService : IProgramPlanService
    {
        private readonly IProgramPlanRepository _iProgramPlanRepository;

        public ProgramPlanService(IProgramPlanRepository iProgramPlanRepository)
        {
            _iProgramPlanRepository = iProgramPlanRepository;
        }

        public ProgramPlan GetById(Guid id)
        {
            return _iProgramPlanRepository.GetById(id);
        }

        public IEnumerable<ProgramPlan> GetAll()
        {
            return _iProgramPlanRepository.GetAll();
        }

        public ProgramPlan Create(ProgramPlan ProgramPlan)
        {
            return _iProgramPlanRepository.Create(ProgramPlan);
        }

        public ProgramPlan Update(ProgramPlan ProgramPlan)
        {
            return _iProgramPlanRepository.Update(ProgramPlan);
        }

        public ProgramPlan Delete(Guid id)
        {
            return _iProgramPlanRepository.Delete(id);
        }
    }
}
