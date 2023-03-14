using DirectoryOfTeachers.Core.DTOs.TeacherCharacteristics;

namespace DirectoryOfTeachers.Core.DTOs.Teacher
{
    public class TeacherFullDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EducationalInstitution { get; set; }
        public IEnumerable<TeacherCharacteristicInfoDTO>? Characteristics { get; set; }
    }
}
