using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.AuthorPlanRepository
{
    public class AuthorPlanRepository : IAuthorPlanRepository
    {
        private readonly DbSet<AuthorPlan> _dbSet;
        private readonly XaiBibleContext _context;

        public AuthorPlanRepository(XaiBibleContext context)
        {
            _dbSet = context.Set<AuthorPlan>();
            _context = context;
        }

        public AuthorPlan Create(AuthorPlan AuthorPlan)
        {
            _dbSet.Add(AuthorPlan);
            _context.SaveChanges();

            return AuthorPlan;
        }

        public AuthorPlan Delete(Guid id)
        {
            AuthorPlan AuthorPlan = _dbSet.FirstOrDefault(record => record.Id == id);

            if (AuthorPlan != null)
            {
                _dbSet.Remove(AuthorPlan);
                _context.SaveChanges();
            }

            return AuthorPlan;
        }

        public IEnumerable<AuthorPlan> GetAll()
        {
            return _dbSet.Include(bookAuthor => bookAuthor.BookAuthor )
                .Include(publicationPlan => publicationPlan.PublicationPlan)
                .AsNoTracking()
                .ToList();
        }

        public AuthorPlan GetById(Guid id)
        {
            return _dbSet.Where(record => record.Id == id)
                .Include(bookAuthor => bookAuthor.BookAuthor)
                .Include(publicationPlan => publicationPlan.PublicationPlan)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public AuthorPlan Update(AuthorPlan AuthorPlan)
        {
            AuthorPlan _AuthorPlan = _dbSet.FirstOrDefault(record => record.Id == AuthorPlan.Id);

            if (_AuthorPlan != null)
            {
                _dbSet.Update(AuthorPlan);
                _context.SaveChanges();

                return AuthorPlan;
            }

            return null;
        }
    }
}
