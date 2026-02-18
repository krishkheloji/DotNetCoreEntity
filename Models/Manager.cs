using System.ComponentModel.DataAnnotations;

namespace DecBatch2025MVCCoreProject.Models
{
    public class Manager
    {
        [Key]
        public int mid { get; set; }
        public string mname { get; set; }

        public List<Emp> emps { get; set; }
    }
}
