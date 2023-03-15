using DirectoryOfTeachers.Core.DTOs.TeacherCharacteristics;

namespace DirectoryOfTeacher.BussinessLogic.Services.Interfaces
{
    public interface ITeacherCharacteristicService
    {
        Task<bool> AddCharacteristicAsync(AddTeacherCharacteristicDTO dto);
        Task<IEnumerable<TeacherCharacteristicInfoDTO>> GetTeacherCharacteristicsAsync(int teacherId);
        Task<int> VoteByCharacteristicAsync(int characteristicId, long userId);
    }
}
