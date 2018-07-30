namespace Matrixes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Matrixes.EventArgs;

    public abstract class Matrix<T> : IEnumerable<T>
    {
        protected Matrix(int size)
        {
            ValidateDimensionOnPositiveValue(size, nameof(size));
            this.Size = size;
        }

        public event EventHandler<MatrixEventArgs> ElementChanged = delegate { };

        public int Size { get; }

        public T this[int i, int j]
        {
            get
            {
                ValidateIndexesOnBounds(i, j);
                return this.Get(i, j);
            }
            set
            {
                ValidateIndexesOnBounds(i, j);
                Set(i, j, value);
                OnElementChanged(i, j);
            }
        }

        private void OnElementChanged(int i, int j)
        {
            MatrixEventArgs e = new MatrixEventArgs(i, j);
            this.ElementChanged?.Invoke(this, e);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return OverridedEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        protected abstract void Set(int i, int j, T value);

        protected abstract T Get(int i, int j);

        protected abstract IEnumerator<T> OverridedEnumerator();
        
        private static void ValidateDimensionOnPositiveValue(int dimension, string name)
        {
            if (dimension <= 0)
            {
                throw new ArgumentOutOfRangeException($"{name} is null");
            }
        }

        private void ValidateIndexesOnBounds(int i, int j)
        {
            if (i >= this.Size ||
                i < 0 ||
                j >= Size ||
                j < 0)
            {
                throw new ArgumentOutOfRangeException("indexes are out of bounds");
            }
        }
    }
}
