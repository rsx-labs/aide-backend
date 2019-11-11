using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// By Jhunell G. Barcenas / John Harvey Sanchez
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsResourcePlanner : BusinessObjectBase
    {

        #region InnerClass
        public enum clsResourcePlannerFields
        {
            EMP_ID,
            EMPLOYEE_NAME,
            from,
            to,
            STATUS,
            USEDLEAVES,
            TOTALBALANCE,
            HALFBALANCE,
            DESCR,
            IMAGE_PATH,
            DATE_ENTRY,
            HOLIDAYHOURS,
            VLHOURS,
            SLHOURS,
            START_DATE,
            END_DATE,
            DURATION,
            STATUS_CD
        }
        #endregion

        #region Data Members

        int _eMP_ID;
        string _NAME;
        DateTime _from;
        DateTime _to;
        string _status;
        double _usedLeaves;
        double _totalBalance;
        double _halfBalance;
        string _description;
        string _IMAGE_PATH;
        double _holidayHours;
        double _slHours;
        double _vlHours;
        DateTime _dateEntry;
        DateTime _startDate;
        DateTime _endDate;
        double _duration;
        int _statusCd;
        #endregion

        #region Properties

        public int EMP_ID
        {
            get { return _eMP_ID; }
            set
            {
                if (_eMP_ID != value)
                {
                    _eMP_ID = value;
                    PropertyHasChanged("EMP_ID");
                }
            }
        }

        public string EMPLOYEE_NAME
        {
            get { return _NAME; }
            set
            {
                if (_NAME != value)
                {
                    _NAME = value;
                    PropertyHasChanged("EMPLOYEE_NAME");
                }
            }
        }

        public string STATUS
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

        public double USEDLEAVES
        {
            get { return _usedLeaves ; }
            set
            {
                if (_usedLeaves != value)
                {
                    _usedLeaves = value;
                    PropertyHasChanged("USEDLEAVES");
                }
            }
        }

        public double TOTALBALANCE
        {
            get { return _totalBalance; }
            set
            {
                if (_totalBalance != value)
                {
                    _totalBalance = value;
                    PropertyHasChanged("TOTALBALANCE");
                }
            }
        }

        public double HALFBALANCE
        {
            get { return _halfBalance; }
            set
            {
                if (_halfBalance != value)
                {
                    _halfBalance = value;
                    PropertyHasChanged("HALFBALANCE");
                }
            }
        }

        public DateTime from
        {
            get { return _from; }
            set
            {
                if (_from != value)
                {
                    _from = value;
                    PropertyHasChanged("from");
                }
            }
        }

        public DateTime to
        {
            get { return _to; }
            set
            {
                if (_to != value)
                {
                    _to = value;
                    PropertyHasChanged("to");
                }
            }
        }

        public string DESCR
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    PropertyHasChanged("DESCR");
                }
            }
        }

        public string IMAGE_PATH
        {
            get { return _IMAGE_PATH; }
            set
            {
                if (_IMAGE_PATH != value)
                {
                    _IMAGE_PATH = value;
                    PropertyHasChanged("IMAGE_PATH");
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

        public double HOLIDAYHOURS
        {
            get { return _holidayHours; }
            set
            {
                if (_holidayHours != value)
                {
                    _holidayHours = value;
                    PropertyHasChanged("HOLIDAYHOURS");
                }
            }
        }

        public double VLHOURS
        {
            get { return _vlHours; }
            set
            {
                if (_vlHours != value)
                {
                    _vlHours = value;
                    PropertyHasChanged("VLHOURS");
                }
            }
        }

        public double SLHOURS
        {
            get { return _slHours; }
            set
            {
                if (_slHours != value)
                {
                    _slHours = value;
                    PropertyHasChanged("SLHOURS");
                }
            }
        }

        public DateTime START_DATE
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    PropertyHasChanged("START_DATE");
                }
            }
        }

        public DateTime END_DATE
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    PropertyHasChanged("END_DATE");
                }
            }
        }

        public double DURATION
        {
            get { return _duration; }
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    PropertyHasChanged("DURATION");
                }
            }
        }

        public int STATUS_CD
        {
            get { return _statusCd; }
            set
            {
                if (_statusCd != value)
                {
                    _statusCd = value;
                    PropertyHasChanged("STATUS_CD");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMPLOYEE_NAME", "EMPLOYEE_NAME"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("STATUS", "STATUS"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("from", "from"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("to", "to"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DESCR", "DESCR"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("IMAGE_PATH", "IMAGE_PATH"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DATE_ENTRY", "DATE_ENTRY"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("START_DATE", "START_DATE"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("END_DATE", "END_DATE"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DURATION", "DURATION"));
        }

        #endregion

    }
}
