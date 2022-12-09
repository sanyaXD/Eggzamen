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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWimdow = MainWindow.Instance;
            mainWimdow.db.Patients.Add(new Patient { Name = PatientName.Text, AnimalType = AnimalType.Text, OwnerName = OwnerName.Text, BirthDate = BirthDate.SelectedDate,  Diagnosis =Diagnosis.Text});
            await mainWimdow.db.SaveChangesAsync();
            mainWimdow.LoadGrid1();
        }
    }
}
