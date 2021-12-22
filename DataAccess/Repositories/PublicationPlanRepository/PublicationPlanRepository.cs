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
        public PublicationPlan Create(PublicationPlan publicationPlan)
        {
            _dbSet.AddAsync(publicationPlan);
            _context.SaveChangesAsync();

            return publicationPlan;
        }

        public PublicationPlan Delete(Guid id)
        {
            PublicationPlan publicationPlan = _dbSet.FirstOrDefault(record => record.Id == id);

            if (publicationPlan != null)
            {
                _dbSet.Remove(publicationPlan);
                _context.SaveChangesAsync();
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
                .Include(publicationPlanTable => publicationPlanTable.PublicationPlanTable)
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
                .Include(publicationPlanTable => publicationPlanTable.PublicationPlanTable)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public PublicationPlan Update(PublicationPlan publicationPlan)
        {
            PublicationPlan _publicationPlan = _dbSet.FirstOrDefault(record => record.Id == publicationPlan.Id);

            if (_publicationPlan != null)
            {
                _dbSet.Update(_publicationPlan);
                _context.SaveChangesAsync();

                return _publicationPlan;
            }

            return null;
        }
    }
}
