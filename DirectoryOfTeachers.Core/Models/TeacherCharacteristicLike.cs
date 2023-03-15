namespace DirectoryOfTeachers.Core.Models
{
    public class TeacherCharacteristicLike
    {
        public int Id { get; set; }
        public int TeacherCharacteristicId { get; set; }
        public long UserId { get; set; }
    }
}
