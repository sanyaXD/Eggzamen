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
    /// Interaction logic for AddAppointmentWindow.xaml
    /// </summary>
    public partial class AddAppointmentWindow : Window
    {
        public AddAppointmentWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWimdow = MainWindow.Instance;
            mainWimdow.db.Appointments.Add(new Appointment { Date = Date.SelectedDate, Time = Date.SelectedDate, PatientId = Convert.ToInt32(PatientId.Text) });
            await mainWimdow.db.SaveChangesAsync();
            mainWimdow.LoadGrid2();
        }
    }
}
