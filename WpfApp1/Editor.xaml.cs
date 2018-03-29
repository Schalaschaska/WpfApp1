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
                double? zz = null;
                List<double> N_list = new List<double>();
                List<double> Ki_list = new List<double>();
                List<double> Di_lis = new List<double>();
                List<double> Ri_list = new List<double>();
                List<DataGridCell> test_list = new List<DataGridCell>();
                List<MyTable> result = new List<MyTable>(Convert.ToInt32(N_box.Text));

                for (int i = 1; i <= Convert.ToInt32(N_box.Text); i++)
                {
                    result.Add(new MyTable(i, 0, 0, 0));
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
                catch(System.UnauthorizedAccessException)
                {
                    MessageBox.Show("Нет доступа к файлу. Возможно он доступен только для чтения, либо имеет атрибут 'скрытый'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                    error_flag = true;

                }
            }
            catch(System.IO.IOException)
            {
                MessageBox.Show("Нет доступа к файлу. Возможно он открыт, либо удалён", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                error_flag = true;
            }
            if (error_flag == false)
            {
                StreamReader sr = File.OpenText("c:/MyTest.txt");
                string row;
                List<string> parsed_N = new List<string>();
                List<string> parsed_KI = new List<string>();
                List<string> parsed_DI = new List<string>();
                List<string> parsed_RI = new List<string>();
                while ((row = sr.ReadLine()) != null)
                {
                    parsed_N.Add(row.Split(',')[0]);
                }
                string[] mas_N= parsed_N.ToArray<string>();

                string row_1;
                while ((row_1 = sr.ReadLine()) != null)
                {
                    parsed_KI.Add(row_1.Split(',')[1]);
                }
                string[] mas_KI = parsed_KI.ToArray<string>();

                string row_2;
                while ((row_2 = sr.ReadLine()) != null)
                {
                    parsed_DI.Add(row_2.Split(',')[2]);
                }
                string[] mas_DI = parsed_DI.ToArray<string>();

                string row_3;
                while ((row_3 = sr.ReadLine()) != null)
                {
                    parsed_RI.Add(row_3.Split(',')[3]);
                }
                string[] mas_RI = parsed_RI.ToArray<string>();
                

                sr.Close();
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int count_row = table_data.Items.Count;
            MessageBox.Show(Convert.ToString(count_row));
            
        }

    }
    }

