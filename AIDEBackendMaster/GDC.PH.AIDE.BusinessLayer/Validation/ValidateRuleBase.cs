using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer.Validation
{
    /// <summary>
    /// Comparing for validation rules
    /// </summary>
    public abstract class ValidateRuleBase
    {
        #region Data Members

        string _propertyName = string.Empty;
        string _friendlyName = string.Empty;
        string _description = string.Empty;

        #endregion

        #region Constructor

        /// <summary>
        /// Construcot 
        /// </summary>
        /// <param name="propertyName">name of property</param>
        /// <param name="friendlyName">friendly name of property</param>
        public ValidateRuleBase(string propertyName, string friendlyName)
        {
            _propertyName = propertyName;
            _friendlyName = friendlyName;
        }

        #endregion

        #region Properties

        /// <summary>
        /// get rule name
        /// </summary>
        internal string RuleName
        {
            get { return PropertyName + "_" + this.GetType().ToString(); }
        }


        /// <summary>
        /// get name of the property
        /// </summary>
        public string PropertyName
        {
            get { return _propertyName; }

        }

        /// <summary>
        /// get friendly name of property
        /// </summary>
        public string FriendlyName
        {
            get { return _friendlyName; }
        }

        /// <summary>
        /// get/set the description of the rule
        /// </summary>
        public string Description
        {
            get { return _description; }
            protected set { _description = value; }
        }


        #endregion

        #region Internal Method

        /// <summary>
        /// validate the rule
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>true for valid value</returns>
        internal abstract bool Validate(object value);

        #endregion
    }
}
