using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace Matrixes.Visitors
{
    public class SummarizeMatrixVisitor<T> : MatrixVisitor<T>
    {
        protected override SquareMatrix<T> Visit(Matrix<T> lhs, Matrix<T> rhs)
        {
            ValidateLengths(lhs.Size, rhs.Size);

            SquareMatrix<T> result = new SquareMatrix<T>(lhs.Size);

            Summarize(lhs, rhs, result);

            return result;
        }

        protected override SymmetricMatrix<T> Visit(SymmetricMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            ValidateLengths(lhs.Size, rhs.Size);

            SymmetricMatrix<T> result = new SymmetricMatrix<T>(lhs.Size);

            Summarize(lhs, rhs, result);

            return result;
        }

        protected override DiagonalMatrix<T> Visit(SymmetricMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            ValidateLengths(lhs.Size, rhs.Size);

            DiagonalMatrix<T> result = new DiagonalMatrix<T>(lhs.Size);

            Summarize(lhs, rhs, result);

            return result;
        }

        protected override DiagonalMatrix<T> Visit(DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            ValidateLengths(lhs.Size, rhs.Size);

            DiagonalMatrix<T> result = new DiagonalMatrix<T>(lhs.Size);

            Summarize(lhs, rhs, result);

            return result;
        }

        private void Summarize(Matrix<T> lhs, Matrix<T> rhs, Matrix<T> result)
        {
            try
            {
                for (int i = 0; i < lhs.Size; i++)
                {
                    for (int j = 0; j < lhs.Size; j++)
                    {
                        result[i, j] = (dynamic)lhs[i, j] + rhs[i, j];
                    }
                }
            }
            catch (RuntimeBinderException)
            {
                throw new InvalidOperationException($"You cannot add two {nameof(T)} elements");
            }
        }

        private void ValidateLengths(int l1, int l2)
        {
            if (l1 != l2)
            {
                throw new InvalidOperationException("matrices must have the same size");
            }
        }
    }
}
