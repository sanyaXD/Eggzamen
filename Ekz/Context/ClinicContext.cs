using Ekz.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekz.Context
{
    public class ClinicContext:DbContext
    {
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public ClinicContext() : base("ClinicDB")
        {

        }
    }
}
