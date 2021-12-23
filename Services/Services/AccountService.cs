using System;
using BC = BCrypt.Net.BCrypt;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories.UserRepository;
using Services.Contracts;

namespace Services.Services
{
    public class AccountService : IAccountService
    {
        XaiBibleContext _context;
        IUserRepository _repository;
        IUserService _service;

        public AccountService()
        {
            _context = new XaiBibleContext();
            _repository = new UserRepository(_context);
            _service = new UserService(_repository);
        }

        public void Register(User model)
        {
            model.Password = BC.HashPassword(model.Password);

            _service.Create(model);
        }

        public bool Authenticate(User model)
        {
            var account = _service.GetByUsername(model.Username);

            return account != null && BC.Verify(model.Password, account.Password);
        }

        public Guid GetGuidByUsername(string username)
        {
            var account = _service.GetByUsername(username);

            return account.Id;
        }
    }
}
