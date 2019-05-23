using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsTasksKeys
	{

		#region Data Members

		int _tASK_ID;

		#endregion

		#region Constructor

		public clsTasksKeys(int tASK_ID)
		{
			 _tASK_ID = tASK_ID; 
		}

		#endregion

		#region Properties

		public int  TASK_ID
		{
			 get { return _tASK_ID; }
		}

		#endregion

	}
}
