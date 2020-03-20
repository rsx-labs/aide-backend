using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsReportsFactory
    {

        #region data Members

        clsReportsSql _dataObject = null;

        #endregion

         #region Constructor

        public clsReportsFactory()
        {
            _dataObject = new clsReportsSql();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// get list of all clsSabaLearning
        /// </summary>
        /// <returns>list</returns>
        public List<clsReports> GetAllReports()
        {
            return _dataObject.GetAllReports();
        }

        #endregion
    }
}
