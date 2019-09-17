using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class ClsKPISummary : BusinessObjectBase
    {

        #region InnerClass
        public enum ClsKPISummaryFields
        {
            ID,
            FY_START,
            FY_END,
            KPI_REF,
            KPI_MONTH,
            SUBJECT,
            DESCRIPTION,
            KPI_TARGET,
            KPI_ACTUAL,
            KPI_OVERALL,
            DATE_POSTED
        }
        #endregion

        #region Data Members

        int _ID;
        DateTime _FYStart;
        DateTime _FYEnd;
        string _KPIRef;
        string _subject;
        string _description;
        short _month;
        double _target;
        double _actual;
        double _overall;
        DateTime _datePosted;

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
        public short KPI_MONTH
        {
            get { return _month; }
            set
            {
                if (_month != value)
                {
                    _month = value;
                    PropertyHasChanged("KPI_MONTH");
                }
            }
        }
        public double KPI_TARGET
        {
            get { return _target; }
            set
            {
                if (_target != value)
                {
                    _target = value;
                    PropertyHasChanged("KPI_TARGET");
                }
            }
        }

        public double KPI_ACTUAL
        {
            get { return _actual; }
            set
            {
                if (_actual != value)
                {
                    _actual = value;
                    PropertyHasChanged("KPI_ACTUAL");
                }
            }
        }

        public double KPI_OVERALL
        {
            get { return _overall; }
            set
            {
                if (_overall != value)
                {
                    _overall = value;
                    PropertyHasChanged("KPI_OVERALL");
                }
            }
        }

        public DateTime DATE_POSTED
        {
            get { return _datePosted; }
            set
            {
                if (_datePosted != value)
                {
                    _datePosted = value;
                    PropertyHasChanged("DATE_POSTED");
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
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("KPI_MONTH", "KPI_MONTH"));
        }
        #endregion

    }
}
