using System;
using System.Collections.Generic;
using System.Text;
/* By Jester Sanchez */
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsMailConfig : BusinessObjectBase
    {

        #region InnerClass
        public enum clsMailConfigFields
        {
            SC_SENDER_EMAIL,
            SC_SUBJECT,
            SC_BODY,
            SC_PORT,
            SC_HOST,
            SC_ENABLE_SSL,
            SC_TIMEOUT,
            SC_USE_DFLT_CREDENTIALS,
            SC_SENDER_PASSWORD,
            SC_PASSWORD_EXPIRY
        }
        #endregion

        #region Data Members

        string _sc_sender_email;
        string _sc_subject;
        string _sc_body;
        int _sc_port;
        string _sc_host;
        int _sc_enable_ssl;
        int _sc_timeout;
        int _sc_use_dflt_credentials;
        string _sc_sender_password;
        int _sc_password_expiry;

        #endregion

        #region Properties

        public string SC_SENDER_EMAIL
        {
            get { return _sc_sender_email; }
            set
            {
                if (_sc_sender_email != value)
                {
                    _sc_sender_email = value;
                    PropertyHasChanged("SC_SENDER_EMAIL");
                }
            }
        }

        public string SC_SUBJECT
        {
            get { return _sc_subject; }
            set
            {
                if (_sc_subject != value)
                {
                    _sc_subject = value;
                    PropertyHasChanged("SC_SUBJECT");
                }
            }
        }


        public string SC_BODY
        {
            get { return _sc_body; }
            set
            {
                if (_sc_body != value)
                {
                    _sc_body = value;
                    PropertyHasChanged("SC_BODY");
                }
            }
        }

        public int SC_PORT 
        {
            get { return _sc_port; }
            set
            {
                if (_sc_port != value)
                {
                    _sc_port = value;
                    PropertyHasChanged("SC_PORT");
                }
            }
        }

        public string SC_HOST
        {
            get { return _sc_host; }
            set
            {
                if (_sc_host != value)
                {
                    _sc_host = value;
                    PropertyHasChanged("SC_HOST");
                }
            }
        }

        public int SC_ENABLE_SSL
        {
            get { return _sc_enable_ssl; }
            set
            {
                if (_sc_enable_ssl != value)
                {
                    _sc_enable_ssl = value;
                    PropertyHasChanged("SC_ENABLE_SSL");
                }
            }
        }

        public int SC_TIMEOUT
        {
            get { return _sc_timeout; }
            set
            {
                if (_sc_timeout != value)
                {
                    _sc_timeout = value;
                    PropertyHasChanged("SC_TIMEOUT");
                }
            }
        }

        public int SC_USE_DFLT_CREDENTIALS
        {
            get { return _sc_use_dflt_credentials; }
            set
            {
                if (_sc_use_dflt_credentials != value)
                {
                    _sc_use_dflt_credentials = value;
                    PropertyHasChanged("SC_USE_DFLT_CREDENTIALS");
                }
            }
        }

        public string SC_SENDER_PASSWORD
        {
            get { return _sc_sender_password; }
            set
            {
                if (_sc_sender_password != value)
                {
                    _sc_sender_password = value;
                    PropertyHasChanged("SC_SENDER_PASSWORD");
                }
            }
        }

        public int SC_PASSWORD_EXPIRY
        {
            get { return _sc_password_expiry; }
            set
            {
                if (_sc_password_expiry != value)
                {
                    _sc_password_expiry = value;
                    PropertyHasChanged("SC_PASSWORD_EXPIRY");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SC_SENDER_EMAIL", "SC_SENDER_EMAIL"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SC_SUBJECT", "SC_SUBJECT"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SC_BODY", "SC_BODY"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SC_PORT", "SC_PORT"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SC_HOST", "SC_HOST"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SC_ENABLE_SSL", "SC_ENABLE_SSL"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SC_TIMEOUT", "SC_TIMEOUT"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SC_USE_DFLT_CREDENTIALS", "SC_USE_DFLT_CREDENTIALS"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SC_SENDER_PASSWORD", "SC_SENDER_PASSWORD"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("SC_PASSWORD_EXPIRY", "SC_PASSWORD_EXPIRY"));
        }

        #endregion

    }
}
