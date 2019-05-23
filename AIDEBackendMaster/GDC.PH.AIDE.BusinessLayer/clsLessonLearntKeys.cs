using System;
using System.Collections.Generic;
using System.Text;

///<summary>
/// By Marivic Espino
///<summary>

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsLessonLearntKeys
    {

        #region Data Members

        string _pROBLEM;

        #endregion

        #region Constructor

        public clsLessonLearntKeys(string pROBLEM)
        {
            _pROBLEM = pROBLEM;
        }

        #endregion

        #region Properties

        public string PROBLEM
        {
            get { return _pROBLEM; }
        }

        #endregion

    }
}
