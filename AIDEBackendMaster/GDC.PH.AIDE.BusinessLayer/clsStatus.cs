using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
	public class clsStatus: BusinessObjectBase
	{

		#region InnerClass
		public enum clsStatusFields
		{
            STATUS_ID,
			STATUS_NAME,
			DESCR,
			STATUS
		}
		#endregion

		#region Data Members

        byte _status_ID;
			string _status_NAME;
			string _dESCR;
			byte _sTATUS;

		#endregion

		#region Properties

		public byte  STATUS_ID
		{
			 get { return _status_ID; }
			 set
			 {
                 if (_status_ID != value)
				 {
                     _status_ID = value;
                    PropertyHasChanged("STATUS");
				 }
			 }
		}

        public string STATUS_NAME
		{
            get { return _status_NAME; }
			 set
			 {
                 if (_status_NAME != value)
				 {
                     _status_NAME = value;
                    PropertyHasChanged("STATUS_NAME");
				 }
			 }
		}

		public string  DESCR
		{
			 get { return _dESCR; }
			 set
			 {
				 if (_dESCR != value)
				 {
					_dESCR = value;
					 PropertyHasChanged("DESCR");
				 }
			 }
		}

		public byte  STATUS
		{
			 get { return _sTATUS; }
			 set
			 {
				 if (_sTATUS != value)
				 {
					_sTATUS = value;
					 PropertyHasChanged("STATUS");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("STATUS_ID", "STATUS_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("STATUS_NAME", "STATUS_NAME"));
            ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("STATUS_NAME", "STATUS_NAME", 20));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DESCR", "DESCR"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("DESCR", "DESCR",20));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("STATUS", "STATUS"));
		}

		#endregion

	}
}
