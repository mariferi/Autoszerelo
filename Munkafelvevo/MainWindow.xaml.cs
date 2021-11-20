﻿using System;
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
using Munkafelvevo.DataProviders;
using WebApi_Common.Models;

namespace Munkafelvevo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()//Munka felvevő,ügyintétő ablak
        {
            InitializeComponent();
            UpdateSheetListBox();
        }

        private void SheetListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)//Listából választás
        {
            var selectedSheet = SheetListBox.SelectedItem as ServiceSheet;

            if (selectedSheet != null)
            {
                var window = new ServiceSheetWindow(selectedSheet);
                if(window.ShowDialog()?? false)
                {
                    UpdateSheetListBox();
                }
                SheetListBox.UnselectAll();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)//Új munka gomb
        {
            var window = new ServiceSheetWindow(null);
            if(window.ShowDialog()?? false)
            {
                UpdateSheetListBox();
            }
        }

        private void UpdateSheetListBox()
        {
            var sheets = DataProvider.GetServiceSheets().ToList();
            SheetListBox.ItemsSource= sheets;
        }
    }
}
