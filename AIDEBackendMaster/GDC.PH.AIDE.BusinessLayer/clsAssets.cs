using System;
using System.Collections.Generic;
using System.Text;
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsAssets : BusinessObjectBase
    {

        #region InnerClass
        public enum clsAssetsFields
        {
            ASSET_ID,
            EMP_ID,
            ASSET_DESC,
            MANUFACTURER,
            MODEL_NO,
            SERIAL_NO,
            ASSET_TAG,
            DATE_PURCHASED,
            STATUS,
            OTHER_INFO,
            FULL_NAME,
            COMMENTS,
            DEPARTMENT,
            DATE_ASSIGNED,
            ASSIGNED_TO,
            APPROVAL,
            TABLE_NAME,
            STATUS_DESCR
        }
        #endregion

        #region Data Members

        int _assetID;
        int _empID;
        string _assetDesc;
        string _manufacturer;
        string _modelNo;
        string _serialNo;
        string _assetTag;
        DateTime _datePurchased;
        int _status;
        string _otherInfo;
        string _fullname;
        string _department;
        DateTime _dateAssigned;
        string _comments;
        string _assignedTo;
        int _approval;
        string _tableName;
        string _descr;
        #endregion

        #region Properties

        public int APPROVAL
        {
            get { return _approval; }
            set
            {
                if (_approval != value)
                {
                    _approval = value;
                    PropertyHasChanged("APPROVAL");
                }
            }
        }

        public int ASSET_ID
        {
            get { return _assetID; }
            set
            {
                if (_assetID != value)
                {
                    _assetID = value;
                    PropertyHasChanged("ASSET_ID");
                }
            }
        }

        public int EMP_ID
        {
            get { return _empID; }
            set
            {
                if (_empID != value)
                {
                    _empID = value;
                    PropertyHasChanged("EMP_ID");
                }
            }
        }

        public string ASSET_DESC
        {
            get { return _assetDesc; }
            set
            {
                if (_assetDesc != value)
                {
                    _assetDesc = value;
                    PropertyHasChanged("ASSET_DESC");
                }
            }
        }

        public string MANUFACTURER
        {
            get { return _manufacturer; }
            set
            {
                if (_manufacturer != value)
                {
                    _manufacturer = value;
                    PropertyHasChanged("MANUFACTURER");
                }
            }
        }

        public string MODEL_NO
        {
            get { return _modelNo; }
            set
            {
                if (_modelNo != value)
                {
                    _modelNo = value;
                    PropertyHasChanged("MODEL_NO");
                }
            }
        }

        public string SERIAL_NO
        {
            get { return _serialNo; }
            set
            {
                if (_serialNo != value)
                {
                    _serialNo = value;
                    PropertyHasChanged("SERIAL_NO");
                }
            }
        }

        public string ASSET_TAG
        {
            get { return _assetTag; }
            set
            {
                if (_assetTag != value)
                {
                    _assetTag = value;
                    PropertyHasChanged("ASSET_TAG");
                }
            }
        }

        public DateTime DATE_PURCHASED
        {
            get { return _datePurchased; }
            set
            {
                if (_datePurchased != value)
                {
                    _datePurchased = value;
                    PropertyHasChanged("DATE_PURCHASED");
                }
            }
        }

        public int STATUS
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    PropertyHasChanged("STATUS");
                }
            }
        }

        public string OTHER_INFO
        {
            get { return _otherInfo; }
            set
            {
                if (_otherInfo != value)
                {
                    _otherInfo = value;
                    PropertyHasChanged("OTHER_INFO");
                }
            }
        }

        public DateTime DATE_ASSIGNED
        {
            get { return _dateAssigned; }
            set
            {
                if (_dateAssigned != value)
                {
                    _dateAssigned = value;
                    PropertyHasChanged("DATE_ASSIGNED");
                }
            }
        }

        public string FULL_NAME
        {
            get { return _fullname; }
            set
            {
                if (_fullname != value)
                {
                    _fullname = value;
                    PropertyHasChanged("FULL_NAME");
                }
            }
        }

        public string DEPARTMENT
        {
            get { return _department; }
            set
            {
                if (_department != value)
                {
                    _department = value;
                    PropertyHasChanged("DEPARTMENT");
                }
            }
        }

        public string COMMENTS
        {
            get { return _comments; }
            set
            {
                if (_comments != value)
                {
                    _comments = value;
                    PropertyHasChanged("COMMENTS");
                }
            }
        }

        public string ASSIGNED_TO
        {
            get { return _assignedTo; }
            set
            {
                if (_assignedTo != value)
                {
                    _assignedTo = value;
                    PropertyHasChanged("ASSIGNED_TO");
                }
            }
        }

        public string TABLE_NAME
        {
            get { return _tableName; }
            set
            {
                if (_tableName != value)
                {
                    _tableName = value;
                    PropertyHasChanged("TABLE_NAME");
                }
            }
        }

        public string STATUS_DESCR
        {
            get { return _descr; }
            set
            {
                if (_descr != value)
                {
                    _descr = value;
                    PropertyHasChanged("STATUS_DESCR");
                }
            }
        }
 
        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ASSET_ID", "ASSET_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ASSET_DESC", "ASSET_DESC"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("MANUFACTURER", "MANUFACTURER"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("MODEL_NO", "MODEL_NO"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SERIAL_NO", "SERIAL_NO"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ASSET_TAG", "ASSET_TAG"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DATE_PURCHASED", "DATE_PURCHASED"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("STATUS", "STATUS"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("OTHER_INFO", 255));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ASSIGNED_TO", "ASSIGNED_TO"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("APPROVAL", "APPROVAL"));
        }
        #endregion

    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////