namespace Matrixes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using EventArgs;

    /// <inheritdoc />
    /// <summary>
    /// Matrix abstract class
    /// </summary>
    /// <typeparam name="T">Type of elements</typeparam>
    /// <seealso cref="T:System.Collections.Generic.IEnumerable`1" />
    public abstract class Matrix<T> : IEnumerable<T>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws when dimension is non-positive 
        /// </exception>
        protected Matrix(int size)
        {
            ValidateDimensionOnPositiveValue(size, nameof(size));
            this.Size = size;
        }
        #endregion

        #region Public Events
        /// <summary>
        /// Occurs when [element changed].
        /// </summary>
        public event EventHandler<MatrixEventArgs> ElementChanged = delegate { };
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int Size { get; }

        /// <summary>
        /// Gets or sets element at the specified position
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns>Element at the position</returns>
        /// <exception cref="ArgumentOutOfRangeException">indexes are out of bounds</exception>
        public T this[int i, int j]
        {
            get
            {
                this.ValidateIndexesOnBounds(i, j);
                return this.Get(i, j);
            }

            set
            {
                this.ValidateIndexesOnBounds(i, j);
                this.Set(i, j, value);
                this.OnElementChanged(i, j);
            }
        }
        #endregion

        #region IEnumerable<T> implementation
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.GetOverridedEnumerator();
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Sets the element at [i, j] position
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="value">The value.</param>
        protected abstract void Set(int i, int j, T value);

        /// <summary>
        /// Gets the element at [i, j] position
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns>Element at the position</returns>
        protected abstract T Get(int i, int j);

        /// <summary>
        /// Gets the overridden enumerator.
        /// </summary>
        /// <returns>Overridden enumerator</returns>
        protected abstract IEnumerator<T> GetOverridedEnumerator();
        #endregion

        #region Validation Methods
        /// <summary>
        /// Validates the dimension on positive value.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws when dimension is non-positive 
        /// </exception>
        private static void ValidateDimensionOnPositiveValue(int dimension, string name)
        {
            if (dimension <= 0)
            {
                throw new ArgumentOutOfRangeException($"{name} is null");
            }
        }

        /// <summary>
        /// Validates the indexes on bounds.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <exception cref="ArgumentOutOfRangeException">indexes are out of bounds</exception>
        private void ValidateIndexesOnBounds(int i, int j)
        {
            if (i >= this.Size ||
                i < 0 ||
                j >= this.Size ||
                j < 0)
            {
                throw new ArgumentOutOfRangeException("indexes are out of bounds");
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Called when [element changed].
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        private void OnElementChanged(int i, int j)
        {
            MatrixEventArgs e = new MatrixEventArgs(i, j);
            this.ElementChanged?.Invoke(this, e);
        }
        #endregion
    }
}
