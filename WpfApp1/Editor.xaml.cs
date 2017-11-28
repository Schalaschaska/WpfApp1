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
            List<MyTable> result = new List<MyTable>(Convert.ToInt32(N_box.Text));
            for (int i = 1; i <=Convert.ToInt32(N_box.Text); i++)
            {
                result.Add(new MyTable(i, 0, 0, 0));
            }
            grid.ItemsSource = result;
        }
    }
}
