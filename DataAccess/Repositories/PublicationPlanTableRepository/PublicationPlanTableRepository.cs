using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.PublicationPlanTableRepository
{
    public class PublicationPlanTableRepository : IPublicationPlanTableRepository
    {
        private readonly DbSet<PublicationPlanTable> _dbSet;
        private readonly XaiBibleContext _context;

        public PublicationPlanTableRepository(XaiBibleContext context)
        {
            _dbSet = context.Set<PublicationPlanTable>();
            _context = context;
        }

        public PublicationPlanTable Create(PublicationPlanTable publicationPlanTable)
        {
            _dbSet.AddAsync(publicationPlanTable);
            _context.SaveChangesAsync();

            return publicationPlanTable;
        }

        public PublicationPlanTable Delete(Guid id)
        {
            PublicationPlanTable publicationPlanTable = _dbSet.FirstOrDefault(record => record.Id == id);

            if (publicationPlanTable != null)
            {
                _dbSet.Remove(publicationPlanTable);
                _context.SaveChangesAsync();
            }

            return publicationPlanTable;
        }

        public IEnumerable<PublicationPlanTable> GetAll()
        {
            return _dbSet.Include(user => user.User)
                .AsNoTracking()
                .ToList();
        }

        public PublicationPlanTable GetById(Guid id)
        {
            return _dbSet.Where(record => record.Id == id).Include(user => user.User)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public PublicationPlanTable Update(PublicationPlanTable publicationPlanTable)
        {
            PublicationPlanTable _publicationPlanTable = _dbSet.FirstOrDefault(record => record.Id == publicationPlanTable.Id);

            if (_publicationPlanTable != null)
            {
                _dbSet.Update(_publicationPlanTable);
                _context.SaveChangesAsync();

                return _publicationPlanTable;
            }

            return null;
        }
    }
}
