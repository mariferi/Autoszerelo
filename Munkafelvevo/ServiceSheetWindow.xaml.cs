using System;
using System.Windows;
using System.Windows.Controls;
using WebApi_Common.Models;
using WebApi_Server.Repositories;


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
                _serviceSheet.WorkStatus="Felvett munka";
                _serviceSheet.Date=DatePicker.SelectedDate.Value;
                _serviceSheet.LicensePlate=LicensePlateTextBox.Text.ToUpper();

                ServiceSheetRepository.AddServiceSheet(_serviceSheet);

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
                _serviceSheet.Date = DatePicker.SelectedDate.Value;
                _serviceSheet.LicensePlate = LicensePlateTextBox.Text.ToUpper();

                ServiceSheetRepository.UpdateServiceSheet(_serviceSheet);

                DialogResult = true;
                Close();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Tényleg törölni akarja?","Question",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {

                ServiceSheetRepository.DeleteServiceSheet(_serviceSheet);

                DialogResult = true;
                Close();
            }
        }

        private bool ValidInput()
        {
            if (!IsValidCustomerName()) // ha nem ervenyes az ugyfel neve
            {
                return false;
            }
            if (!IsValidCarType())
            {
                return false;
            }
            if (!IsValidLicensePlate())
            {
                return false;
            }
            if (string.IsNullOrEmpty(ErrorDescriptionTextBox.Text))
            {
                MessageBox.Show("A hiba leírás mező nem lehet üres!");
                return false;
            }
            if (!DatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Dátum választása kötelező!");
                return false;
            }
            return true;
        }

        private bool IsValidCustomerName()
        {
            string customerName = CustomerNameTextBox.Text;
            if (string.IsNullOrEmpty(customerName))
            {
                MessageBox.Show("Az ügyfél név mező kitöltése kötelező!");
                return false;
            }
            else if(customerName.IndexOfAny("~ˇ^˘°˛`˙´˝¨¸¸\\|Ä€Í÷×äđĐ[]íłŁ$ß¤<>#&@{};>*?:_,.-\"'+!%/=()".ToCharArray()) != -1) //tartalmaz-e specialis karaktert
            {
                MessageBox.Show("Az ügyfél név mező nem tartalmazhat speciális karaktert!");
                return false;
            }

            return true;
        }

        private bool IsValidCarType()
        {
            string carType = CarTypeTextBox.Text;
            if (string.IsNullOrEmpty(carType))
            {
                MessageBox.Show("Az autó típusa mező kitöltése kötelező!");
                return false;
            }
            else if (carType.IndexOfAny("~ˇ^˘°˛`˙´˝¨¸¸\\|Ä€Í÷×äđĐ[]íłŁ$ß¤<>#&@{};>*?:_,.-\"'+!%/=()".ToCharArray()) != -1) //tartalmaz-e specialis karaktert
            {
                MessageBox.Show("Az autó típusa mező nem tartalmazhat speciális karaktert!");
                return false;
            }

            return true;
        }

        private bool IsValidLicensePlate()
        {
            string licensePlate = LicensePlateTextBox.Text;
            licensePlate = licensePlate.ToUpper();
            if (string.IsNullOrEmpty(licensePlate))
            {
                MessageBox.Show("A rendszám mező kitöltése kötelező!");
                return false;
            }
            else if (licensePlate.Length != 7)
            {
                MessageBox.Show("A rendszám mező formátuma a következő: XXX-000!");
                return false;
            }
            else if (!(Char.IsUpper(licensePlate[0])
                        && Char.IsUpper(licensePlate[1])
                        && Char.IsUpper(licensePlate[2])
                        && licensePlate[3].Equals('-')
                        && Char.IsDigit(licensePlate[4])
                        && Char.IsDigit(licensePlate[5])
                        && Char.IsDigit(licensePlate[6])))// XXX-000
            {
                MessageBox.Show("A rendszám mező formátuma a következő: XXX-000!");
                return false;
            }

            return true;
        }
    }
}
