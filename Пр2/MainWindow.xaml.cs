using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
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
using LIB_8;
using LIB_MAS;

namespace Пр2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private LIB_MAS.Display _thisArray = new LIB_MAS.Display(5);

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ржевский Александр ИСП-34", "Разработчик", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Calculation_Click(object sender, RoutedEventArgs e)
        {
            multiplication.Clear();
            multiplication.Text = _thisArray.DisplaySUmmaCos();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FillArray_Click(object sender, RoutedEventArgs e)
        {
            multiplication.Clear();
            _thisArray.Fill();
            dataGrid.ItemsSource = _thisArray.ToTableData().DefaultView;
        }

        private void ClearArray_Click(object sender, RoutedEventArgs e)
        {
            _thisArray.Clear();
            multiplication.Clear();
            dataGrid.ItemsSource = _thisArray.ToTableData().DefaultView;
        }

        private void SaveArray_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Title = "Экспорт массива";

            if (saveFileDialog.ShowDialog() == true)
            {
                _thisArray.Export(saveFileDialog.FileName);
            }
            multiplication.Clear();
            dataGrid.ItemsSource = null;
        }
        private void OpenArray_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Импорт массива";

            if (openFileDialog.ShowDialog() == true)
            {
                _thisArray.Import(openFileDialog.FileName);
            }
            multiplication.Clear();
            dataGrid.ItemsSource = _thisArray.ToTableData().DefaultView;
        }
    }
}
