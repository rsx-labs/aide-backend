using System;
using System.Collections.Generic;
using System.Text;
/* By Jester Sanchez / Lemuela Abulencia */
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsComcellClock : BusinessObjectBase
    {
        #region InnerClass
        public enum clsComcellClockFields
        {
            CLOCK_DAY,
            CLOCK_HOUR,
            CLOCK_MINUTE,
            EMP_ID,
            MIDDAY
        }
        #endregion

        #region Data Members

        int _clock_day;
        int _clock_hour;
        int _clock_minute;
        int _emp_id;
        string _midday;

        #endregion

        #region Properties

        public int CLOCK_DAY
        {
            get { return _clock_day; }
            set
            {
                if (_clock_day != value)
                {
                    _clock_day = value;
                    PropertyHasChanged("CLOCK_DAY");
                }
            }
        }

        public int CLOCK_HOUR
        {
            get { return _clock_hour; }
            set
            {
                if (_clock_hour != value)
                {
                    _clock_hour = value;
                    PropertyHasChanged("CLOCK_HOUR");
                }
            }
        }

        public int CLOCK_MINUTE
        {
            get { return _clock_minute; }
            set
            {
                if (_clock_minute != value)
                {
                    _clock_minute = value;
                    PropertyHasChanged("CLOCK_MINUTE");
                }
            }
        }

        public int EMP_ID
        {
            get { return _emp_id; }
            set
            {
                if (_emp_id != value)
                {
                    _emp_id = value;
                    PropertyHasChanged("EMP_ID");
                }
            }
        }

        public string MIDDAY
        {
            get { return _midday; }
            set
            {
                if (_midday != value)
                {
                    _midday = value;
                    PropertyHasChanged("MIDDAY");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("CLOCK_DAY", "CLOCK_DAY"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("CLOCK_HOUR", "CLOCK_HOUR"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("CLOCK_MINUTE", "CLOCK_MINUTE"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
        }

        #endregion


    }
}
