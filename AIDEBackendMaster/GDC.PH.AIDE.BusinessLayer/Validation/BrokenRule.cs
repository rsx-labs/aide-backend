using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer.Validation
{
    /// <summary>
    /// Broken rules
    /// </summary>
    public class BrokenRule
    {

        #region Data Members

        string _ruleName = string.Empty;
        string _description = string.Empty;
        string _propertyName = string.Empty;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor to get rule information
        /// </summary>
        /// <param name="rule">vaidation rule</param>
        public BrokenRule(ValidateRuleBase rule)
        {
            _ruleName = rule.RuleName;
            _description = rule.Description;
            _propertyName = rule.PropertyName;

        }

        #endregion

        #region Properties

        /// <summary>
        /// get rule name
        /// </summary>
        public string RuleName
        {
            get { return _ruleName; }            
        }

        /// <summary>
        /// get broken rule description
        /// </summary>
        public string Description
        {
            get { return _description; }            
        }

        /// <summary>
        /// get Property Name
        /// </summary>
        public string PropertyName
        {
            get { return _propertyName; }            
        }

        #endregion
    }
}
