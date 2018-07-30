namespace Matrixes
{
    using System;
    using System.Collections.Generic;

    public class DiagonalMatrix<T> : Matrix<T>
    { 
        private int version;

        private readonly T[] mainDiagonalLayout;

        public DiagonalMatrix(int size) : base(size)
        {
            this.mainDiagonalLayout = new T[size];
        }

        protected override void Set(int i, int j, T value)
        {
            if (i != j)
            {
                throw new InvalidOperationException("you can change only diagonal elements (i == j)");
            }

            this.mainDiagonalLayout[i] = value;
        }

        protected override T Get(int i, int j)
        {
            if (i != j)
            {
                return default;
            }

            return this.mainDiagonalLayout[i];
        }

        protected override IEnumerator<T> OverridedEnumerator()
        {
            int currentVersion = version;
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    if (i != j)
                    {
                        if (this.version != currentVersion)
                        {
                            throw new InvalidOperationException();
                        }
                        yield return default;
                    }
                    else
                    {
                        if (this.version != currentVersion)
                        {
                            throw new InvalidOperationException();
                        }
                        yield return this.mainDiagonalLayout[i];
                    }
                }
            }
        }
    }
}
