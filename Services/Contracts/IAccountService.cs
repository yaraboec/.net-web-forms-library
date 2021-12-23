using System;
using BC = BCrypt.Net.BCrypt;
using System.Linq;
using DataAccess.Entities;


namespace Services.Contracts
{
    public interface IAccountService
    {
        void Register(User model);
        bool Authenticate(User model);

        string GetGuidByUsername(string username);
    }
}
