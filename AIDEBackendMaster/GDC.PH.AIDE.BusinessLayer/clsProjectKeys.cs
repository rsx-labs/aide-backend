using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsProjectKeys
    {

        #region Data Members

        int _pROJ_ID;

        #endregion

        #region Constructor

        public clsProjectKeys(int pROJ_ID)
        {
            _pROJ_ID = pROJ_ID;
        }

        #endregion

        #region Properties

        public int PROJ_ID
        {
            get { return _pROJ_ID; }
        }

        #endregion

    }
}
