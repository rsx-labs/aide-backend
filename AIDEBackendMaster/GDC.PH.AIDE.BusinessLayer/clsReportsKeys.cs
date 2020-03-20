using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsReportsKeys
    {
        #region Data Members

        int _report_id;

        #endregion

        #region Constructor


        public clsReportsKeys(int report_id)
        {
            _report_id = report_id;
        }
        #endregion

        #region Properties

        public int REPORT_ID
        {
            get { return _report_id; }
        }

        #endregion
    }
}
