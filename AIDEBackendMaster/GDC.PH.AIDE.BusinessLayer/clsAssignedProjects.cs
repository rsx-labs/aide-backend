using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// BY GIANN CARLO CAMILO
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsAssignedProjects : BusinessObjectBase
    {

        #region InnerClass
        public enum clsAssignedProjectsFields
        {
            EMP_ID,
            PROJ_ID,
            EMPLOYEENAME,
            PROJ_NAME,
            DATE_CREATED,
            START_PERIOD,
            END_PERIOD
        }
        #endregion

        #region Data Members

        int _eMP_ID;
        int _pROJ_ID;
        string _eMPLOYEENAME;
        string _pROJ_NAME;
        DateTime _dATE_CREATED;
        DateTime _sTART_PERIOD;
        DateTime _eND_PERIOD;

        #endregion

        #region Properties

        public int EMP_ID
        {
            get { return _eMP_ID; }
            set
            {
                if (_eMP_ID != value)
                {
                    _eMP_ID = value;
                    PropertyHasChanged("EMP_ID");
                }
            }
        }

        public int PROJ_ID
        {
            get { return _pROJ_ID; }
            set
            {
                if (_pROJ_ID != value)
                {
                    _pROJ_ID = value;
                    PropertyHasChanged("PROJ_ID");
                }
            }
        }

        public string EMPLOYEENAME
        {
            get { return _eMPLOYEENAME; }
            set
            {
                if (_eMPLOYEENAME != value)
                {
                    _eMPLOYEENAME = value;
                    PropertyHasChanged("EMPLOYEENAME");
                }
            }
        }

        public string PROJ_NAME
        {
            get { return _pROJ_NAME; }
            set
            {
                if (_pROJ_NAME != value)
                {
                    _pROJ_NAME = value;
                    PropertyHasChanged("PROJ_NAME");
                }
            }
        }

        public DateTime DATE_CREATED
        {
            get { return _dATE_CREATED; }
            set
            {
                if (_dATE_CREATED != value)
                {
                    _dATE_CREATED = value;
                    PropertyHasChanged("DATE_CREATED");
                }
            }
        }

        public DateTime START_PERIOD
        {
            get { return _sTART_PERIOD; }
            set
            {
                if (_sTART_PERIOD != value)
                {
                    _sTART_PERIOD = value;
                    PropertyHasChanged("START_PERIOD");
                }
            }
        }

        public DateTime END_PERIOD
        {
            get { return _eND_PERIOD; }
            set
            {
                if (_eND_PERIOD != value)
                {
                    _eND_PERIOD = value;
                    PropertyHasChanged("END_PERIOD");
                }
            }
        }


        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PROJ_ID", "PROJ_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMPLOYEENAME", "EMPLOYEENAME"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("PROJ_NAME", "PROJ_NAME"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("DATE_CREATED", "DATE_CREATED"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("START_PERIOD", "START_PERIOD"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("END_PERIOD", "END_PERIOD"));
        }

        #endregion

    }
}
