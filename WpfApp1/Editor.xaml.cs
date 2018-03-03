using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            List<double> N_list = new List<double>();
            List<double> Ki_list = new List<double>();
            List<double> Di_lis = new List<double>();
            List<double> Ri_list = new List<double>();
            List<DataGridCell> test_list = new List<DataGridCell>();
            List<MyTable> result = new List<MyTable>(Convert.ToInt32(N_box.Text));
            
            for (int i = 1; i <=Convert.ToInt32(N_box.Text); i++)
            {
                result.Add(new MyTable(i, i, i, i));
            }
            table_data.ItemsSource = result;
            table_data.SelectAllCells();
            string path = @"c:\MyTest.txt";
            table_data.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, table_data);
            table_data.UnselectAllCells();
            string res = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);
            File.WriteAllText(path, res, UnicodeEncoding.UTF8);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataTable DT = new DataTable();
            DT.Columns.Add("1");
            DT.Columns.Add("2");
            DT.Columns.Add("3");
            DT.Columns.Add("4");
            DataRow Row = DT.NewRow();
            Row[0] = "test1";
            Row[1] = "test2";
            Row[2] = "test3";
            Row[3] = "test3";
            DT.Rows.Add(Row);
            table_data.ItemsSource = DT.DefaultView;
            DataRowView drv =table_data.Items[0] as DataRowView;
            MessageBox.Show(drv[2].ToString());
        }
    }
}
