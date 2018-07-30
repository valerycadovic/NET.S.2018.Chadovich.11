namespace Matrixes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public abstract class Matrix<T> : IEnumerable<T>
    {
        protected Matrix(int size)
        {
            ValidateDimensionOnPositiveValue(size, nameof(size));
            this.Size = size;
        }
        
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
            }
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
