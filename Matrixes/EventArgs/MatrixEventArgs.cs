using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes.EventArgs
{
    public class MatrixEventArgs : System.EventArgs
    {
        public MatrixEventArgs(int i, int j)
        {
            this.I = i;
            this.J = j;
        }

        public int I { get; }

        public int J { get; }
    }
}
