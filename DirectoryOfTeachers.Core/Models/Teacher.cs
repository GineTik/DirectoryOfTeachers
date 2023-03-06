namespace DirectoryOfTeachers.Core.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EducationalInstitution { get; set; }
        public List<TeacherCharacteristic> Characteristics { get; set; }
    }
}
