using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes
{
    public class SymmetricMatrix<T> : Matrix<T>
    {
        private readonly T[] matrixLayout;

        public SymmetricMatrix(int size) : base(size)
        {
            this.matrixLayout = new T[size * size];
        }

        protected override void Set(int i, int j, T value)
        {
            this.matrixLayout[i * this.Size + j] = value;

            if (i != j)
            {
                this.matrixLayout[j * this.Size + i] = value;
            }
        }

        protected override T Get(int i, int j)
        {
            return this.matrixLayout[i * this.Size + j];
        }

        protected override IEnumerator<T> OverridedEnumerator()
        {
            return ((IEnumerable<T>)this.matrixLayout).GetEnumerator();
        }
    }
}
