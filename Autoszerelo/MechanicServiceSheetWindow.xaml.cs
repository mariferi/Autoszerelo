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
using WebApi_Common.Models;
using WebApi_Server.Repositories;

namespace Autoszerelo
{
    /// <summary>
    /// Interaction logic for MechanicServiceSheetWindow.xaml
    /// </summary>
    public partial class MechanicServiceSheetWindow : Window
    {
        private readonly ServiceSheet _serviceSheet;
        public MechanicServiceSheetWindow(ServiceSheet serviceSheet)
        {
            InitializeComponent();
            _serviceSheet = serviceSheet;
            //Info kiírása
            CustomerNameTextBox.Text = _serviceSheet.CustomerName;
            CarTypeTextBox.Text = _serviceSheet.CarType;
            LicensePlateTextBox.Text = _serviceSheet.LicensePlate;
            ErrorDescriptionTextBox.Text = _serviceSheet.ErrorDescription;
            DatePicker.Text = _serviceSheet.Date.ToString();
            comboBox.Text = _serviceSheet.WorkStatus;

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            ServiceSheetRepository.UpdateServiceSheet(_serviceSheet);

            DialogResult = true;
            Close();
        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ComboBoxItem)comboBox.SelectedValue;
            _serviceSheet.WorkStatus = item.Content.ToString();
        }
    }
}
