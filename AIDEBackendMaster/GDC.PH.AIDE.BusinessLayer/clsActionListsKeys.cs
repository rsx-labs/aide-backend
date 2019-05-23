using System;
using System.Collections.Generic;
using System.Text;
/* By Lemuela Abulencia */
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsActionListsKeys
    {
        #region Data Members

        string _action_message;

        #endregion

        #region Constructor

        public clsActionListsKeys(string action_message)
        {
            _action_message = action_message;
        }

        #endregion

        #region Properties

        public string ACT_Message
        {
            get { return _action_message; }
        }

        #endregion
    }
}
