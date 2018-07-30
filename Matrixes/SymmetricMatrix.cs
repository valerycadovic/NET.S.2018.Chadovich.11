namespace Matrixes
{
    using System.Collections.Generic;

    /// <summary>
    /// Square matrix which equals to its transposed one
    /// </summary>
    /// <typeparam name="T">Type of matrix elements</typeparam>
    /// <seealso cref="Matrixes.Matrix{T}" />
    public class SymmetricMatrix<T> : Matrix<T>
    {
        #region Private Fields
        /// <summary>
        /// The matrix layout
        /// </summary>
        private readonly T[] matrixLayout;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public SymmetricMatrix(int size) : base(size)
        {
            this.matrixLayout = new T[size * size];
        }
        #endregion

        #region Protected Overridden Methods
        /// <summary>
        /// Sets the element at [i, j] position
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="value">The value.</param>
        protected override void Set(int i, int j, T value)
        {
            this.matrixLayout[(i * this.Size) + j] = value;

            if (i != j)
            {
                this.matrixLayout[(j * this.Size) + i] = value;
            }
        }

        /// <summary>
        /// Gets the element at [i, j] position
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns>
        /// Element at the position
        /// </returns>
        protected override T Get(int i, int j)
        {
            return this.matrixLayout[(i * this.Size) + j];
        }

        /// <summary>
        /// Gets the overridden enumerator.
        /// </summary>
        /// <returns>
        /// Overridden enumerator
        /// </returns>
        protected override IEnumerator<T> GetOverridedEnumerator()
        {
            return ((IEnumerable<T>)this.matrixLayout).GetEnumerator();
        }
        #endregion
    }
}
