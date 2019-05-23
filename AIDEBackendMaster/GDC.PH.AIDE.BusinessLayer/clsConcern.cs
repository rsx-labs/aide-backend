using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// BY GIANN CARLO CAMILO/CHRISTIAN VALONDO
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsConcern : BusinessObjectBase
    {
        #region InnerClass
        public enum clsConcernFields
        {
            REF_ID,
            CONCERN,
            CAUSE,
            COUNTERMEASURE,
            EMP_ID,
            ACT_REFERENCE,
            DUE_DATE,
            DESCR,       
            GENERATEDREF_ID,
            ACTREF,
            ACT_MESSAGE,
            ACTION_REFERENCES,
            DATE1,
            DATE2
        }
        #endregion

        #region Data Members



        string _rEF_ID;
        string _cONCERN;
        string _cAUSE;
        string _cOUNTERMEASURE;
        string _eMP_ID;
        string _aCT_REFERENCE;
        string _DESCR;       
        string _gENERATEDREF_ID;
        string _actREF;
        string _aCT_MESSAGE;
        string _aCTion_References;
        DateTime _dATE1;
        DateTime _dATE2;
        DateTime _dUE_DATE;



        #endregion

        #region Properties

        public string REF_ID
        {
            get { return _rEF_ID; }
            set
            {
                if (_rEF_ID != value)
                {
                    _rEF_ID = value;
                    PropertyHasChanged("REF_ID");
                }
            }
        }

        public string CONCERN
        {
            get { return _cONCERN; }
            set
            {
                if (_cONCERN != value)
                {
                    _cONCERN = value;
                    PropertyHasChanged("CONCERN");
                }
            }
        }

        public string CAUSE
        {
            get { return _cAUSE; }
            set
            {
                if (_cAUSE != value)
                {
                    _cAUSE = value;
                    PropertyHasChanged("CAUSE");
                }
            }
        }
        public string COUNTERMEASURE
        {
            get { return _cOUNTERMEASURE; }
            set
            {
                if (_cOUNTERMEASURE != value)
                {
                    _cOUNTERMEASURE = value;
                    PropertyHasChanged("CAUSE");
                }
            }
        }

        public string EMP_ID
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

        public string ACT_REFERENCE
        {
            get { return _aCT_REFERENCE; }
            set
            {
                if (_aCT_REFERENCE != value)
                {
                    _aCT_REFERENCE = value;
                    PropertyHasChanged("ACT_REFERENCE");
                }
            }
        }

        public DateTime  DUE_DATE
        {
            get { return _dUE_DATE; }
            set
            {
                if (_dUE_DATE != value)
                {
                    _dUE_DATE = value;
                    PropertyHasChanged("DUE_DATE");
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
       


        public string GENERATEDREF_ID
        {
            get { return _gENERATEDREF_ID; }
            set
            {
                if (_gENERATEDREF_ID != value)
                {
                    _gENERATEDREF_ID = value;
                    PropertyHasChanged("GENERATEDREF_ID");
                }
            }
        }


        public string ACTREF
        {
            get { return _actREF; }
            set
            {
                if (_actREF != value)
                {
                    _actREF = value;
                    PropertyHasChanged("ACTREF");
                }
            }
        }


        public string ACT_MESSAGE
        {
            get { return _aCT_MESSAGE; }
            set
            {
                if (_aCT_MESSAGE != value)
                {
                    _aCT_MESSAGE = value;
                    PropertyHasChanged("ACT_MESSAGE");
                }
            }
        }


        public string ACTION_REFERENCES
        {
            get { return _aCTion_References; }
            set
            {
                if (_aCTion_References != value)
                {
                    _aCTion_References = value;
                    PropertyHasChanged("ACTION_REFERENCES");
                }
            }
        }


        public DateTime DATE1
        {
            get { return _dATE1; }
            set
            {
                if (_dATE1 != value)
                {
                    _dATE1 = value;
                    PropertyHasChanged("DATE1");
                }
            }
        }


        public DateTime DATE2
        {
            get { return _dATE2; }
            set
            {
                if (_dATE2 != value)
                {
                    _dATE2 = value;
                    PropertyHasChanged("DATE2");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            
          
        }

        #endregion
    }
}
