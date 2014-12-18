namespace SimplifyDDD.Specifications
{
    /// <summary>
    /// Represents the type of semantics.
    /// </summary>
    public enum Semantics
    {
        #region Members
        /// <summary>
        /// ANY semantics.
        /// </summary>
        Any,
        /// <summary>
        /// NONE semantics.
        /// </summary>
        None,
        /// <summary>
        /// AND semantics.
        /// </summary>
        And,
        /// <summary>
        /// OR semantics.
        /// </summary>
        Or,
        /// <summary>
        /// NOT semantics.
        /// </summary>
        Not,
        /// <summary>
        /// AND NOT semantics.
        /// </summary>
        AndNot,
        /// <summary>
        /// ALL semantics.
        /// </summary>
        All
        #endregion
    }
}
