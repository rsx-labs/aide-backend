using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;
/// <summary>
/// BY GIANN CARLO CAMILO
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsProfileFactory
    {
        #region Data Members

        clsProfileSql _dataObject = null;

        #endregion

        #region Constructor

        public clsProfileFactory()
        {
            _dataObject = new clsProfileSql();
        }

        #endregion

        #region Public Methods

        public clsProfile getProfile(clsProfileKeys keys)
        {
            return _dataObject.getProfile(keys);
        }

        public clsProfile getProfileByEmailAddress(string emailAddress)
        {
            return _dataObject.getProfileByEmailAddress(emailAddress);
        }
        public bool UpdateProfile(clsProfile businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }   


            return _dataObject.UpdateProfile(businessObject);
        }

        #endregion
    }
}
