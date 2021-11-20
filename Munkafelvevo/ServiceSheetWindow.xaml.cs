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
using Munkafelvevo.DataProviders;

namespace Munkafelvevo
{
    /// <summary>
    /// Interaction logic for ServiceSheetWindow.xaml
    /// </summary>
    public partial class ServiceSheetWindow : Window
    {
        private readonly ServiceSheet _serviceSheet;
        public ServiceSheetWindow(ServiceSheet serviceSheet)
        {
            InitializeComponent();

            if (serviceSheet != null)//létezik
            {
                _serviceSheet = serviceSheet;

                //Info kiírása
                CustomerNameTextBox.Text = _serviceSheet.CustomerName;
                CarTypeTextBox.Text = _serviceSheet.CarType;
                LicensePlateTextBox.Text = _serviceSheet.LicensePlate;
                ErrorDescriptionTextBox.Text = _serviceSheet.ErrorDescription;
                WorkStatusTextBox.Text = _serviceSheet.WorkStatus;
                DatePicker.SelectedDate = _serviceSheet.Date;

                //Gombok
                CreateButton.Visibility = Visibility.Collapsed;
                UpdateButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;

            }
            else//nem létezik
            {
                _serviceSheet = new ServiceSheet();

                //Gombok
                CreateButton.Visibility = Visibility.Visible;
                UpdateButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Collapsed;
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidInput())
            {
                _serviceSheet.CustomerName=CustomerNameTextBox.Text;
                _serviceSheet.CarType=CarTypeTextBox.Text;
                _serviceSheet.ErrorDescription=ErrorDescriptionTextBox.Text;
                _serviceSheet.WorkStatus=WorkStatusTextBox.Text;
                _serviceSheet.Date=DatePicker.SelectedDate.Value;
                _serviceSheet.LicensePlate=LicensePlateTextBox.Text;

                DataProvider.CreateSheet(_serviceSheet);

                DialogResult = true;
                Close();
            }

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidInput())
            {
                _serviceSheet.CustomerName = CustomerNameTextBox.Text;
                _serviceSheet.CarType = CarTypeTextBox.Text;
                _serviceSheet.ErrorDescription = ErrorDescriptionTextBox.Text;
                _serviceSheet.WorkStatus = WorkStatusTextBox.Text;
                _serviceSheet.Date = DatePicker.SelectedDate.Value;
                _serviceSheet.LicensePlate = LicensePlateTextBox.Text;

                DataProvider.UpdateSheet(_serviceSheet);

                DialogResult = true;
                Close();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Tényleg törölni akarja?","Question",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
              
                DataProvider.DeleteSheet(_serviceSheet);

                DialogResult = true;
                Close();
            }
        }

        private bool ValidInput()
        {
            if (string.IsNullOrEmpty(CustomerNameTextBox.Text))
            {
                MessageBox.Show("Vásárló név kell");
                return false;
            }
            if (string.IsNullOrEmpty(CarTypeTextBox.Text))
            {
                MessageBox.Show("Autó típus kell");
                return false;
            }
            if (string.IsNullOrEmpty(ErrorDescriptionTextBox.Text))
            {
                MessageBox.Show("Hiba Leírás kell");
                return false;
            }
            if (string.IsNullOrEmpty(WorkStatusTextBox.Text))
            {
                MessageBox.Show("Rendszám  kell");
                return false;
            }
            if (!DatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Dátum kell");
                return false;
            }
            return true;
        }
    }
}
