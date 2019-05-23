using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// By Jhunell G. Barcenas
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
            DESCR,
            IMAGE_PATH,
            DATE_ENTRY,
        }
        #endregion

        #region Data Members

        int _eMP_ID;
        string _NAME;
        DateTime _from;
        DateTime _to;
        double _status;
        string _description;
        string _IMAGE_PATH;
        DateTime _dateEntry;
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

        public double STATUS
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
        }

        #endregion

    }
}
