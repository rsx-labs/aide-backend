using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer.Validation
{
    /// <summary>
    /// Class to containt the list of the broken rules
    /// </summary>
    public class BrokenRulesList : List<BrokenRule>
    {
        #region Internal Methods

        /// <summary>
        /// Add broken rule into the list
        /// </summary>
        /// <param name="rule">rule</param>
        internal void Add(ValidateRuleBase rule)
        {
            Remove(rule);
            Add(new BrokenRule(rule));  
        }

        /// <summary>
        /// remove broken rule from the list
        /// </summary>
        /// <param name="rule">rule</param>
        internal void Remove(ValidateRuleBase rule)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                if (this[i].RuleName == rule.RuleName)
                {
                    RemoveAt(i);
                    break;
                }
            }

        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// get the error/broken rule description
        /// </summary>
        /// <returns>error description</returns>
        public string GetBrokenRulesDescription()
        {
            return GetBrokenRulesDescription(null);
        }

        /// <summary>
        /// get the error description of specific roperty
        /// </summary>
        /// <param name="propertyName">name fo property</param>
        /// <returns></returns>
        public string GetBrokenRulesDescription(string propertyName)
        {
            StringBuilder strToReturn = new StringBuilder();

            foreach (BrokenRule brokenRule in this)
            {
                if (string.IsNullOrEmpty(propertyName) || brokenRule.PropertyName.Equals(propertyName))
                {
                    if (strToReturn.Length > 0)
                    {
                        strToReturn.Append(Environment.NewLine);
                    }

                    // Add Broken Rule
                    strToReturn.Append(brokenRule.Description);
                }
            }

            
            return strToReturn.ToString();
        }

        /// <summary>
        /// get the error list
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return GetBrokenRulesDescription();
        }

        #endregion
    }
}
