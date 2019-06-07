using System;
using System.Collections.Generic;
using System.Text;
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsAuditSched : BusinessObjectBase
    {

        #region InnerClass
        public enum clsAuditSchedFields
        {
            AUDIT_SCHED_ID,
            EMP_ID,
            FY_WEEK,
            PERIOD_START,
            PERIOD_END,
            DAILY,
            WEEKLY,
            MONTHLY,
            YEAR,
            FY_START,
            FY_END
        }
        #endregion

        #region Data Members

        int _auditSchedID;
        int _empID;
        int _fyWeek;
        DateTime _periodStart;
        DateTime _periodEnd;
        string _daily;
        string _weekly;
        string _monthly;
        int _year;
        DateTime _fyStart;
        DateTime _fyEnd;

        #endregion

        #region Properties
        
        public int AUDIT_SCHED_ID
        {
            get { return _auditSchedID; }
            set
            {
                if (_auditSchedID != value)
                {
                    _auditSchedID = value;
                    PropertyHasChanged("AUDIT_SCHED_ID");
                }
            }
        }

        public int EMP_ID
        {
            get { return _empID; }
            set
            {
                if (_empID != value)
                {
                    _empID = value;
                    PropertyHasChanged("EMP_ID");
                }
            }
        }

        public int FY_WEEK
        {
            get { return _fyWeek; }
            set
            {
                if (_fyWeek != value)
                {
                    _fyWeek = value;
                    PropertyHasChanged("FY_WEEK");
                }
            }
        }

        public DateTime PERIOD_START
        {
            get { return _periodStart; }
            set
            {
                if (_periodStart != value)
                {
                    _periodStart = value;
                    PropertyHasChanged("PERIOD_START");
                }
            }
        }

        public DateTime PERIOD_END
        {
            get { return _periodEnd; }
            set
            {
                if (_periodEnd != value)
                {
                    _periodEnd = value;
                    PropertyHasChanged("PERIOD_END");
                }
            }
        }

        public string DAILY
        {
            get { return _daily; }
            set
            {
                if (_daily != value)
                {
                    _daily = value;
                    PropertyHasChanged("DAILY");
                }
            }
        }

        public string WEEKLY
        {
            get { return _weekly; }
            set
            {
                if (_weekly != value)
                {
                    _weekly = value;
                    PropertyHasChanged("WEEKLY");
                }
            }
        }

        public string MONTHLY
        {
            get { return _monthly; }
            set
            {
                if (_monthly != value)
                {
                    _monthly = value;
                    PropertyHasChanged("MONTHLY");
                }
            }
        }

        public int YEAR
        {
            get { return _year; }
            set
            {
                if (_year != value)
                {
                    _year = value;
                    PropertyHasChanged("YEAR");
                }
            }
        }

        public DateTime FY_START
        {
            get { return _fyStart; }
            set
            {
                if (_fyStart != value)
                {
                    _fyStart = value;
                    PropertyHasChanged("FY_START");
                }
            }
        }

        public DateTime FY_END
        {
            get { return _fyEnd; }
            set
            {
                if (_fyEnd != value)
                {
                    _fyEnd = value;
                    PropertyHasChanged("FY_END");
                }
            }
        }
 
        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("AUDIT_SCHED_ID", "AUDIT_SCHED_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("FY_WEEK", "FY_WEEK"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PERIOD_START", "PERIOD_START"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PERIOD_END", "PERIOD_END"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DAILY", "DAILY"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("WEEKLY", "WEEKLY"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("MONTHLY", "MONTHLY"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("FY_START", "FY_START"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("FY_END", "FY_END"));
        }
        #endregion

    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////