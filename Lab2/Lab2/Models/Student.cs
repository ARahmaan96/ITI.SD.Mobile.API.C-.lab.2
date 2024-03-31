using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        [ForeignKey("Department")]
        public int? DeptId { get; set; }

        public Department? Department { get; set; }

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
