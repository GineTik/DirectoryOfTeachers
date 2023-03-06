namespace DirectoryOfTeachers.Core.Models
{
    public class TeacherCharacteristicDislike
    {
        public int Id { get; set; }
        public int TeacherCharacteristicId { get; set; }
        public int UserId { get; set; }
    }
}
