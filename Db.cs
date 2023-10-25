using Microsoft.EntityFrameworkCore;
using UMS.Models;

namespace UMS
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options) { }

        public DbSet<Faculty> Faculties => Set<Faculty>();
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<List> List => Set<List>();
        public DbSet<Student> Students => Set<Student>();
    }
}
