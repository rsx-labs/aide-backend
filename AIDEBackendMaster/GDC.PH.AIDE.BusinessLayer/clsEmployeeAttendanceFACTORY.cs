using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsEmployeeAttendanceFactory
    {
        #region data Members

        clsEmployeeAttendanceSql _dataObject = null;

        #endregion

        #region Constructor

        public clsEmployeeAttendanceFactory()
        {
            _dataObject = new clsEmployeeAttendanceSql();
        }

        #endregion

        #region Public Methods
        public List<clsEmployeeAttendance> GetAll()
        {
            return _dataObject.SelectAll();
        }
        #endregion
    }
}
