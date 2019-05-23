using System;
using System.Collections.Generic;
using System.Text;

///<summary>
/// By Krizza Tolento
///<summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsSuccessRegisterKeys
    {
        #region Data Members

        int _eMP_ID;
        string _input;
        int _deptID;
        string _email;

        #endregion

        #region Constructor

        public clsSuccessRegisterKeys(int eMP_ID, int deptID)
        {
            _eMP_ID = eMP_ID;
            _deptID = deptID;
        }

        public clsSuccessRegisterKeys()
        {
        }

        public clsSuccessRegisterKeys(string input)
        {
            _input = input;
        }
        public clsSuccessRegisterKeys(string input, string email)
        {
            _input = input;
            _email = email;
        }

        #endregion

        #region Properties

        public int EMP_ID
        {
            get { return _eMP_ID; }
        }

        public string SEARCH_INPUT
        {
            get { return _input; }
        }

        public string EMAIL
        {
            get { return _email; }
        }

        #endregion
    }
}
