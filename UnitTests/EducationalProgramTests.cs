using NUnit.Framework;
using Moq;
using DataAccess.Repositories;
using DataAccess.Entities;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    public class EducationalProgramTests
    {
        private static Guid ExistingId = Guid.NewGuid();
        private static Guid NonExistingId = Guid.NewGuid();

        private readonly EducationalProgram _entity = new EducationalProgram()
        {
            Id = ExistingId
        };

        private readonly EducationalProgram _nonExistingEntity = new EducationalProgram()
        {
            Id = NonExistingId
        };

        private readonly IEnumerable<EducationalProgram> _entities = new List<EducationalProgram>()
        {
            new EducationalProgram()
            {
                Id = ExistingId
            }
        };

        private Mock<ISqlRepository<EducationalProgram>> _iSqlRepository;

        private EducationalProgramService _service;

        [SetUp]
        public void Setup()
        {
            _iSqlRepository = new Mock<ISqlRepository<EducationalProgram>>();

            _service = new EducationalProgramService(_iSqlRepository.Object);
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
                .Returns((EducationalProgram)null);

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
                .Returns((EducationalProgram)null);

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
                .Returns((EducationalProgram)null);

            var entity = _service.Delete(NonExistingId);

            Assert.IsNull(entity);
        }
    }
}
