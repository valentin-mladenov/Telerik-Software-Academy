namespace MyStudentSystem.Model
{
    public class Material
    {
        public int MaterialID { get; set; }

        public string Data { get; set; }

        public int CourseID { get; set; }

        public virtual Course Course { get; set; }
    }
}