using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsPositionList : BusinessObjectBase
    {
        #region InnerClass
        public enum clsPositionListFields
        {
            POS_ID,
            POS_DESCR
        }
        #endregion

        #region Data Members

        int _posID;
        string _posDescr;
        
        #endregion

        #region Properties

        public int POS_ID
        {
            get { return _posID; }
            set
            {
                if (_posID != value)
                {
                    _posID = value;
                    PropertyHasChanged("POS_ID");
                }
            }
        }
        public string POS_DESCR
        {
            get { return _posDescr; }
            set
            {
                if (_posDescr != value)
                {
                    _posDescr = value;
                    PropertyHasChanged("POS_DESCR");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("POS_ID", "POS_ID"));
        }
        #endregion
    }

    public class clsPermissionList : BusinessObjectBase
    {
        #region InnerClass
        public enum clsPermissionListFields
        {
            GRP_ID,
            GRP_DESCR
        }
        #endregion

        #region Data Members

        int _grpID;
        string _grpDescr;

        #endregion

        #region Properties

        public int GRP_ID
        {
            get { return _grpID; }
            set
            {
                if (_grpID != value)
                {
                    _grpID = value;
                    PropertyHasChanged("GRP_ID");
                }
            }
        }
        public string GRP_DESCR
        {
            get { return _grpDescr; }
            set
            {
                if (_grpDescr != value)
                {
                    _grpDescr = value;
                    PropertyHasChanged("GRP_DESCR");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("GRP_ID", "GRP_ID"));
        }
        #endregion
    }

    public class clsDepartmentList : BusinessObjectBase
    {
        #region InnerClass
        public enum clsDepartmentListFields
        {
           
            DEPT_ID,
            DEPT_DESC
            
        }
        #endregion

        #region Data Members

        int _deptID;
        string _deptDescr;
        
        #endregion

        #region Properties

        public int DEPT_ID
        {
            get { return _deptID; }
            set
            {
                if (_deptID != value)
                {
                    _deptID = value;
                    PropertyHasChanged("DEPT_ID");
                }
            }
        }
        public string DEPT_DESCR
        {
            get { return _deptDescr; }
            set
            {
                if (_deptDescr != value)
                {
                    _deptDescr = value;
                    PropertyHasChanged("DEPT_DESCR");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DEPT_ID", "DEPT_ID"));
        }
        #endregion
    }

    public class clsDivisionList : BusinessObjectBase
    {
        #region InnerClass
        public enum clsDivisionListFields
        {
           
            DIV_ID,
            DIV_DESCR

        }
        #endregion

        #region Data Members

        int _divID;
        string _divDescr;

        #endregion

        #region Properties

        public int DIV_ID
        {
            get { return _divID; }
            set
            {
                if (_divID != value)
                {
                    _divID = value;
                    PropertyHasChanged("DIV_ID");
                }
            }
        }
        public string DIV_DESCR
        {
            get { return _divDescr; }
            set
            {
                if (_divDescr != value)
                {
                    _divDescr = value;
                    PropertyHasChanged("DIV_DESCR");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DIV_ID", "DIV_ID"));
        }
        #endregion
    }

    public class clsStatusList : BusinessObjectBase
    {
        #region InnerClass
        public enum clsStatusListFields
        {
         
            STATUS_ID,
            STATUS_DESCR

        }
        #endregion

        #region Data Members

        int _statusID;
        string _statusDescr;

        #endregion

        #region Properties

        public int STATUS_ID
        {
            get { return _statusID; }
            set
            {
                if (_statusID != value)
                {
                    _statusID = value;
                    PropertyHasChanged("STATUS_ID");
                }
            }
        }
        public string STATUS_DESCR
        {
            get { return _statusDescr; }
            set
            {
                if (_statusDescr != value)
                {
                    _statusDescr = value;
                    PropertyHasChanged("STATUS_DESCR");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("STATUS_ID", "STATUS_ID"));
        }
        #endregion
    }

    public class clsLocationList : BusinessObjectBase
    {
        #region InnerClass
        public enum clsLocationListFields
        {
            LOCATION_ID,
            LOCATION,
            ONSITE_FLG
        }
        #endregion

        #region Data Members

        int _locationID;
        string _location;
        short _onsiteFlg;

        #endregion

        #region Properties

        public int LOCATION_ID
        {
            get { return _locationID; }
            set
            {
                if (_locationID != value)
                {
                    _locationID = value;
                    PropertyHasChanged("LOCATION_ID");
                }
            }
        }

        public string LOCATION
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    PropertyHasChanged("LOCATION");
                }
            }
        }

        public short ONSITE_FLG
        {
            get { return _onsiteFlg; }
            set
            {
                if (_onsiteFlg != value)
                {
                    _onsiteFlg = value;
                    PropertyHasChanged("ONSITE_FLG");
                }
            }
        }
        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("LOCATION_ID", "LOCATION_ID"));
        }
        #endregion
    }
}
