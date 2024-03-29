﻿using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeacher.DataAccess.EF;
using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Core.DTOs.TeacherCharacteristics;
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
            var result = (await _context.Teachers.AddAsync(teacher)).State == EntityState.Added;
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

        public async Task<TeacherFullDTO?> GetTeacherAsync(TeacherShortDTO dto)
        {
            return await Task.Run(() =>
            {
                var teacher = _context.Teachers
                    .Include(t => t.Characteristics)
                    .ThenInclude(c => c.Likes)
                    .FirstOrDefault(t => t.Name == dto.Name && t.EducationalInstitution == dto.EducationalInstitution);

                if (teacher == null)
                    return null;

                var characteristicsInfo = teacher.Characteristics.Select(c => new TeacherCharacteristicInfoDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    LikeCount = c.Likes?.Count ?? 0
                });

                return new TeacherFullDTO
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    EducationalInstitution = teacher.EducationalInstitution,
                    Characteristics = characteristicsInfo
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

        public async Task<bool> IsTeacherExistsAsync(int id)
        {
            return await _context.Teachers.AnyAsync(t => t.Id == id);
        }

        public async Task<bool> RemoveTeacherAsync(int id)
        {
            var result = _context.Teachers.Remove(new Teacher { Id = id }).State == EntityState.Deleted;
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
