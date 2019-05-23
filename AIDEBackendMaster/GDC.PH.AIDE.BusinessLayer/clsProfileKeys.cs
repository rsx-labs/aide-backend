using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// BY GIANN CARLO CAMILO
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsProfileKeys
    {

        #region Data Members

		String _eMP_ID;

		#endregion

		#region Constructor




		public clsProfileKeys(string eMP_ID)
		{
			 _eMP_ID = eMP_ID; 
		}

		#endregion

		#region Properties

		public string  EMP_ID
		{
			 get { return _eMP_ID; }
		}

		#endregion

    }
}
