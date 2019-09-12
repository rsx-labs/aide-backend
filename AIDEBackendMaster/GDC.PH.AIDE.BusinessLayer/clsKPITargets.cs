using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class ClsKPITargets : BusinessObjectBase
    {

        #region InnerClass
        public enum ClsKPITargetsFields
        {
            ID,
            FY_START,
            FY_END,
            KPI_REF,
            DESCRIPTION,
            SUBJECT,
            DATE_CREATED
        }
        #endregion

        #region Data Members

        int _ID;
        DateTime _FYStart;
        DateTime _FYEnd;
        string _KPIRef;
        string _description;
        string _subject;
        DateTime _dateCreated;

        #endregion

        #region Properties

        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    PropertyHasChanged("ID");
                }
            }
        }

        public DateTime FY_START
        {
            get { return _FYStart; }
            set
            {
                if (_FYStart != value)
                {
                    _FYStart = value;
                    PropertyHasChanged("FY_START");
                }
            }
        }

        public DateTime FY_END
        {
            get { return _FYEnd; }
            set
            {
                if (_FYEnd != value)
                {
                    _FYEnd = value;
                    PropertyHasChanged("FY_END");
                }
            }
        }
        public string KPI_REF
        {
            get { return _KPIRef; }
            set
            {
                if (_KPIRef != value)
                {
                    _KPIRef = value;
                    PropertyHasChanged("KPI_REF");
                }
            }
        }

        public string DESCRIPTION
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    PropertyHasChanged("DESCRIPTION");
                }
            }
        }

        public string SUBJECT
        {
            get { return _subject; }
            set
            {
                if (_subject != value)
                {
                    _subject = value;
                    PropertyHasChanged("SUBJECT");
                }
            }
        }


        public DateTime DATE_CREATED
        {
            get { return _dateCreated; }
            set
            {
                if (_dateCreated != value)
                {
                    _dateCreated = value;
                    PropertyHasChanged("DATE_CREATED");
                }
            }
        }

 
        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("FY_START", "FY_START"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("FY_END", "FY_END"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("KPI_REF", "KPI_REF"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DESCRIPTION", "DESCRIPTION"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SUBJECT", "SUBJECT"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DATE_CREATED", "DATE_CREATED"));
        }
        #endregion

    }
}
