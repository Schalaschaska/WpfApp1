using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class MyTable
    {
        public MyTable(int N, double Ki, double Di, double Ri)
        {
            this.N = N;
            this.Ki = Ki;
            this.Di = Di;
            this.Ri = Ri;
        }
        public int N { get; set; }
        public double Ki { get; set; }
        public double Di { get; set; }
        public double Ri { get; set; }
    }
}
