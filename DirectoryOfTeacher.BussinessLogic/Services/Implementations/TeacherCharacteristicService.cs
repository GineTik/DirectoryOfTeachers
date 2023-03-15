using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeacher.DataAccess.EF;
using DirectoryOfTeachers.Core.DTOs.TeacherCharacteristics;
using DirectoryOfTeachers.Core.Models;
using Microsoft.EntityFrameworkCore;

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

            var result = (await _context.TeacherCharacteristics.AddAsync(characteristic)).State == Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<TeacherCharacteristicInfoDTO>> GetTeacherCharacteristicsAsync(int teacherId)
        {
            return await Task.Run(() => _context.TeacherCharacteristics
                .Where(c => c.TeacherId == teacherId)
                .Select(c => new TeacherCharacteristicInfoDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    LikeCount = c.Likes.Count(),
                }));
        }

        public async Task<int> VoteByCharacteristicAsync(int characteristicId, long userId)
        {
            var characteristic = await _context.TeacherCharacteristics.Include(c => c.Likes).FirstOrDefaultAsync(c => c.Id == characteristicId);

            ArgumentNullException.ThrowIfNull(characteristic);
            
            var like = characteristic.Likes.FirstOrDefault(l => l.UserId == userId);
            var likeCount = characteristic.Likes.Count();

            if (like == null)
            {
                var newLike = new TeacherCharacteristicLike()
                {
                    TeacherCharacteristicId = characteristicId,
                    UserId = userId
                };
                await _context.TeacherCharacteristicLikes.AddAsync(newLike);
                likeCount++;
            }
            else
            {
                _context.TeacherCharacteristicLikes.Remove(like);
                likeCount--;
            }

            await _context.SaveChangesAsync();
            return likeCount;
        }
    }
}
