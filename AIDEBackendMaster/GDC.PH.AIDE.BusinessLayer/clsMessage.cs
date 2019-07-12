using System;
using System.Collections.Generic;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsMessage : BusinessObjectBase
    {
        #region InnerClass
        public enum clsMessageFields
        {
            MESSAGE_DESCR,
            TITLE
        }
        #endregion

        #region Data Members

        string _message_descr;
        string _title;

        #endregion

        #region Properties

        public string MESSAGE_DESCR
        {
            get { return _message_descr; }
            set
            {
                if (_message_descr != value)
                {
                    _message_descr = value;
                    PropertyHasChanged("MESSAGE_DESCR");
                }
            }
        }

        public string TITLE
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    PropertyHasChanged("TITLE");
                }
            }
        }
        #endregion
    }
}
