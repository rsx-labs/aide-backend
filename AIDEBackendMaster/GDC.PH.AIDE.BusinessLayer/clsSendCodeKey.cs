using System;
using System.Collections.Generic;
using System.Text;
/* By Lemuela Abulencia */
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsSendCodeKey
    {

        #region Data Members

        string _send_code_email_address;

        #endregion

        #region Constructor

        public clsSendCodeKey(string send_code_email_address)
        {
            _send_code_email_address = send_code_email_address;
        }

        #endregion

        #region Properties

        public string SEND_CODE_EMAIL_ADDRESS
        {
            get { return _send_code_email_address; }
        }

        #endregion


    }
}
