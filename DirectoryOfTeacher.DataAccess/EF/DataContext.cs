using DirectoryOfTeachers.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace DirectoryOfTeacher.DataAccess.EF
{
    public class DataContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCharacteristic> TeacherCharacteristics { get; set; }
        public DbSet<TeacherCharacteristicLike> TeacherCharacteristicLikes { get; set; }
        public DbSet<TeacherCharacteristicDislike> TeacherCharacteristicDislikes { get; set; }

        public DataContext()
        { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (builder.IsConfigured == false)
            {
                builder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }
    }
}
