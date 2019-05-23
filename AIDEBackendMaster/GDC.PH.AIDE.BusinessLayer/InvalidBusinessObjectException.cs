using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer
{
    /// <summary>
    /// Class to create custom exception
    /// </summary>
    public class InvalidBusinessObjectException: Exception
    {

        #region Data members

        string _methodName = string.Empty;

        #endregion 

        #region Constructor

        /// <summary>
        /// Constructor to set message
        /// </summary>
        /// <param name="message">error message</param>
        public InvalidBusinessObjectException(string message)
            : base(message)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// get/set Method name
        /// </summary>
        public string MethodName
        {
            get { return _methodName; }
            set { _methodName = value; }
        }

        #endregion

    }
}
