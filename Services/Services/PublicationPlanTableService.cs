using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories.PublicationPlanTableRepository;
using Services.Contracts;

namespace Services.Services
{
    public class PublicationPlanTableService : IPublicationPlanTableService
    {
        private readonly IPublicationPlanTableRepository _iPublicationPlanTableRepository;

        public PublicationPlanTableService(IPublicationPlanTableRepository iPublicationPlanTableRepository)
        {
            _iPublicationPlanTableRepository = iPublicationPlanTableRepository;
        }

        public PublicationPlanTable GetById(Guid id)
        {
            return _iPublicationPlanTableRepository.GetById(id);
        }

        public IEnumerable<PublicationPlanTable> GetAll()
        {
            return _iPublicationPlanTableRepository.GetAll();
        }

        public PublicationPlanTable Create(PublicationPlanTable publicationPlanTable)
        {
            return _iPublicationPlanTableRepository.Create(publicationPlanTable);
        }

        public PublicationPlanTable Update(PublicationPlanTable publicationPlanTable)
        {
            return _iPublicationPlanTableRepository.Update(publicationPlanTable);
        }

        public PublicationPlanTable Delete(Guid id)
        {
            return _iPublicationPlanTableRepository.Delete(id);
        }

        public Guid GetPlanTableByUserId(Guid id)
        {
            return _iPublicationPlanTableRepository.GetPlanTableByUserId(id);
        }
    }
}
