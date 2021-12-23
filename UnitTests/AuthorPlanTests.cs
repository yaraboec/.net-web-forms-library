using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.AuthorPlanRepository;
using Moq;
using NUnit.Framework;
using Services.Services;

namespace UnitTests
{
    class AuthorPlanTests
    {
        private static Guid ExistingId = Guid.NewGuid();
        private static Guid NonExistingId = Guid.NewGuid();

        private readonly AuthorPlan _entity = new AuthorPlan()
        {
            Id = ExistingId
        };

        private readonly AuthorPlan _nonExistingEntity = new AuthorPlan()
        {
            Id = NonExistingId
        };

        private readonly IEnumerable<AuthorPlan> _entities = new List<AuthorPlan>()
        {
            new AuthorPlan()
            {
                Id = ExistingId
            }
        };

        private Mock<IAuthorPlanRepository> _iSqlRepository;

        private AuthorPlanService _service;

        [SetUp]
        public void Setup()
        {
            _iSqlRepository = new Mock<IAuthorPlanRepository>();

            _service = new AuthorPlanService(_iSqlRepository.Object);
        }

        [Test]
        public void GetById_ExistingId_ReturnsEntity()
        {
            _iSqlRepository.Setup(x => x.GetById(ExistingId)).Returns(_entity);

            var entity = _service.GetById(ExistingId);

            Assert.AreEqual(entity, _entity);
        }

        [Test]
        public void GetById_NonExistingId_ReturnsNull()
        {
            _iSqlRepository.Setup(x => x.GetById(ExistingId))
                .Returns((AuthorPlan)null);

            var entity = _service.GetById(NonExistingId);

            Assert.IsNull(entity);
        }

        [Test]
        public void GetAll_IEnumerableOfEntities_ReturnsIEnumerable()
        {
            _iSqlRepository.Setup(x => x.GetAll())
                .Returns(_entities.AsEnumerable());

            var entity = _service.GetAll();

            Assert.AreEqual(entity, _entities.AsEnumerable());
        }

        [Test]
        public void Create_CreateEntity_ReturnsEntity()
        {
            _iSqlRepository.Setup(x => x.Create(_entity))
               .Returns(_entity);

            var entity = _service.Create(_entity);

            Assert.AreEqual(entity, _entity);
        }

        [Test]
        public void Update_ExistingEntity_ReturnsEntity()
        {
            _iSqlRepository.Setup(x => x.Update(_entity))
                .Returns(_entity);

            var entity = _service.Update(_entity);

            Assert.AreEqual(entity, _entity);
        }

        [Test]
        public void Update_NonExistingEntity_ReturnsNull()
        {
            _iSqlRepository.Setup(x => x.Update(_nonExistingEntity))
                .Returns((AuthorPlan)null);

            var entity = _service.Update(_nonExistingEntity);

            Assert.IsNull(entity);
        }

        [Test]
        public void Delete_ExistingId_ReturnsEntity()
        {
            _iSqlRepository.Setup(x => x.Delete(ExistingId))
                .Returns(_entity);

            var entity = _service.Delete(ExistingId);

            Assert.AreEqual(entity, _entity);
        }

        [Test]
        public void Delete_NonExistingId_ReturnsNull()
        {
            _iSqlRepository.Setup(x => x.Delete(NonExistingId))
                .Returns((AuthorPlan)null);

            var entity = _service.Delete(NonExistingId);

            Assert.IsNull(entity);
        }
    }
}
