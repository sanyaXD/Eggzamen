using Ekz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ekz
{
    /// <summary>
    /// Interaction logic for UpdateAppointmentWindow.xaml
    /// </summary>
    public partial class UpdateAppointmentWindow : Window
    {
        public Appointment appointmentObj { get; set; }
        public int Id { get; set; }
        public UpdateAppointmentWindow(Appointment appointment, int id)
        {
            appointmentObj = appointment;
            Id = id;
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWimdow = MainWindow.Instance;
            Appointment appointment;
            appointment = new Appointment { Date = Date.SelectedDate, Time = Date.SelectedDate, PatientId = Convert.ToInt32( PatientId.Text)};
            var tempPat = mainWimdow.db.Appointments.FirstOrDefault(m => m.AppointmentId == Id);
            if (tempPat == null)
                return;
            tempPat.Date = appointment.Date;
            tempPat.Time = appointment.Time;
            tempPat.PatientId = appointment.PatientId;
            await mainWimdow.db.SaveChangesAsync();
            mainWimdow.LoadGrid2();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AppointmentId.Text = appointmentObj.PatientId.ToString();
            Date.Text = appointmentObj.Date.ToString();
            PatientId.Text = appointmentObj.PatientId.ToString();
        }
    }
}
