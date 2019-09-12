using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class ClsKPITargetsKeys
    {

		#region Data Members

		int _Id;

        DateTime _FYear;

		#endregion

        #region Constructor

        public ClsKPITargetsKeys(int id, DateTime fyear)
        {
            _Id = id;
            _FYear = fyear;
        }



		#endregion

        #region Properties

        public int ID
        {
            get { return _Id; }
        }

        public DateTime FISCAL_YEAR
        {
            get { return _FYear; }
        }
        #endregion

    }
}
