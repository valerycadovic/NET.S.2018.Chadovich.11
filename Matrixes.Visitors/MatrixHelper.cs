using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes.Visitors
{
    public static class MatrixHelper
    {
        public static Matrix<T> AddTo<T>(this Matrix<T> self, Matrix<T> matrix)
        {
            var visitor = new SummarizeMatrixVisitor<T>();
            return visitor.DispatchVisit(self, matrix);
        }

        private static void ValidateOnNull<T>(T obj) where T : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
