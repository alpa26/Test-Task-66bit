using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Тестовое.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<FootBallTeam> FootBallTeam { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Footballer>().HasKey(u => u.Id);
            modelBuilder.Entity<FootBallTeam>().HasKey(u => u.Id);
        }
    }



    public class Footballer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public string DateOfBirthday { get; set; }
        public string FootBallTeam { get; set; }
        public string Country { get; set; }
    }

    public class FootBallTeam
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

