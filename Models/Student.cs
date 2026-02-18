using System.ComponentModel.DataAnnotations;

namespace DecBatch2025MVCCoreProject.Models
{
    public class Student
    {
        [Key]
        public int sid { get; set; }
        public string sname { get; set; }
        public string scourse { get; set; }
        public string sprofile { get; set; }
    }
}
