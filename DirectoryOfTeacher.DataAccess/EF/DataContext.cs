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

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { }
    }
}
