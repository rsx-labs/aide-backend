using System;
using System.Collections.Generic;
using System.Text;
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsLate : BusinessObjectBase
    {

        #region InnerClass
        public enum clsLateFields
        {
            FIRST_NAME,
            DATE_ENTRY,
            STATUS,
            MONTH,
            NUMBER_OF_LATE
        }
        #endregion

        #region Data Members

        string _fName;
        DateTime _dateEntry;
        int _status;
        string _month;
        int _noOfLate;

        #endregion

        #region Properties

        public string FIRST_NAME
        {
            get { return _fName; }
            set
            {
                if (_fName != value)
                {
                    _fName = value;
                    PropertyHasChanged("FIRST_NAME");
                }
            }
        }

        public DateTime DATE_ENTRY
        {
            get { return _dateEntry; }
            set
            {
                if (_dateEntry != value)
                {
                    _dateEntry = value;
                    PropertyHasChanged("DATE_ENTRY");
                }
            }
        }

        public int STATUS
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    PropertyHasChanged("STATUS");
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

        public int NUMBER_OF_LATE
        {
            get { return _noOfLate; }
            set
            {
                if (_noOfLate != value)
                {
                    _noOfLate = value;
                    PropertyHasChanged("NUMBER_OF_LATE");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("FIRST_NAME", "FIRST_NAME"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DATE_ENTRY", "DATE_ENTRY"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("STATUS", "STATUS"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("MONTH", "MONTH"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("NUMBER_OF_LATE", "NUMBER_OF_LATE"));
        }
        #endregion

    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////