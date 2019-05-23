using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

///<summary>
/// By Krizza Tolento
///<summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsSuccessRegisterFactory
    {
        #region "Data Members     
            private clsSuccessRegisterSql _dataObject = null;
        #endregion

        #region "Constructor"

        public clsSuccessRegisterFactory()
        {
            _dataObject = new clsSuccessRegisterSql();
        }

        #endregion

        #region "Public Methods"

        public List<clsSuccessRegister> getSuccessRegisterAll(string email)
        {
            return _dataObject.getSuccessRegisterAll(email);
        }
        public List<clsSuccessRegister> getSuccessRegisterBySearch(clsSuccessRegisterKeys keys)
        {
            return _dataObject.getSuccessRegisterBySearch(keys.SEARCH_INPUT, keys.EMAIL);
        }
        public List<clsSuccessRegister> getSuccessRegisterByEmpID(string email)
        {
            return _dataObject.getSuccessRegisterByEmpID(email);
        }
        public bool UpdateSuccessRegister(clsSuccessRegister businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }

            return _dataObject.UpdateSuccessRegister(businessObject);
        }

        public bool DeleteSuccessRegister(int successID)
        {
            return _dataObject.DeleteSuccessRegister(successID);
        }
        public bool InsertSuccessRegister(clsSuccessRegister businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }
            return _dataObject.InsertSuccessRegister(businessObject);

        }
        #endregion
    }
}
