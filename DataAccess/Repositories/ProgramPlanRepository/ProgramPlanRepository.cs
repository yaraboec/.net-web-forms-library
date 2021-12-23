using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.ProgramPlanRepository
{
    public class ProgramPlanRepository
    {
        private readonly DbSet<ProgramPlan> _dbSet;
        private readonly XaiBibleContext _context;
        public ProgramPlan Create(ProgramPlan ProgramPlan)
        {
            _dbSet.AddAsync(ProgramPlan);
            _context.SaveChangesAsync();

            return ProgramPlan;
        }

        public ProgramPlan Delete(Guid id)
        {
            ProgramPlan ProgramPlan = _dbSet.FirstOrDefault(record => record.Id == id);

            if (ProgramPlan != null)
            {
                _dbSet.Remove(ProgramPlan);
                _context.SaveChangesAsync();
            }

            return ProgramPlan;
        }

        public IEnumerable<ProgramPlan> GetAll()
        {
            return _dbSet.Include(educationalProgram => educationalProgram.EducationalProgram)
                .Include(publicationPlan => publicationPlan.PublicationPlan)
                .AsNoTracking()
                .ToList();
        }

        public ProgramPlan GetById(Guid id)
        {
            return _dbSet.Where(record => record.Id == id)
                .Include(educationalProgram => educationalProgram.EducationalProgram)
                .Include(publicationPlan => publicationPlan.PublicationPlan)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public ProgramPlan Update(ProgramPlan ProgramPlan)
        {
            ProgramPlan _ProgramPlan = _dbSet.FirstOrDefault(record => record.Id == ProgramPlan.Id);

            if (_ProgramPlan != null)
            {
                _dbSet.Update(ProgramPlan);
                _context.SaveChanges();

                return ProgramPlan;
            }

            return null;
        }
    }
}
