using System;
using System.Collections.Generic;
using System.Text;
/* By Lemuela Abulencia */
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsComcellClockKeys
    {
        #region Data Members

        int _emp_id;

        #endregion

        #region Constructor

        public clsComcellClockKeys(int emp_id)
        {
            _emp_id = emp_id;
        }

        #endregion

        #region Properties

        public int EMP_ID
        {
            get { return _emp_id; }
        }

        #endregion
    }
}
