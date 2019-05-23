using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace GDC.PH.AIDE.BusinessLayer
{
    /// <summary>
    /// base class for all business objects
    /// </summary>
    public abstract class BusinessObjectBase : INotifyPropertyChanged
    {

        #region Data Member

        bool _disablePropertyChangeEvent = false;
        Validation.ValidationRules _validationRules = null;

        #endregion

        #region Properties

        #region Internal Properties

        /// <summary>
        /// get/set the Disable Property change event value
        /// </summary>
        internal bool DisablePropertyChangeEvent
        {
            get { return _disablePropertyChangeEvent; }
            set { _disablePropertyChangeEvent = value; }
        }

        /// <summary>
        /// get the list of validation rules
        /// </summary>
        internal Validation.ValidationRules ValidationRules
        {
            get 
            {
                if (_validationRules == null)
                {
                    _validationRules = new Validation.ValidationRules(this);

                    // Add the validation rules for this object
                    AddValidationRules(); 
                }

                return _validationRules; 
            
            }

        }

        #endregion

        #region Public Properties

        /// <summary>
        /// gets the valid status of the object
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this.ValidationRules.IsValid;  
            }
        }

        /// <summary>
        /// get the list of the broken rules
        /// </summary>
        public Validation.BrokenRulesList BrokenRulesList
        {
            get
            {
                return ValidationRules.BrokenRules;
            }
        }

        #endregion

        #endregion

        #region Virtual Methods

        /// <summary>
        /// Add validation rules
        /// </summary>
        internal virtual void AddValidationRules()
        {
            
        }

        #endregion

        #region Implement INotifyPropertyChanged

        /// <summary>
        /// override Property Change event of INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// method called when property has changed
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected virtual void PropertyHasChanged(string propertyName)
        {
            if (!DisablePropertyChangeEvent)
            {
                // call overloaded method
                PropertyHasChanged(new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Called when a property has changed
        /// </summary>
        /// <param name="e">PropertyChangedEventArgs</param>
        protected virtual void PropertyHasChanged(PropertyChangedEventArgs e)
        {
            if (!DisablePropertyChangeEvent)
            {
                ValidationRules.ValidateRules(e.PropertyName);

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, e);
                }
            }
        }

        #endregion

    }
}
