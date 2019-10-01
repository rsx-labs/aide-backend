using System;
using System.Collections.Generic;
using System.Text;

namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsWeeklyTeamStatusReport : BusinessObjectBase
    {
        public enum clsWeeklyTeamStatusReportFields
        {
            WeekRangeID,
            EmployeeID,
            EmployeeName,
            TotalHours,
            Status,
            Date_Submitted,
            DateRange
        }

        int _weekRangeID;
        int _employeeID;
        string _employeeName;
        double totalHours;
        short _status;
        DateTime _dateSubmitted;
        string _dateRange;

        #region Properties

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

        public int EmployeeID
        {
            get { return _employeeID; }
            set
            {
                if (_employeeID != value)
                {
                    _employeeID = value;
                    PropertyHasChanged("EmployeeID");
                }
            }
        }

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

        public double TotalHours
        {
            get { return totalHours; }
            set
            {
                if (totalHours != value)
                {
                    totalHours = value;
                    PropertyHasChanged("TotalHours");
                }
            }
        }

        public short Status
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
