using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsSabaLearningKeys
    {
        #region Data Members

        string _saba_title;

        #endregion

        #region Constructor

        public clsSabaLearningKeys(string saba_message)
        {
            _saba_title = saba_message;
        }

        #endregion

        #region Properties

        public string SABA_MESSAGE
        {
            get { return _saba_title; }
        }

        #endregion
    }
}
