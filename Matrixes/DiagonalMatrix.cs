namespace Matrixes
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Square matrix which has non-default value only at the main diagonal
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Matrixes.Matrix{T}" />
    public class DiagonalMatrix<T> : Matrix<T>
    {
        #region Private Fields
        /// <summary>
        /// The version
        /// </summary>
        private int version;

        /// <summary>
        /// The main diagonal layout
        /// </summary>
        private readonly T[] mainDiagonalLayout;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public DiagonalMatrix(int size) : base(size)
        {
            this.mainDiagonalLayout = new T[size];
        }
        #endregion

        #region Protected Overridden Methods
        /// <summary>
        /// Sets the element at [i, j] position
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="InvalidOperationException">you can change only diagonal elements (i == j)</exception>
        protected override void Set(int i, int j, T value)
        {
            if (i != j)
            {
                throw new InvalidOperationException("you can change only diagonal elements (i == j)");
            }

            this.mainDiagonalLayout[i] = value;
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
            if (i != j)
            {
                return default;
            }

            return this.mainDiagonalLayout[i];
        }

        /// <summary>
        /// Gets the overridden enumerator.
        /// </summary>
        /// <returns>
        /// Overridden enumerator
        /// </returns>
        protected override IEnumerator<T> GetOverridedEnumerator()
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
        #endregion
    }
}
