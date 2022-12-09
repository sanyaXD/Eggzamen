using Ekz.Context;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ekz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; set; }
        AddWindow addPatientWindow;
        UpdatePatientWindow updateWindow;
        AddAppointmentWindow addAppointmentWindow;
        UpdateAppointmentWindow updateAppointmentWindow;
        public ClinicContext db = new ClinicContext();
        public MainWindow()
        {
            Instance = this;
            InitializeComponent();
        }
        public void LoadGrid1()
        {
            var query =
            from patients in db.Patients
            select new
            {
                patients.PatientId,
                patients.Name,
                patients.AnimalType,
                patients.OwnerName,
                patients.BirthDate,
                patients.Diagnosis
            };
            dataGrid1.ItemsSource = query.ToList();
        }
        public void LoadGrid2()
        {
            var query =
            from appointments in db.Appointments
            select new
            {
                appointments.AppointmentId,
                appointments.Date,
                appointments.Time,
                appointments.PatientId
            };
            dataGrid2.ItemsSource = query.ToList();
        }
        private void TabItem1_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGrid1();
        }
        private void TabItem2_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGrid2();
        }

        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            addPatientWindow = Application.Current.Windows.OfType<AddWindow>().SingleOrDefault();
            if (addPatientWindow == null)
            {
                addPatientWindow = new AddWindow();
            }
            addPatientWindow.Show();
        }

        private void UpdatePatientButton_Click(object sender, RoutedEventArgs e)
        {
            var row = dataGrid1.SelectedValue;
            int id = -1;
            if (row != null)
                id = (int)row.GetType().GetProperty(nameof(Patient.PatientId)).GetValue(row, null);
            Patient patient;
            if (id == -1)
                patient = db.Patients.FirstOrDefault();
            else
                patient = db.Patients.FirstOrDefault(m => m.PatientId == id);
            updateWindow = Application.Current.Windows.OfType<UpdatePatientWindow>().SingleOrDefault();
            if (updateWindow == null)
            {
                updateWindow = new UpdatePatientWindow(patient, id);
            }
            updateWindow.patientObj = patient;
            updateWindow.Id = id;
            updateWindow.Show();
        }

        private async void DeletePatientButton_Click(object sender, RoutedEventArgs e)
        {
            var row = dataGrid1.SelectedValue;
            int id = -1;
            if (row == null)
                return;
            id = (int)row.GetType().GetProperty(nameof(Patient.PatientId)).GetValue(row, null);
            var patient = db.Patients.FirstOrDefault(m => m.PatientId == id);
            db.Patients.Remove(patient);
            await db.SaveChangesAsync();
            LoadGrid1();
        }
        
        private void AddAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            addAppointmentWindow = Application.Current.Windows.OfType<AddAppointmentWindow>().SingleOrDefault();
            if (addAppointmentWindow == null)
            {
                addAppointmentWindow = new AddAppointmentWindow();
            }
            addAppointmentWindow.Show();
        }

        private void UpdateAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            var row = dataGrid2.SelectedValue;
            int id = -1;
            if (row != null)
                id = (int)row.GetType().GetProperty(nameof(Patient.PatientId)).GetValue(row, null);
            Appointment appointment;
            if (id == -1)
                appointment = db.Appointments.FirstOrDefault();
            else
                appointment = db.Appointments.FirstOrDefault(m => m.PatientId == id);
            updateAppointmentWindow = Application.Current.Windows.OfType<UpdateAppointmentWindow>().SingleOrDefault();
            if (updateAppointmentWindow == null)
            {
                updateAppointmentWindow = new UpdateAppointmentWindow(appointment, id);
            }
            updateAppointmentWindow.appointmentObj = appointment;
            updateAppointmentWindow.Id = id;
            updateAppointmentWindow.Show();
        }

        private async void DeleteAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            var row = dataGrid2.SelectedValue;
            int id = -1;
            if (row == null)
                return;
            id = (int)row.GetType().GetProperty(nameof(Appointment.AppointmentId)).GetValue(row, null);
            var appointment = db.Appointments.FirstOrDefault(m => m.AppointmentId == id);
            db.Appointments.Remove(appointment);
            await db.SaveChangesAsync();
            LoadGrid2();
        }
    }
}
