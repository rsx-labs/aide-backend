using System;
using System.Collections.Generic;
using System.Text;
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsComcellKeys
	{

		#region Data Members

		int _commendID;

		#endregion

        #region Constructor

        public clsComcellKeys(int commendID)
        {
            _commendID = commendID;
        }



		#endregion

        #region Properties

        public int COMMEND_ID
        {
            get { return _commendID; }
        }


		#endregion

	}
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////