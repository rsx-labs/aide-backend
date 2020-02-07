using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsBillablesFactory
    {

        #region Data Members

        clsBillablesSql _dataObject = null;

        #endregion

        #region Constructor

        public clsBillablesFactory()
        {
            _dataObject = new clsBillablesSql();
        }

        #endregion

        #region Public Methods

        public List<clsBillables> GetBillableHoursByMonth(int empID, int month, int year, int weekID)
        {
            return _dataObject.GetBillableHoursByMonth(empID, month, year, weekID);
        }

        public List<clsBillables> GetBillableHoursByWeek(int empID, int weekID)
        {
            return _dataObject.GetBillableHoursByWeek(empID, weekID);
        }

        public bool InsertLeaveCredits(int empID, int year)
        {
            return _dataObject.InsertLeaveCredits(empID, year);
        }

        //public List<clsBillables> GetNonBillableHours(string email, int display, int month, int year)
        //{
        //    return _dataObject.GetNonBillableHours(email, display, month, year);
        //}
        #endregion

    }
}
