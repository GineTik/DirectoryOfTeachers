using DirectoryOfTeachers.Core.DTOs.TeacherCharacteristics;

namespace DirectoryOfTeacher.BussinessLogic.Services.Interfaces
{
    public interface ITeacherCharacteristicService
    {
        Task<bool> AddCharacteristicAsync(AddTeacherCharacteristicDTO dto);
    }
}
