using System;
using System.Collections.Generic;
using System.Text;
///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsContactsKeys
	{

		#region Data Members

		int _eMP_ID;
        string _email;

		#endregion

        #region Constructor

        public clsContactsKeys(int eMP_ID)
        {
            _eMP_ID = eMP_ID;
        }

        public clsContactsKeys(string email)
        {
            _email = email;
        }

		#endregion

        #region Properties

        public int EMP_ID
        {
            get { return _eMP_ID; }
        }

        public string EMAIL
        {
            get { return _email; }
        }

		#endregion

	}
}
///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
