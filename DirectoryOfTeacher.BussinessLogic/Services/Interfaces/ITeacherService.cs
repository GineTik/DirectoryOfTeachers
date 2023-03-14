using DirectoryOfTeachers.Core.DTOs.Teacher;

namespace DirectoryOfTeacher.BussinessLogic.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherShortDTO>> GetTeachersByContainsNameAsync(string name);
        Task<IEnumerable<TeacherShortDTO>> GetTeachersByContainsEducationalInstitutionAsync(string educationalInstitution);
        Task<IEnumerable<TeacherShortDTO>> GetSimilarTeachersAsync(TeacherShortDTO dto);
        Task<TeacherFullDTO> GetTeacher(TeacherShortDTO dto);
        Task<bool> AddTeacherAsync(AddTeacherDTO dto);
        Task<bool> RemoveTeacherAsync(TeacherShortDTO dto);
    }
}
