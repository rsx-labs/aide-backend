using System;
using System.Collections.Generic;
using System.Text;
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsAnnouncements : BusinessObjectBase
    {

        #region InnerClass
        public enum clsAnnouncementsFields
        {
            ANNOUNCEMENT_ID,
            EMP_ID,
            MESSAGE,
            TITLE,
            END_DATE
        }
        #endregion

        #region Data Members

        int _announcementID;
        int _empID;
        string _message;
        string _title;
        DateTime _endDate;

        #endregion

        #region Properties

        public int ANNOUNCEMENT_ID
        {
            get { return _announcementID; }
            set
            {
                if (_announcementID != value)
                {
                    _announcementID = value;
                    PropertyHasChanged("ANNOUNCEMENT_ID");
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

        public string MESSAGE
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    PropertyHasChanged("MESSAGE");
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


        public DateTime END_DATE
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    PropertyHasChanged("END_DATE");
                }
            }
        }

 
        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ANNOUNCEMENT_ID", "ANNOUNCEMENT_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("MESSAGE", "MESSAGE"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("TITLE", "TITLE"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("END_DATE", "END_DATE"));
        }
        #endregion

    }
}
///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////