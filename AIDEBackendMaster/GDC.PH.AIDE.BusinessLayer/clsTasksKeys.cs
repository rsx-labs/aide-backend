using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsTasksKeys
	{

		#region Data Members

		int _task_ID;

		#endregion

		#region Constructor

		public clsTasksKeys(int tASK_ID)
		{
            _task_ID = tASK_ID; 
		}

		#endregion

		#region Properties

		public int  TASK_ID
		{
            get { return _task_ID; }
		}

		#endregion

	}
}
