using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsWeekRange : BusinessObjectBase
    {
        public enum clsWeekRangeFields
        {
            WeekRangeID,
            StartWeek,
            EndWeek,
            EmpID,
            Status,
            Date_Submitted,
            DateRange
        }

        int _weekRangeID;
        DateTime _startWeek;
        DateTime _endWeek;
        int _empID;
        int _status;
        DateTime _dateSubmitted;
        string _dateRange;
        
        #region StoredProcSetters&Getters

        public int WeekRangeID
        {
            get { return _weekRangeID; }
            set
            {
                if (_weekRangeID != value)
                {
                    _weekRangeID = value;
                    PropertyHasChanged("WeekRangeID");
                }
            }
        }

        public DateTime StartWeek
        {
            get { return _startWeek; }
            set
            {
                if (_startWeek != value)
                {
                    _startWeek = value;
                    PropertyHasChanged("StartWeek");
                }
            }
        }

        public DateTime EndWeek
        {
            get { return _endWeek; }
            set
            {
                if (_endWeek != value)
                {
                    _endWeek = value;
                    PropertyHasChanged("EndWeek");
                }
            }
        }

        public int EmpID
        {
            get { return _empID; }
            set
            {
                if (_empID != value)
                {
                    _empID = value;
                    PropertyHasChanged("EmpID");
                }
            }
        }

        public int Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    PropertyHasChanged("Status");
                }
            }
        }

        public DateTime Date_Submitted
        {
            get { return _dateSubmitted; }
            set
            {
                if (_dateSubmitted != value)
                {
                    _dateSubmitted = value;
                    PropertyHasChanged("Date_Submitted");
                }
            }
        }

        public string DateRange
        {
            get { return _dateRange; }
            set
            {
                if (_dateRange != value)
                {
                    _dateRange = value;
                    PropertyHasChanged("DateRange");
                }
            }
        }

        #endregion

    }
}
