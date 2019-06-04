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
            DateCreated,
            DateRange
        }

        int _weekRangeID;
        DateTime _startWeek;
        DateTime _endWeek;
        DateTime _dateCreated;
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

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if (_dateCreated != value)
                {
                    _dateCreated = value;
                    PropertyHasChanged("DateCreated");
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
