using System.Data.Entity;
using IssueTracker.Models;

namespace IssueTracker.AppCode
{
    public class IssueTrackerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Collobrator> Collobrators { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<CollobratorQualification> CollobratorQualifications { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<State> States { get; set; }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Column> Columns { get; set; }

        public DbSet<Issue> Issues { get; set; }



        public IssueTrackerContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<IssueTrackerContext, IssueTracker.Migrations.Configuration>());
        }
    }
}