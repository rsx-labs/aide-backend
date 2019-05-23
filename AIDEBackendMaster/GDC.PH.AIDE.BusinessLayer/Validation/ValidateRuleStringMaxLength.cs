using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer.Validation
{
    /// <summary>
    /// validate the maximun length of the string
    /// </summary>
    class ValidateRuleStringMaxLength : ValidateRuleBase
    {

        #region Data member

        int _length = 0;

        #endregion

        #region Constructor

        /// <summary>
        /// Constrcutor
        /// </summary>
        /// <param name="propertyName">name of property</param>
        /// <param name="length">length</param>
        public ValidateRuleStringMaxLength(string propertyName, int length)
            : this(propertyName, propertyName, length)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyName">property name</param>
        /// <param name="friendlyName">friendly name of property</param>
        /// <param name="length">length</param>
        public ValidateRuleStringMaxLength(string propertyName, string friendlyName, int length)
            : base(propertyName, friendlyName)
        {
            _length = length;
        }

        #endregion

        #region Property

        /// <summary>
        /// get the length of the string
        /// </summary>
        public int Length
        {
            get { return _length; }
        }

        #endregion

        #region internal overrided method

        /// <summary>
        /// Validate the max length
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>true for valid value</returns>
        internal override bool Validate(object value)
        {
            string str = (string)value;

            if (!string.IsNullOrEmpty(str) && str.Length > Length)
            {
                Description = string.Format("{0} cannot be greater then {1} characters.", FriendlyName, Length.ToString());
                return false;
            }


            Description = string.Empty;
            return true;
        }

        #endregion
    }
}
