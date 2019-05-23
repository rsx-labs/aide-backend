using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GDC.PH.AIDE.BusinessLayer.Validation
{
    /// <summary>
    /// validate using Regular expression
    /// </summary>
    class ValidateRuleRegexMatching : ValidateRuleBase
    {
        #region Data Members

        string _regexExpression = string.Empty;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyName">name of property</param>
        /// <param name="regularExpression">regular expression</param>
        public ValidateRuleRegexMatching(string propertyName, string regularExpression)
            : this(propertyName, propertyName, regularExpression)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyName">name of property</param>
        /// <param name="friendlyName">friendly name of property</param>
        /// <param name="regularExpression">regular expression</param>
        public ValidateRuleRegexMatching(string propertyName, string friendlyName, string regularExpression)
            : base(propertyName, friendlyName)
        {
            _regexExpression = regularExpression;

        }

        #endregion

        #region Properties

        /// <summary>
        /// get regular expression
        /// </summary>
        public string RegexExpression
        {
            get { return _regexExpression; }
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// validate the regular expression
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>true for valid value</returns>
        internal override bool Validate(object value)
        {

            if (value == null || !Regex.IsMatch((string)value, RegexExpression))
            {
                Description = string.Format("{0} is not valid.", FriendlyName);
                return false;
            }

            Description = string.Empty;
            return true;
        }

        #endregion
    }
}
