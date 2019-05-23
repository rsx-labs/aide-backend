using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// BY GIANN CARLO CAMILO
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsAssignedProjectsKeys
    {


        #region Data Members

        int _eMP_ID;

        #endregion

        #region Constructor

        public clsAssignedProjectsKeys(int eMP_ID)
        {
            _eMP_ID = eMP_ID;
        }

        #endregion

        #region Properties

        public int EMP_ID
        {
            get { return _eMP_ID; }
        }

        #endregion

    }
}
