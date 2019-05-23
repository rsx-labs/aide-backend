using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///<summary>
/// By Jhunell G. Barcenas
///<summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsSkills : BusinessObjectBase
    {

        #region InnerClass
        public enum clsSkillsFields
        {
            EMP_ID,
            SKILL_ID,
            PROF_LVL,
            LAST_REVIEWED,
            DESCR,
            IMAGE_PATH,
            EMPLOYEE_NAME
        }
        #endregion

        #region Data Members

        int _EMP_ID;
        int _SKILL_ID;
        int _PROF_LVL;
        string _IMAGE_PATH;
        DateTime _LAST_REVIEWED;
        string _DESCR;
        string _NAME;

        #endregion

        #region Properties

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

        public int SKILL_ID
        {
            get { return _SKILL_ID; }
            set
            {
                if (_SKILL_ID != value)
                {
                    _SKILL_ID = value;
                    PropertyHasChanged("SKILL_ID");
                }
            }
        }

        public int PROF_LVL
        {
            get { return _PROF_LVL; }
            set
            {
                if (_PROF_LVL != value)
                {
                    _PROF_LVL = value;
                    PropertyHasChanged("PROF_LVL");
                }
            }
        }

        public DateTime LAST_REVIEWED
        {
            get { return _LAST_REVIEWED; }
            set
            {
                if (_LAST_REVIEWED != value)
                {
                    _LAST_REVIEWED = value;
                    PropertyHasChanged("LAST_REVIEWED");
                }
            }
        }

        public string DESCR
        {
            get { return _DESCR; }
            set
            {
                if (_DESCR != value)
                {
                    _DESCR = value;
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

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SKILL_ID", "SKILL_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PROF_LVL", "PROF_LVL"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LAST_REVIEWED", "LAST_REVIEWED"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DESCR", "DESCR"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMPLOYEE_NAME", "EMPLOYEE_NAME"));
        }
        #endregion
    }
}
