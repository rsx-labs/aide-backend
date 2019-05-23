    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// BY GIANN CARLO CAMILO/CHRISTIAN VALONDO
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    class clsConcernKeys
    {
     #region Data Members

        string _rEF_ID;

        #endregion

        #region Constructor

        public clsConcernKeys(string rEF_ID)
        {
            _rEF_ID = rEF_ID;
        }

        #endregion

        #region Properties

        public string REF_ID
        {
            get { return _rEF_ID; }
        }

        #endregion

    }
}
