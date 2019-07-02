using System;
using System.Collections.Generic;
using System.Text;
using GDC.PH.AIDE.BusinessLayer.DataLayer;
///<summary>
/// By Krizza Tolento
///<summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsSuccessRegister : BusinessObjectBase
    {
        #region "Inner Class"

        public enum clsSuccessRegisterFields
        {
            ID,
            DATE_INPUT,
            EMP_ID,
            DETAILSOFSUCCESS,
            WHOSINVOLVE,
            ADDITIONALINFORMATION,
            NICK_NAME,
            FIRST_NAME,
            DEPT_ID
        }

        #endregion

        #region "Data Members"

        //private int _id;
        private int _deptid;
        private System.Nullable<DateTime> _date_input;
        private int _emp_id;
        private string _detailsofsuccess;
        private string _whosinvolve;
        private string _nickname;
        private string _firstname;
        private string _additionalinformation;

        #endregion

        #region "Properties"
        public int SUCCESS_ID
        {
            get { return _deptid; }
            set
            {
                if (_deptid != value)
                {
                    _deptid = value;
                    PropertyHasChanged("Success_ID");
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

        public int DEPT_ID
        {
            get { return _deptid; }
            set
            {
                if (_deptid != value)
                {
                    _deptid = value;
                    PropertyHasChanged("DEPT_ID");
                }
            }
        }

        public string NICK_NAME
        {
            get { return _nickname; }
            set
            {
                if (_nickname != value)
                {
                    _nickname = value;
                    PropertyHasChanged("NICK_NAME");
                }
            }
        }

        public string FIRST_NAME
        {
            get { return _firstname; }
            set
            {
                if (_firstname != value)
                {
                    _firstname = value;
                    PropertyHasChanged("FIRST_NAME");
                }
            }
        }
        
        public System.Nullable<DateTime> DATE_INPUT
        {
            get { return _date_input; }
            set
            {
                if (_date_input != value)
                {
                    _date_input = value;
                    PropertyHasChanged("DateInput");
                }
            }
        }

        public string DETAILSOFSUCCESS
        {
            get { return _detailsofsuccess; }
            set
            {
                if (_detailsofsuccess != value)
                {
                    _detailsofsuccess = value;
                    PropertyHasChanged("DetailsOfSuccess");
                }
            }
        }

        public string WHOSINVOLVE
        {
            get { return _whosinvolve; }
            set
            {
                if (_whosinvolve != value)
                {
                    _whosinvolve = value;
                    PropertyHasChanged("WhosInvolve");
                }
            }
        }

        public string ADDITIONALINFORMATION
        {
            get { return _additionalinformation; }
            set
            {
                if (_additionalinformation != value)
                {
                    _additionalinformation = value;
                    PropertyHasChanged("AdditionalInformation");
                }
            }
        }

        #endregion

        #region "Validation"

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));

            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DETAILSOFSUCCESS", "DETAILSOFSUCCESS"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("DETAILSOFSUCCESS", "DETAILSOFSUCCESS", 160));

            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("NICK_NAME", "NICK_NAME", 160));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FIRST_NAME", "FIRST_NAME", 160));
            
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("WHOSINVOLVE", "WHOSINVOLVE"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("WHOSINVOLVE", "WHOSINVOLVE", 160));

            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ADDITIONALINFORMATION", "ADDITIONALINFORMATION"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("ADDITIONALINFORMATION", "ADDITIONALINFORMATION", 160));

            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DATE_INPUT", "DATE_INPUT"));
        }

        #endregion
    }

    public class clsNickname : BusinessObjectBase
    {
        #region "Inner Class"

        public enum clsNicknameFields
        {
            EMP_ID,
            NICK_NAME,
            FIRST_NAME,
            TO_DISPLAY
        }

        #endregion

        #region "Data Members"

        private int _EMP_ID;
        private string _NICKNAME;
        private string _firstname;
        private int _TO_DISPLAY;
        #endregion

        #region "Properties"

        public int EMP_ID
        {
            get { return _EMP_ID; }
            set
            {
                if (_EMP_ID != value)
                {
                    _EMP_ID = value;
                    PropertyHasChanged("EMP_ID");
                }
            }
        }

        public string NICK_NAME
        {
            get { return _NICKNAME; }
            set
            {
                if (_NICKNAME != value)
                {
                    _NICKNAME = value;
                    PropertyHasChanged("NICK_NAME");
                }
            }
        }

        public string FIRST_NAME
        {
            get { return _firstname; }
            set
            {
                if (_firstname != value)
                {
                    _firstname = value;
                    PropertyHasChanged("FIRST_NAME");
                }
            }
        }

        public int TO_DISPLAY
        {
            get { return _TO_DISPLAY; }
            set
            {
                if (_TO_DISPLAY != value)
                {
                    _TO_DISPLAY = value;
                    PropertyHasChanged("TO_DISPLAY");
                }
            }
        }

        #endregion

        #region "Validation"

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("NICKNAME", "NICKNAME"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("NICKNAME", "NICKNAME", 50));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FIRST_NAME", "FIRST_NAME", 160));
        }

        #endregion
    }
    public class clsNicknameFactory
    {
        private clsSuccessRegisterSql _dataObject = null;
        private clsProjectSql _dataObject2 = null;
        private clsAssetsSql _dataObject3 = null;

        public clsNicknameFactory()
        {
            _dataObject = new clsSuccessRegisterSql();
            _dataObject2 = new clsProjectSql();
            _dataObject3 = new clsAssetsSql();
        }

        public List<clsNickname> getNicknameByDeptID(string email, int toDisplay)
        {
            return _dataObject.getNicknameByDeptID(email, toDisplay);
        }
        
        /// <summary>
        /// get list of employee per project
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<clsNickname> GetEmployeePerProject(int empID, int projID)
        {
            return _dataObject2.GetEmployeePerProject(empID, projID);
        }
        
        /// <summary>
        /// get list of employee per project
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<clsNickname> GetAllManagers(int empID)
        {
            return _dataObject3.GetAllManagers(empID);
        }
    }
}
