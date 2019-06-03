using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamLibrary.Diagnostics
{
    /// <summary>Represents an "and" constraint.</summary>
    /// <typeparam name="T">The type of the argument.</typeparam>
    public class AndArgumentConstraint<T>
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="AndArgumentConstraint{T}"/> class.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="parent"/> is <see langword="null"/>.</exception>
        public AndArgumentConstraint(ArgumentConstraint<T> parent)
        {
            if (parent == null)
                throw new ArgumentNullException("parent");

            m_parent = parent;
        }
        #endregion

        /// <summary>Gets the next constraint to check.</summary>
        public ArgumentConstraint<T> And
        {
            get { return m_parent; }
        }

        #region Private Members

        private ArgumentConstraint<T> m_parent;
        #endregion
    }
}
