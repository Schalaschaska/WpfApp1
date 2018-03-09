using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Editor.xaml
    /// </summary>
    public partial class Editor : Page
    {
        public Editor()
        {
            InitializeComponent();


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Regex X = new Regex(@"^\d*(\,\d+)?$");
            if ((X.IsMatch(N_box.Text))&& (N_box.Text != String.Empty))
            {
                List<double> N_list = new List<double>();
                List<double> Ki_list = new List<double>();
                List<double> Di_lis = new List<double>();
                List<double> Ri_list = new List<double>();
                List<DataGridCell> test_list = new List<DataGridCell>();
                List<MyTable> result = new List<MyTable>(Convert.ToInt32(N_box.Text));

                for (int i = 1; i <= Convert.ToInt32(N_box.Text); i++)
                {
                    result.Add(new MyTable(i, i, i, i));
                }
                table_data.ItemsSource = result;
            }
            else
            {
                MessageBox.Show("Ошибка ввода!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool error_flag=false;
            try
            {
                table_data.SelectAllCells();
                string path = @"c:\MyTest.txt";
                table_data.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, table_data);
                table_data.UnselectAllCells();
                string res = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                File.WriteAllText(path, res, UnicodeEncoding.UTF8);
            }
            catch(System.IO.IOException)
            {
                MessageBox.Show("Нет доступа к файлу. Возможно он открыт, либо был удалён", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                error_flag = true;
            }
            if (error_flag == false)
            {
                StreamReader sr = File.OpenText("c:/MyTest.txt");
                string row;
                List<string> parsed = new List<string>();
                while ((row = sr.ReadLine()) != null)
                {
                    parsed.Add(row.Split(',')[1]);
                }
                string[] mas = parsed.ToArray<string>();
                for (int i = 0; i <= mas.Length - 1; i++)
                {
                    MessageBox.Show(mas[i]);
                }
                sr.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            

        }

    


    }
    }

