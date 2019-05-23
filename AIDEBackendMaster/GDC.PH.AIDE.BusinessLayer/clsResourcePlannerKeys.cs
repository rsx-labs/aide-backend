using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// By Jhunell G. Barcenas
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsResourcePlannerKeys
    {

        #region Data Members

        int _eMP_ID;
        int _Month;
        short _Year;
        string _email;

        #endregion

        #region Constructor

        public clsResourcePlannerKeys(int eMP_ID, int Month, short Year)
        {
            _eMP_ID = eMP_ID;
            _Month = Month;
            _Year = Year;

        }

        public clsResourcePlannerKeys(string email, int Month, short Year)
        {
            _email = email;
            _Month = Month;
            _Year = Year;

        }

        #endregion

        #region Properties

        public int EMP_ID
        {
            get { return _eMP_ID; }
        }

        public int MONTH
        {
            get { return _Month; }
        }

        public short YEAR
        {
            get { return _Year; }
        }

        public string EMAIL
        {
            get { return _email; }
        }

        #endregion

    }
}
