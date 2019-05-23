using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer.Validation
{
    /// <summary>
    /// Validate the required value
    /// </summary>
    class ValidateRuleStringRequired : ValidateRuleBase
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyName">name of property</param>
        public ValidateRuleStringRequired(string propertyName)
            : this(propertyName, propertyName)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyName">name of property</param>
        /// <param name="friendlyName">friendly name of the property</param>
        public ValidateRuleStringRequired(string propertyName, string friendlyName)
            : base(propertyName, friendlyName)
        {
        }

        #endregion

        #region internal Methods

        /// <summary>
        /// validate the required value
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>true for valid value</returns>
        internal override bool Validate(object value)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                Description = string.Format("{0} is required.", FriendlyName);
                return false;
            }

            Description = string.Empty;
            return true;
        }

        #endregion
    }
}
