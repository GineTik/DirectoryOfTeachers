using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeacher.DataAccess.EF;
using DirectoryOfTeachers.Core.DTOs.TeacherCharacteristics;
using DirectoryOfTeachers.Core.Models;

namespace DirectoryOfTeacher.BussinessLogic.Services.Implementations
{
    public class TeacherCharacteristicService : ITeacherCharacteristicService
    {
        private readonly DataContext _context;

        public TeacherCharacteristicService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCharacteristicAsync(AddTeacherCharacteristicDTO dto)
        {
            var characteristic = new TeacherCharacteristic()
            {
                Name = dto.Name,
                TeacherId = dto.TeacherId,
            };

            var result = await _context.TeacherCharacteristics.AddAsync(characteristic);

            var isAdded = result.State == Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return isAdded;
        }
    }
}
