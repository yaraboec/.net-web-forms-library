using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.UserRepository;
using Moq;
using NUnit.Framework;
using Services.Contracts;
using Services.Services;

namespace UnitTests
{
    public class UserTests
    {
        private static Guid ExistingId = Guid.NewGuid();
        private static Guid NonExistingId = Guid.NewGuid();
        private static string _userName = "admin";
        private static string _nonUserName = "inkognito";

        private readonly User _entity = new User()
        {
            Id = ExistingId
        };

        private readonly User _nonExistingEntity = new User()
        {
            Id = NonExistingId
        };

        private readonly User _entityFounded = new User()
        {
            Username = _userName
        };

        private readonly IEnumerable<User> _entities = new List<User>()
        {
            new User()
            {
                Id = ExistingId
            }
        };

        private Mock<IUserRepository> _iSqlRepository;

        private IUserService _service;

        [SetUp]
        public void Setup()
        {
            _iSqlRepository = new Mock<IUserRepository>();

            _service = new UserService(_iSqlRepository.Object);
        }

        [Test]
        public void GetById_ExistingId_ReturnsEntity()
        {
            _iSqlRepository.Setup(x => x.GetByUsername(_userName)).Returns(_entityFounded);

            var entity = _service.GetByUsername(_userName);

            Assert.AreEqual(entity, _entityFounded);
        }

        [Test]
        public void GetById_NonExistingId_ReturnsNull()
        {
            _iSqlRepository.Setup(x => x.GetByUsername(_nonUserName))
                .Returns((User)null);

            var entity = _service.GetByUsername(_nonUserName);

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
                .Returns((User)null);

            var entity = _service.Update(_nonExistingEntity);

            Assert.IsNull(entity);
        }

        [Test]
        public void Delete_ExistingId_ReturnsEntity()
        {
            _iSqlRepository.Setup(x => x.Delete(_userName)).Returns(_entityFounded);

            var entity = _service.Delete(_userName);

            Assert.AreEqual(entity, _entityFounded);
        }

        [Test]
        public void Delete_NonExistingId_ReturnsNull()
        {
            _iSqlRepository.Setup(x => x.Delete(_nonUserName))
                .Returns((User)null);

            var entity = _service.Delete(_nonUserName);

            Assert.IsNull(entity);
        }
    }
}
