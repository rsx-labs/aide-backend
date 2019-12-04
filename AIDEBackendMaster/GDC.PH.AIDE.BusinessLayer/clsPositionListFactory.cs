using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsPositionListFactory
    {
        #region data Members

        clsPositionListsSql _dataObject = null;

        #endregion

        #region Constructor

        public clsPositionListFactory()
        {
            _dataObject = new clsPositionListsSql();
        }

        #endregion

        #region Public Methods

        public List<clsPositionList> GetAllPosition()
        {
            return _dataObject.GetAllPosition();
        }

        public List<clsPermissionList> GetAllPermission()
        {
            return _dataObject.GetAllPermission();
        }

        public List<clsDepartmentList> GetAllDepartment()
        {
            return _dataObject.GetAllDeparment();
        }

        public List<clsDivisionList> GetAllDivision(int deptID)
        {
            return _dataObject.GetAllDivision(deptID);
        }

        public List<clsStatusList> GetAllStatus(string _statusname)
        {
            return _dataObject.GetAllStatus(_statusname);
        }

        public List<clsLocationList> GetAllLocation()
        {
            return _dataObject.GetAllLocation();
        }

        public List<clsFiscalYearList> GetAllFiscalYear()
        {
            return _dataObject.GetAllFiscalYear();
        }

        #endregion
    }
}
