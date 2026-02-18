using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecBatch2025MVCCoreProject.Models
{
    public class Emp
    {
        [Key]
        public int eid { get; set; }
        public string ename { get; set; }
        public double esalary { get; set; }

        [ForeignKey("managers")]
        public int mid { get; set; }
        public Manager managers { get; set; }
    }
}
