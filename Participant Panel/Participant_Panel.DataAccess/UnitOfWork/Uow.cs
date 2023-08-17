using Participant_Panel.DataAccess.Contexts;
using Participant_Panel.DataAccess.Interfaces;
using Participant_Panel.DataAccess.Repositories;

namespace Participant_Panel.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly ParticipantPanelContext _context;

        public Uow(ParticipantPanelContext context)
        {
            _context = context;
        }
        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
