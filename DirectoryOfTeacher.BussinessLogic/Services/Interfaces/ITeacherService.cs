using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Core.Models;

namespace DirectoryOfTeacher.BussinessLogic.Services.Interfaces
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetTeachersByName(string name);
        IEnumerable<Teacher> GetTeachersByEducationalInstitution(string educationalInstitution);
        void AddTeacher(AddTeacherDTO dto);
    }
}
