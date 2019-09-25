using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class ClsKPITargetsKeys
    {

		#region Data Members

        
		int _Id;
        int _empId;
        DateTime _FYear;

		#endregion

        #region Constructor

        public ClsKPITargetsKeys(int id, int EmpID, DateTime fyear)
        {
            _empId = EmpID;
            _Id = id;
            _FYear = fyear;
        }



		#endregion

        #region Properties

        public int ID
        {
            get { return _Id; }
        }

        public int EMP_ID
        {
            get { return _empId; }
        }
        public DateTime FISCAL_YEAR
        {
            get { return _FYear; }
        }
        #endregion

    }
}
