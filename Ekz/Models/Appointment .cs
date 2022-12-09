using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekz.Models
{
    [Table("Appointments")]
    public class Appointment
    {
        [Key]
        [Column("Id")]
        public int AppointmentId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }

        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
