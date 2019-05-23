using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer.Validation
{
    /// <summary>
    /// validate Not null rule
    /// </summary>
    class ValidateRuleNotNull : ValidateRuleBase
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyName">name of property</param>
        public ValidateRuleNotNull(string propertyName)
            : this(propertyName, propertyName)
        {
        }

        /// <summary>
        /// Construcotr
        /// </summary>
        /// <param name="propertyName">name of property</param>
        /// <param name="friendlyName">friendly name of property</param>
        public ValidateRuleNotNull(string propertyName, string friendlyName)
            : base(propertyName, friendlyName)
        {
        }

        #endregion

        #region Overloaded Methods

        /// <summary>
        /// validate not null rule
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>true for not null value</returns>
        internal override bool Validate(object value)
        {
            if (value == null)
            {
                Description = string.Format("{0} cannot be null.", FriendlyName);
                return false;
            }

            Description = string.Empty;
            return true;
        }

        #endregion

    }
}
