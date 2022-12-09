using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekz.Models
{
    [Table("Patients")]
    public class Patient
    {
        [Key]
        [Column("Id")]
        public int PatientId { get; set; }
        public string? Name { get; set; }
        public string? AnimalType { get; set; }
        public string? OwnerName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Diagnosis { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
