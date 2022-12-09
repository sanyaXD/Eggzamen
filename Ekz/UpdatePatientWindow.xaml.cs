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
    /// Interaction logic for UpdatePatientWindow.xaml
    /// </summary>
    public partial class UpdatePatientWindow : Window
    {
        public Patient patientObj { get; set; }
        public int Id { get; set; }
        public UpdatePatientWindow(Patient patient, int id)
        {
            patientObj = patient;
            Id = id;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PatientId.Text = patientObj.PatientId.ToString();
            PatientName.Text = patientObj.Name.ToString();
            AnimalType.Text = patientObj.AnimalType.ToString();
            OwnerName.Text = patientObj.OwnerName.ToString();
            BirthDate.SelectedDate = patientObj.BirthDate;
            Diagnosis.Text = patientObj.Diagnosis.ToString();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWimdow = MainWindow.Instance;
            Patient patient;
            patient = new Patient { Name = PatientName.Text, AnimalType = AnimalType.Text, OwnerName = OwnerName.Text, BirthDate = BirthDate.SelectedDate, Diagnosis = Diagnosis.Text };
            var tempPat = mainWimdow.db.Patients.FirstOrDefault(m => m.PatientId == Id);
            if (tempPat == null)
                return;
            tempPat.Name = patient.Name;
            tempPat.AnimalType = patient.AnimalType;
            tempPat.OwnerName = patient.OwnerName;
            tempPat.BirthDate = patient.BirthDate;
            tempPat.Diagnosis = patient.Diagnosis;
            await mainWimdow.db.SaveChangesAsync();
            mainWimdow.LoadGrid1();
            Close();
        }
    }
}
