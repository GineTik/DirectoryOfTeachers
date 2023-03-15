namespace DirectoryOfTeachers.Core.Models
{
    public class TeacherCharacteristic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public List<TeacherCharacteristicLike> Likes { get; set; }
    }
}
