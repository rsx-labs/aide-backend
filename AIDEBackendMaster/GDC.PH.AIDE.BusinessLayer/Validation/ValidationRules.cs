using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace GDC.PH.AIDE.BusinessLayer.Validation
{
    /// <summary>
    /// Class to contain the validation rules of the object
    /// </summary>
    class ValidationRules
    {

        #region Data Members

        BrokenRulesList _brokenRulesList = null;
        Dictionary<string, List<ValidateRuleBase>> _validationRulesList = null;
        object _parentObject = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to get the parent object
        /// </summary>
        /// <param name="parentObject">parent object whose property will be validate</param>
        public ValidationRules(object parentObject)
        {
            _parentObject = parentObject;
        }

        #endregion

        #region Properties

        /// <summary>
        /// gets the validation rules list
        /// </summary>
        internal Dictionary<string, List<ValidateRuleBase>> ValidationRulesList
        {
            get
            {
                if (_validationRulesList == null)
                    _validationRulesList = new Dictionary<string, List<ValidateRuleBase>>();
                return _validationRulesList;
            }

        }

        /// <summary>
        /// Broken rules list
        /// </summary>
        internal BrokenRulesList BrokenRules
        {
            get
            {
                if (_brokenRulesList == null)
                    _brokenRulesList = new BrokenRulesList();
                return _brokenRulesList;
            }


        }

        /// <summary>
        /// Is valid
        /// </summary>
        internal bool IsValid
        {
            get
            {
                ValidateRules();
                return (BrokenRules.Count == 0);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method to get the list of rules of the property
        /// </summary>
        /// <param name="propertyName">name of the property</param>
        /// <returns>List</returns>
        private List<ValidateRuleBase> GetPropertyRules(string propertyName)
        {
            List<ValidateRuleBase> list = null;

            // Check Rules in Dictionary
            if (ValidationRulesList.ContainsKey(propertyName))
            {
                list = ValidationRulesList[propertyName];
            }
            // if not exist then add new list
            else
            {
                list = new List<ValidateRuleBase>();
                ValidationRulesList.Add(propertyName, list);
            }

            return list;
        }

        /// <summary>
        /// Validate the rules list
        /// </summary>
        /// <param name="list">list of rules</param>
        private void ValidateRulesList(List<ValidateRuleBase> list)
        {
            foreach (ValidateRuleBase rule in list)
            {
                PropertyInfo info = _parentObject.GetType().GetProperty(rule.PropertyName);
                if (info != null)
                {
                    object value = info.GetValue(_parentObject, null);
                    if (rule.Validate(value))
                    {
                        BrokenRules.Remove(rule);
                    }
                    else
                    {
                        BrokenRules.Add(rule);
                    }
                }
                else
                {
                    throw new ArgumentException(string.Format("Property \"{0}\" not found on object \"{1}\"", rule.PropertyName, _parentObject.GetType().ToString()));
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add new rule to list
        /// </summary>
        /// <param name="validationRule">validate rule</param>
        public void AddRules(ValidateRuleBase validationRule)
        {
            List<ValidateRuleBase> ruleList = GetPropertyRules(validationRule.PropertyName);
            ruleList.Add(validationRule);
        }

        /// <summary>
        /// Validate rule using property name
        /// </summary>
        /// <param name="propertyName">name of the property</param>
        public void ValidateRules(string propertyName)
        {
            if (ValidationRulesList.ContainsKey(propertyName))
            {
                List<ValidateRuleBase> rules = ValidationRulesList[propertyName];

                if (rules != null)
                {
                    ValidateRulesList(rules);
                }

            }

        }

        /// <summary>
        /// Validate the rules
        /// </summary>
        public void ValidateRules()
        {
            foreach (string key in ValidationRulesList.Keys)
            {
                ValidateRules(key);
            }
        }

        #endregion

    }
}
