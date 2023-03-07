using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Core.Models;

namespace DirectoryOfTeacher.BussinessLogic.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        public void AddTeacher(AddTeacherDTO dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetTeachersByEducationalInstitution(string educationalInstitution)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetTeachersByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
