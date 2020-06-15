using System;
using System.Collections.Generic;
using System.Text;
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsComcell : BusinessObjectBase
    {

        #region InnerClass
        public enum clsComcellFields
        {
            COMCELL_ID,
            EMP_ID,
            MONTH,
            FACILITATOR,
            MINUTES_TAKER,
            SCHEDULE,
            YEAR,
            FY_START,
            FY_END,
            FAC_NAME,
            MIN_NAME,
            WEEK,
            WEEK_START
        }
        #endregion

        #region Data Members

        int _comcellID;
        int _empID;
        string _month;
        string _facilitator;
        string _minTaker;
        string _sched;
        int _year;
        DateTime _fyStart;
        DateTime _fyEnd;
        string _facilitatorName;
        string _minTakerName;
        int _week;
        DateTime _weekStart;

        #endregion

        #region Properties

        public int COMCELL_ID
        {
            get { return _comcellID; }
            set
            {
                if (_comcellID != value)
                {
                    _comcellID = value;
                    PropertyHasChanged("COMCELL_ID");
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

        public string MONTH
        {
            get { return _month; }
            set
            {
                if (_month != value)
                {
                    _month = value;
                    PropertyHasChanged("MONTH");
                }
            }
        }

        public string FACILITATOR
        {
            get { return _facilitator; }
            set
            {
                if (_facilitator != value)
                {
                    _facilitator = value;
                    PropertyHasChanged("FACILITATOR");
                }
            }
        }

        public string MINUTES_TAKER
        {
            get { return _minTaker; }
            set
            {
                if (_minTaker != value)
                {
                    _minTaker = value;
                    PropertyHasChanged("MINUTES_TAKER");
                }
            }
        }

        public string SCHEDULE
        {
            get { return _sched; }
            set
            {
                if (_sched != value)
                {
                    _sched = value;
                    PropertyHasChanged("SCHEDULE");
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

        public string FACILITATOR_NAME
        {
            get { return _facilitatorName; }
            set
            {
                if (_facilitatorName != value)
                {
                    _facilitatorName = value;
                    PropertyHasChanged("FACILITATOR_NAME");
                }
            }
        }

        public string MINUTES_TAKER_NAME
        {
            get { return _minTakerName; }
            set
            {
                if (_minTakerName != value)
                {
                    _minTakerName = value;
                    PropertyHasChanged("MINUTES_TAKER_NAME");
                }
            }
        }

        public int WEEK
        {
            get { return _week; }
            set
            {
                if (_week != value)
                {
                    _week = value;
                    PropertyHasChanged("WEEK");
                }
            }
        }

        public DateTime WEEK_START
        {
            get { return _weekStart; }
            set
            {
                if (_weekStart != value)
                {
                    _weekStart = value;
                    PropertyHasChanged("WEEK_START");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("COMCELL_ID", "COMCELL_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("MONTH", "MONTH"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("FACILITATOR", "FACILITATOR"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("MINUTES_TAKER", "MINUTES_TAKER"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("FY_START", "FY_START"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("FY_END", "FY_END"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("WEEK", "WEEK"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("WEEK_START", "WEEK_START"));
        }
        #endregion

    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////