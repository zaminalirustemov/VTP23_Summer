using Microsoft.EntityFrameworkCore;
using Participant_Panel.DataAccess.Contexts;
using Participant_Panel.DataAccess.Interfaces;
using System.Linq.Expressions;

namespace Participant_Panel.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ParticipantPanelContext _context;

        public Repository(ParticipantPanelContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await _context.Set<T>().SingleOrDefaultAsync(filter) : await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void Update(T entity, T unchangedEntity)
        {
            _context.Entry(unchangedEntity).CurrentValues.SetValues(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

    }
}
