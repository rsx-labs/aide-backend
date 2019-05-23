using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsStatusKeys
	{

		#region Data Members
        int _grp_ID;

		#endregion

		#region Constructor

		public clsStatusKeys(int gRP_ID)
		{
            _grp_ID = gRP_ID; 
		}

		#endregion

		#region Properties

        public int GRP_ID
        {
            get { return _grp_ID; }
        }
		#endregion

	}
}
