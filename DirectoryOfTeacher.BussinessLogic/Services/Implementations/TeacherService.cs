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

        public async Task<IEnumerable<TeacherShortDTO>> GetSimilarTeachersAsync(TeacherShortDTO dto)
        {
            return await Task.Run(() =>
            {
                var teachers = _context.Teachers
                .Where(t => 
                    t.Name.Contains(dto.Name) &&
                    t.EducationalInstitution.Contains(dto.EducationalInstitution));

                return teachers.Select(t => new TeacherShortDTO { Name = t.Name, EducationalInstitution = t.EducationalInstitution });
            });
        }

        public async Task<TeacherFullDTO> GetTeacher(TeacherShortDTO dto)
        {
            return await Task.Run(() =>
            {
                var teacher = _context.Teachers
                    .Include(t => t.Characteristics)
                    .FirstOrDefault(t => t.Name == dto.Name && t.EducationalInstitution == dto.EducationalInstitution);

                return new TeacherFullDTO
                {
                    Name = teacher.Name,
                    EducationalInstitution = teacher.EducationalInstitution,
                    Characteristics = teacher.Characteristics
                };
            });
        }

        public async Task<IEnumerable<TeacherShortDTO>> GetTeachersByContainsEducationalInstitutionAsync(string educationalInstitution)
        {
            var teachers = _context.Teachers
                .Where(t => t.EducationalInstitution.Contains(educationalInstitution));

            return await Task.Run(() =>
                teachers.Select(t => new TeacherShortDTO { Name = t.Name, EducationalInstitution = t.EducationalInstitution } ));
        }

        public async Task<IEnumerable<TeacherShortDTO>> GetTeachersByContainsNameAsync(string name)
        {
            var teachers = _context.Teachers
                .Where(t => t.Name.Contains(name));

            return await Task.Run(() =>
                teachers.Select(t => new TeacherShortDTO { Name = t.Name, EducationalInstitution = t.EducationalInstitution }));
        }

        public async Task<bool> RemoveTeacherAsync(TeacherShortDTO dto)
        {
            var teacher = new Teacher()
            {
                Name = dto.Name,
                EducationalInstitution = dto.EducationalInstitution,
            };
            var result = _context.Teachers.Remove(teacher).State == EntityState.Deleted;
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
