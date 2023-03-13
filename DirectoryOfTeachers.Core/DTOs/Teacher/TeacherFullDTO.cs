using DirectoryOfTeachers.Core.Models;

namespace DirectoryOfTeachers.Core.DTOs.Teacher
{
    public class TeacherFullDTO
    {
        public string Name { get; set; }
        public string EducationalInstitution { get; set; }
        public List<TeacherCharacteristic> Characteristics { get; set; }
    }
}
