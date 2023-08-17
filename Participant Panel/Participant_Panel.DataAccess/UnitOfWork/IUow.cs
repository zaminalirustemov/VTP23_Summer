using Participant_Panel.DataAccess.Interfaces;

namespace Participant_Panel.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        Task SaveChangesAsync();
    }
}
