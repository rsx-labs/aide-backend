using System;
using System.Collections.Generic;
using System.Text;

///<summary>
/// By John Harvey Sanchez / Marivic Espino
///<summary>

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsLessonLearnt : BusinessObjectBase
    {

        #region InnerClass
        public enum clsLessonLearntFields
        {
            REF_NO,
            EMP_ID,
            NICK_NAME,
            PROBLEM,
            RESOLUTION,
            ACTION_NO
        }
        #endregion

        #region Data Members

        string _rEF_NO;
        string _nICKNAME;
        string _pROBLEM;
        string _rESOLUTION;
        string _aCTION_NO;
        int _eMP_ID;

        #endregion

        #region Properties

        public string REF_NO
        {
            get { return _rEF_NO; }
            set
            {
                if (_rEF_NO != value)
                {
                    _rEF_NO = value;
                    PropertyHasChanged("REF_NO");
                }
            }
        }

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

        public string NICK_NAME
        {
            get { return _nICKNAME; }
            set
            {
                if (_nICKNAME != value)
                {
                    _nICKNAME = value;
                    PropertyHasChanged("NICK_NAME");
                }
            }
        }

        public string PROBLEM
        {
            get { return _pROBLEM; }
            set
            {
                if (_pROBLEM != value)
                {
                    _pROBLEM = value;
                    PropertyHasChanged("PROBLEM");
                }
            }
        }

        public string RESOLUTION
        {
            get { return _rESOLUTION; }
            set
            {
                if (_rESOLUTION != value)
                {
                    _rESOLUTION = value;
                    PropertyHasChanged("RESOLUTION");
                }
            }
        }

        public string ACTION_NO
        {
            get { return _aCTION_NO; }
            set
            {
                if (_aCTION_NO != value)
                {
                    _aCTION_NO = value;
                    PropertyHasChanged("ACTION_NO");
                }
            }
        }
        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("REF_NO", "REF_NO"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PROBLEM", "PROBLEM"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("PROBLEM", "PROBLEM", 500));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("RESOLUTION", "RESOLUTION"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("RESOLUTION", "RESOLUTION", 500));
        }

        #endregion
    }
}
