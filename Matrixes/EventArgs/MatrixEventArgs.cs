namespace Matrixes.EventArgs
{
    /// <summary>
    /// Matrix event arguments
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class MatrixEventArgs : System.EventArgs
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixEventArgs"/> class.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        public MatrixEventArgs(int i, int j)
        {
            this.I = i;
            this.J = j;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the i.
        /// </summary>
        /// <value>
        /// The i.
        /// </value>
        public int I { get; }

        /// <summary>
        /// Gets the j.
        /// </summary>
        /// <value>
        /// The j.
        /// </value>
        public int J { get; }
        #endregion
    }
}
