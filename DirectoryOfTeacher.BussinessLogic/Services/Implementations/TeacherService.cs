using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeacher.DataAccess.EF;
using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DirectoryOfTeacher.BussinessLogic.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly DataContext _context;

        public TeacherService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTeacherAsync(AddTeacherDTO dto)
        {
            var teacher = new Teacher()
            {
                Name = dto.Name,
                EducationalInstitution = dto.EducationalInstitution,
            };
            var result = _context.Teachers.Add(teacher).State == EntityState.Added;
            await _context.SaveChangesAsync(); 
            return result;
        }

        public async Task<IEnumerable<Teacher>> GetTeachersByContainsEducationalInstitutionAsync(string educationalInstitution)
        {
            return await Task.Run(() => 
                _context.Teachers.Where(t => t.EducationalInstitution.Contains(educationalInstitution)));
        }

        public async Task<IEnumerable<Teacher>> GetTeachersByContainsNameAsync(string name)
        {
            return await Task.Run(() => 
                _context.Teachers.Where(t => t.Name.Contains(name)));
        }
    }
}
