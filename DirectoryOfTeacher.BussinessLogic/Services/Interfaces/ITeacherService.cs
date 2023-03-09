using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Core.Models;

namespace DirectoryOfTeacher.BussinessLogic.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetTeachersByContainsNameAsync(string name);
        Task<IEnumerable<Teacher>> GetTeachersByContainsEducationalInstitutionAsync(string educationalInstitution);
        Task<bool> AddTeacherAsync(AddTeacherDTO dto);
    }
}
