using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes
{
    public class SquareMatrix<T> : Matrix<T>
    {
        private readonly T[] maxrixLayout;

        public SquareMatrix(int size) : base(size)
        {
            this.maxrixLayout = new T[size * size];
        }
        
        protected override void Set(int i, int j, T value)
        {
            this.maxrixLayout[i * this.Size + j] = value;
        }

        protected override T Get(int i, int j)
        {
            return this.maxrixLayout[i * this.Size + j];
        }

        protected override IEnumerator<T> OverridedEnumerator()
        {
            return ((IEnumerable<T>) this.maxrixLayout).GetEnumerator();
        }
    }
}
