using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Participant_Panel.DataAccess.Configurations;
using Participant_Panel.Entites.Domains;

namespace Participant_Panel.DataAccess.Contexts
{
    public class ParticipantPanelContext : IdentityDbContext
    {
        public ParticipantPanelContext(DbContextOptions<ParticipantPanelContext> options) : base(options) { }

        public DbSet<Department> Departments => this.Set<Department>();
        public DbSet<AppUser> AppUsers => this.Set<AppUser>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DepartmentConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
