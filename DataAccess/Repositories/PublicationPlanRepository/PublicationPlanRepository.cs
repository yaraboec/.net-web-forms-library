using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.PublicationPlanRepository
{
    public class PublicationPlanRepository : IPublicationPlanRepository
    {
        private readonly DbSet<PublicationPlan> _dbSet;
        private readonly XaiBibleContext _context;

        public PublicationPlanRepository(XaiBibleContext context)
        {
            _dbSet = context.Set<PublicationPlan>();
            _context = context;
        }

        public PublicationPlan Create(PublicationPlan publicationPlan)
        {
            _dbSet.Add(publicationPlan);
            _context.SaveChanges();

            return publicationPlan;
        }

        public PublicationPlan Delete(Guid id)
        {
            PublicationPlan publicationPlan = _dbSet.FirstOrDefault(record => record.Id == id);

            if (publicationPlan != null)
            {
                _dbSet.Remove(publicationPlan);
                _context.SaveChanges();
            }

            return publicationPlan;
        }

        public IEnumerable<PublicationPlan> GetAll()
        {
            return _dbSet.Include(bookName => bookName.BookName)
                .Include(speciality => speciality.Speciality)
                .Include(discipline => discipline.Discipline)
                .Include(language => language.Language)
                .Include(methodPublication => methodPublication.MethodPublication)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<PublicationPlan> GetAllbyPublicationPlanTableId(Guid id)
        {
            return _dbSet.Where(x => x.PublicationPlanTableId == id )
                .Include(authorPlan => authorPlan.AuthorPlans)
                .ThenInclude(u => u.BookAuthor)
                .Include(programPlan => programPlan.ProgramPlans)
                .ThenInclude(u => u.EducationalProgram)
                .Include(bookName => bookName.BookName)
                .ThenInclude(type => type.BookType)
                .Include(speciality => speciality.Speciality)
                .Include(discipline => discipline.Discipline)
                .Include(language => language.Language)
                .Include(methodPublication => methodPublication.MethodPublication)
                .AsNoTracking()
                .ToList();
        }

        public PublicationPlan GetById(Guid id)
        {
            return _dbSet.Where(record => record.Id == id)
                .Include(bookName => bookName.BookName)
                .Include(speciality => speciality.Speciality)
                .Include(discipline => discipline.Discipline)
                .Include(language => language.Language)
                .Include(methodPublication => methodPublication.MethodPublication)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public PublicationPlan Update(PublicationPlan publicationPlan)
        {
            PublicationPlan _publicationPlan = _dbSet.FirstOrDefault(record => record.Id == publicationPlan.Id);

            if (_publicationPlan != null)
            {
                _dbSet.Update(publicationPlan);
                _context.SaveChanges();

                return publicationPlan;
            }

            return null;
        }
    }
}
