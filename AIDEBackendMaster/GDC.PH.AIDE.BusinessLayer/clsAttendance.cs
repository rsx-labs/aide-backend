using System;
using System.Collections.Generic;
using System.Text;
namespace GDC.PH.AIDE.BusinessLayer
{
    public class clsAttendance : BusinessObjectBase
    {

        #region InnerClass
        public enum clsAttendanceFields
        {
            EMP_ID,
            EMPLOYEE_NAME,
            DESCR,
            IMAGE_PATH,
            STATUS,
            DATE_ENTRY,
            MONTH,
            YEAR,
            DAY1,
            DAY2,
            DAY3,
            DAY4,
            DAY5,
            DAY6,
            DAY7,
            DAY8,
            DAY9,
            DAY10,
            DAY11,
            DAY12,
            DAY13,
            DAY14,
            DAY15,
            DAY16,
            DAY17,
            DAY18,
            DAY19,
            DAY20,
            DAY21,
            DAY22,
            DAY23,
            DAY24,
            DAY25,
            DAY26,
            DAY27,
            DAY28,
            DAY29,
            DAY30,
            DAY31
        }

        public enum clsAttendanceFieldsWeekly
        {
            EMP_ID,
            EMP_NAME,
            MONDAY,
            TUESDAY,
            WEDNESDAY,
            THURSDAY,
            FRIDAY
        }
        #endregion

        #region Data Members

        int _eMP_ID;
        string _eMP_NAME;
        string _descr;
        int _status;
        string imagePath;
        DateTime date_entry;

        byte _mONTH;
        short _yEAR;
        byte? _dAY1;
        byte? _dAY2;
        byte? _dAY3;
        byte? _dAY4;
        byte? _dAY5;
        byte? _dAY6;
        byte? _dAY7;
        byte? _dAY8;
        byte? _dAY9;
        byte? _dAY10;
        byte? _dAY11;
        byte? _dAY12;
        byte? _dAY13;
        byte? _dAY14;
        byte? _dAY15;
        byte? _dAY16;
        byte? _dAY17;
        byte? _dAY18;
        byte? _dAY19;
        byte? _dAY20;
        byte? _dAY21;
        byte? _dAY22;
        byte? _dAY23;
        byte? _dAY24;
        byte? _dAY25;
        byte? _dAY26;
        byte? _dAY27;
        byte? _dAY28;
        byte? _dAY29;
        byte? _dAY30;
        byte? _dAY31;
        byte? _monday;
        byte? _tuesday;
        byte? _wednesday;
        byte? _thursday;
        byte? _friday;


        #endregion

        #region Properties


        public DateTime DATE_ENTRY
        {
            get { return date_entry; }
            set
            {
                if (date_entry != value)
                {
                    date_entry = value;
                    PropertyHasChanged("DATE_ENTRY");
                }
            }
        }
        
        public string IMAGE_PATH
        {
            get { return imagePath; }
            set
            {
                if (imagePath != value)
                {
                    imagePath = value;
                    PropertyHasChanged("IMAGE_PATH");
                }
            }
        }

        public string DESCR
        {
            get { return _descr; }
            set
            {
                if (_descr != value)
                {
                    _descr = value;
                    PropertyHasChanged("DESCR");
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

        public string EMPLOYEE_NAME
        {
            get { return _eMP_NAME; }
            set
            {
                if (_eMP_NAME != value)
                {
                    _eMP_NAME = value;
                    PropertyHasChanged("EMPLOYEE_NAME");
                }
            }
        }

        public byte MONTH
        {
            get { return _mONTH; }
            set
            {
                if (_mONTH != value)
                {
                    _mONTH = value;
                    PropertyHasChanged("MONTH");
                }
            }
        }

        public short YEAR
        {
            get { return _yEAR; }
            set
            {
                if (_yEAR != value)
                {
                    _yEAR = value;
                    PropertyHasChanged("YEAR");
                }
            }
        }

        public byte? DAY1
        {
            get { return _dAY1; }
            set
            {
                if (_dAY1 != value)
                {
                    _dAY1 = value;
                    PropertyHasChanged("DAY1");
                }
            }
        }

        public byte? DAY2
        {
            get { return _dAY2; }
            set
            {
                if (_dAY2 != value)
                {
                    _dAY2 = value;
                    PropertyHasChanged("DAY2");
                }
            }
        }

        public byte? DAY3
        {
            get { return _dAY3; }
            set
            {
                if (_dAY3 != value)
                {
                    _dAY3 = value;
                    PropertyHasChanged("DAY3");
                }
            }
        }

        public byte? DAY4
        {
            get { return _dAY4; }
            set
            {
                if (_dAY4 != value)
                {
                    _dAY4 = value;
                    PropertyHasChanged("DAY4");
                }
            }
        }

        public byte? DAY5
        {
            get { return _dAY5; }
            set
            {
                if (_dAY5 != value)
                {
                    _dAY5 = value;
                    PropertyHasChanged("DAY5");
                }
            }
        }

        public byte? DAY6
        {
            get { return _dAY6; }
            set
            {
                if (_dAY6 != value)
                {
                    _dAY6 = value;
                    PropertyHasChanged("DAY6");
                }
            }
        }

        public byte? DAY7
        {
            get { return _dAY7; }
            set
            {
                if (_dAY7 != value)
                {
                    _dAY7 = value;
                    PropertyHasChanged("DAY7");
                }
            }
        }

        public byte? DAY8
        {
            get { return _dAY8; }
            set
            {
                if (_dAY8 != value)
                {
                    _dAY8 = value;
                    PropertyHasChanged("DAY8");
                }
            }
        }

        public byte? DAY9
        {
            get { return _dAY9; }
            set
            {
                if (_dAY9 != value)
                {
                    _dAY9 = value;
                    PropertyHasChanged("DAY9");
                }
            }
        }

        public byte? DAY10
        {
            get { return _dAY10; }
            set
            {
                if (_dAY10 != value)
                {
                    _dAY10 = value;
                    PropertyHasChanged("DAY10");
                }
            }
        }

        public byte? DAY11
        {
            get { return _dAY11; }
            set
            {
                if (_dAY11 != value)
                {
                    _dAY11 = value;
                    PropertyHasChanged("DAY11");
                }
            }
        }

        public byte? DAY12
        {
            get { return _dAY12; }
            set
            {
                if (_dAY12 != value)
                {
                    _dAY12 = value;
                    PropertyHasChanged("DAY12");
                }
            }
        }

        public byte? DAY13
        {
            get { return _dAY13; }
            set
            {
                if (_dAY13 != value)
                {
                    _dAY13 = value;
                    PropertyHasChanged("DAY13");
                }
            }
        }

        public byte? DAY14
        {
            get { return _dAY14; }
            set
            {
                if (_dAY14 != value)
                {
                    _dAY14 = value;
                    PropertyHasChanged("DAY14");
                }
            }
        }

        public byte? DAY15
        {
            get { return _dAY15; }
            set
            {
                if (_dAY15 != value)
                {
                    _dAY15 = value;
                    PropertyHasChanged("DAY15");
                }
            }
        }

        public byte? DAY16
        {
            get { return _dAY16; }
            set
            {
                if (_dAY16 != value)
                {
                    _dAY16 = value;
                    PropertyHasChanged("DAY16");
                }
            }
        }

        public byte? DAY17
        {
            get { return _dAY17; }
            set
            {
                if (_dAY17 != value)
                {
                    _dAY17 = value;
                    PropertyHasChanged("DAY17");
                }
            }
        }

        public byte? DAY18
        {
            get { return _dAY18; }
            set
            {
                if (_dAY18 != value)
                {
                    _dAY18 = value;
                    PropertyHasChanged("DAY18");
                }
            }
        }

        public byte? DAY19
        {
            get { return _dAY19; }
            set
            {
                if (_dAY19 != value)
                {
                    _dAY19 = value;
                    PropertyHasChanged("DAY19");
                }
            }
        }

        public byte? DAY20
        {
            get { return _dAY20; }
            set
            {
                if (_dAY20 != value)
                {
                    _dAY20 = value;
                    PropertyHasChanged("DAY20");
                }
            }
        }

        public byte? DAY21
        {
            get { return _dAY21; }
            set
            {
                if (_dAY21 != value)
                {
                    _dAY21 = value;
                    PropertyHasChanged("DAY21");
                }
            }
        }

        public byte? DAY22
        {
            get { return _dAY22; }
            set
            {
                if (_dAY22 != value)
                {
                    _dAY22 = value;
                    PropertyHasChanged("DAY22");
                }
            }
        }

        public byte? DAY23
        {
            get { return _dAY23; }
            set
            {
                if (_dAY23 != value)
                {
                    _dAY23 = value;
                    PropertyHasChanged("DAY23");
                }
            }
        }

        public byte? DAY24
        {
            get { return _dAY24; }
            set
            {
                if (_dAY24 != value)
                {
                    _dAY24 = value;
                    PropertyHasChanged("DAY24");
                }
            }
        }

        public byte? DAY25
        {
            get { return _dAY25; }
            set
            {
                if (_dAY25 != value)
                {
                    _dAY25 = value;
                    PropertyHasChanged("DAY25");
                }
            }
        }

        public byte? DAY26
        {
            get { return _dAY26; }
            set
            {
                if (_dAY26 != value)
                {
                    _dAY26 = value;
                    PropertyHasChanged("DAY26");
                }
            }
        }

        public byte? DAY27
        {
            get { return _dAY27; }
            set
            {
                if (_dAY27 != value)
                {
                    _dAY27 = value;
                    PropertyHasChanged("DAY27");
                }
            }
        }

        public byte? DAY28
        {
            get { return _dAY28; }
            set
            {
                if (_dAY28 != value)
                {
                    _dAY28 = value;
                    PropertyHasChanged("DAY28");
                }
            }
        }

        public byte? DAY29
        {
            get { return _dAY29; }
            set
            {
                if (_dAY29 != value)
                {
                    _dAY29 = value;
                    PropertyHasChanged("DAY29");
                }
            }
        }

        public byte? DAY30
        {
            get { return _dAY30; }
            set
            {
                if (_dAY30 != value)
                {
                    _dAY30 = value;
                    PropertyHasChanged("DAY30");
                }
            }
        }

        public byte? DAY31
        {
            get { return _dAY31; }
            set
            {
                if (_dAY31 != value)
                {
                    _dAY31 = value;
                    PropertyHasChanged("DAY31");
                }
            }
        }

        public byte? MONDAY
        {
            get { return _monday; }
            set
            {
                if (_monday != value)
                {
                    _monday = value;
                    PropertyHasChanged("MONDAY");
                }
            }
        }

        public byte? TUESDAY
        {
            get { return _tuesday; }
            set
            {
                if (_tuesday != value)
                {
                    _tuesday = value;
                    PropertyHasChanged("TUESDAY");
                }
            }
        }

        public byte? WEDNESDAY
        {
            get { return _wednesday; }
            set
            {
                if (_wednesday != value)
                {
                    _wednesday = value;
                    PropertyHasChanged("WEDNESDAY");
                }
            }
        }

        public byte? THURSDAY
        {
            get { return _thursday; }
            set
            {
                if (_thursday != value)
                {
                    _thursday = value;
                    PropertyHasChanged("THURSDAY");
                }
            }
        }

        public byte? FRIDAY
        {
            get { return _friday; }
            set
            {
                if (_friday != value)
                {
                    _friday = value;
                    PropertyHasChanged("FRIDAY");
                }
            }
        }

        #endregion

        #region Validation

        internal override void AddValidationRules()
        {
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("EMP_ID", "EMP_ID"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("MONTH", "MONTH"));
            ValidationRules.AddRules(new Validation.ValidateRuleNotNull("YEAR", "YEAR"));
        }

        #endregion

    }
}
