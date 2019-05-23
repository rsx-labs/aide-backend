using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsTasks_sp: BusinessObjectBase
    {
        public enum clsTasks_spFields
        {
            EmployeeName,
            LastWeekOutstanding,
            Mon_AT,
            Mon_CT,
            Mon_OT,
            Tue_AT,
            Tue_CT,
            Tue_OT,
            Wed_AT,
            Wed_CT,
            Wed_OT,
            Thu_AT,
            Thu_CT,
            Thu_OT,
            Fri_AT,
            Fri_CT,
            Fri_OT
        }

        string _employeeName;
        int _lastWeekOutstanding;
        int _mon_AT;
        int _mon_CT;
        int _mon_OT;
        int _tue_AT;
        int _tue_CT;
        int _tue_OT;
        int _wed_AT;
        int _wed_CT;
        int _wed_OT;
        int _thu_AT;
        int _thu_CT;
        int _thu_OT;
        int _fri_AT;
        int _fri_CT;
        int _fri_OT;

        #region StoredProcSetters&Getters

        public string EmployeeName
        {
            get { return _employeeName; }
            set
            {
                if (_employeeName != value)
                {
                    _employeeName = value;
                    PropertyHasChanged("EmployeeName");
                }
            }
        }

        public int LastWeekOutstanding
        {
            get { return _lastWeekOutstanding; }
            set
            {
                if (_lastWeekOutstanding != value)
                {
                    _lastWeekOutstanding = value;
                    PropertyHasChanged("LastWeekOutstanding");
                }
            }
        }

        public int Mon_AT
        {
            get { return _mon_AT; }
            set
            {
                if (_mon_AT != value)
                {
                    _mon_AT = value;
                    PropertyHasChanged("Mon_AT");
                }
            }
        }

        public int Mon_CT
        {
            get { return _mon_CT; }
            set
            {
                if (_mon_CT != value)
                {
                    _mon_CT = value;
                    PropertyHasChanged("Mon_CT");
                }
            }
        }

        public int Mon_OT
        {
            get { return _mon_OT; }
            set
            {
                if (_mon_OT != value)
                {
                    _mon_OT = value;
                    PropertyHasChanged("Mon_OT");
                }
            }
        }

        public int Tue_AT
        {
            get { return _tue_AT; }
            set
            {
                if (_tue_AT != value)
                {
                    _tue_AT = value;
                    PropertyHasChanged("Tue_AT");
                }
            }
        }

        public int Tue_CT
        {
            get { return _tue_CT; }
            set
            {
                if (_tue_CT != value)
                {
                    _tue_CT = value;
                    PropertyHasChanged("Tue_CT");
                }
            }
        }

        public int Tue_OT
        {
            get { return _tue_OT; }
            set
            {
                if (_tue_OT != value)
                {
                    _tue_OT = value;
                    PropertyHasChanged("Tue_OT");
                }
            }
        }

        public int Wed_AT
        {
            get { return _wed_AT; }
            set
            {
                if (_wed_AT != value)
                {
                    _wed_AT = value;
                    PropertyHasChanged("Wed_AT");
                }
            }
        }

        public int Wed_CT
        {
            get { return _wed_CT; }
            set
            {
                if (_wed_CT != value)
                {
                    _wed_CT = value;
                    PropertyHasChanged("Wed_CT");
                }
            }
        }

        public int Wed_OT
        {
            get { return _wed_OT; }
            set
            {
                if (_wed_OT != value)
                {
                    _wed_OT = value;
                    PropertyHasChanged("Wed_OT");
                }
            }
        }

        public int Thu_AT
        {
            get { return _thu_AT; }
            set
            {
                if (_thu_AT != value)
                {
                    _thu_AT = value;
                    PropertyHasChanged("Thu_AT");
                }
            }
        }

        public int Thu_CT
        {
            get { return _thu_CT; }
            set
            {
                if (_thu_CT != value)
                {
                    _thu_CT = value;
                    PropertyHasChanged("Thu_CT");
                }
            }
        }

        public int Thu_OT
        {
            get { return _thu_OT; }
            set
            {
                if (_thu_OT != value)
                {
                    _thu_OT = value;
                    PropertyHasChanged("Thu_OT");
                }
            }
        }

        public int Fri_AT
        {
            get { return _fri_AT; }
            set
            {
                if (_fri_AT != value)
                {
                    _fri_AT = value;
                    PropertyHasChanged("Fri_AT");
                }
            }
        }

        public int Fri_CT
        {
            get { return _fri_CT; }
            set
            {
                if (_fri_CT != value)
                {
                    _fri_CT = value;
                    PropertyHasChanged("Fri_CT");
                }
            }
        }

        public int Fri_OT
        {
            get { return _fri_OT; }
            set
            {
                if (_fri_OT != value)
                {
                    _fri_OT = value;
                    PropertyHasChanged("Fri_OT");
                }
            }
        }

        #endregion

    }
}
