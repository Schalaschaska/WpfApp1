using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;using OxyPlot.Series;

namespace WpfApp1
{
    
    public class graf
    {

        private PlotModel model;
        private void AddSeries(List<DataPoint> Buffer)
        {
            var series = new LineSeries();
            series.ItemsSource = Buffer;
            model.Series.Add(series);
        }

        public graf()
        {
            int[] mas = new int[6] { 0, 10, 20, 30, 40, 50 };
            int[] mas2 = new int[6] { 4, 13, 15, 16, 12, 12 };
            this.Title = "Example 2";
            this.Points = new List<DataPoint>();
            var series = new LineSeries();
            List<DataPoint> Buf = new List<DataPoint>();
            for (int i = 0; i <= 5; i++)
            {

                Points.Add(new DataPoint(mas[i], mas2[i]));
                series.ItemsSource = Points;


            }
          
        }
        public string Title { get; private set; }
        public IList<DataPoint> Points { get; private set; }

    }

}

