using System;

namespace SimplifyDDD.Specifications
{
    /// <summary>
    /// Represents that the decorated classes would have semantics meanings.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited=false)]
    public sealed class SemanticsAttribute : Attribute
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets the type of the semantics.
        /// </summary>
        public Semantics Type { get; set; }
        #endregion

        #region Ctor
        /// <summary>
        /// Constructs a new instance of the Semantics Attribute with parameters.
        /// </summary>
        /// <param name="type">The type of the semantics.</param>
        public SemanticsAttribute(Semantics type)
        {
            Type = type;
        }
        #endregion
    }
}
