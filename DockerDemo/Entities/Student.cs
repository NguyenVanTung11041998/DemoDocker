using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerDemo.Entities
{
    [Table("student")]
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        [ForeignKey(nameof(ClassRoom))]
        public int ClassId { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
    }
}
