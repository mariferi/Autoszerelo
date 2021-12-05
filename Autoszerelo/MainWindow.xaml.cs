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
using WebApi_Common.Models;
using WebApi_Server.Repositories;

namespace Autoszerelo
{
    public partial class MainWindow : Window
    {
        public MainWindow()//Autószerelő ablak
        {
            InitializeComponent();
            UpdateSheetListBox();
        }

        private void SheetListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)//Listából választás
        {
            var selectedSheet = SheetListBox.SelectedItem as ServiceSheet;

            if (selectedSheet != null)
            {
                var window = new MechanicServiceSheetWindow(selectedSheet);
                if (window.ShowDialog() ?? false)
                {
                    UpdateSheetListBox();
                }
                SheetListBox.UnselectAll();
            }
        }
        private void FrissitesButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateSheetListBox();
        }
        private void UpdateSheetListBox()
        {
            var sheets = ServiceSheetRepository.GetServiceSheets().ToList();
            sheets.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
            SheetListBox.ItemsSource = sheets;
        }
    }
}
