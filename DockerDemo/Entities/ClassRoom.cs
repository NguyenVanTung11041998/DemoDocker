using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerDemo.Entities
{
    [Table("classroom")]
    public class ClassRoom
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
