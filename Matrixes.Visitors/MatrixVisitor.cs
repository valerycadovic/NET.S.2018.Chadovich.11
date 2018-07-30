namespace Matrixes.Visitors
{
    using System;

    /// <summary>
    /// Abstract <see cref="Matrix{T}"/> visitor
    /// </summary>
    /// <typeparam name="T">Type of matrix elements</typeparam>
    public abstract class MatrixVisitor<T>
    {
        #region Public API
        /// <summary>
        /// Dispatches the visit.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <exception cref="System.ArgumentNullException">Throws when matrix is null</exception>
        public Matrix<T> DispatchVisit(Matrix<T> lhs, Matrix<T> rhs)
        {
            if (lhs == null)
            {
                throw new ArgumentNullException($"{nameof(lhs)} is null");
            }

            if (rhs == null)
            {
                throw new ArgumentNullException($"{nameof(rhs)} is null");
            }

            return this.Visit((dynamic)lhs, (dynamic)rhs);
        }
        #endregion

        #region Protected Abstract Visitors

        protected abstract SquareMatrix<T> Visit(Matrix<T> lhs, Matrix<T> rhs);

        protected abstract SymmetricMatrix<T> Visit(SymmetricMatrix<T> lhs, SymmetricMatrix<T> rhs);

        protected abstract DiagonalMatrix<T> Visit(SymmetricMatrix<T> lhs, DiagonalMatrix<T> rhs);

        protected abstract DiagonalMatrix<T> Visit(DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs);
        #endregion
    }
}
