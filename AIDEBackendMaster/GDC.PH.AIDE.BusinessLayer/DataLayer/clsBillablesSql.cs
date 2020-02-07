using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
	/// <summary>
	/// Data access layer class for clsAttendance
	/// </summary>
	class clsBillablesSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public clsBillablesSql()
		{
			// Nothing for now.
		}

        #endregion

        #region Public Methods

        public List<clsBillables> GetBillableHoursByMonth(int empID, int month, int year, int weekID)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetBillableHoursByMonth]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMPID", empID));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", month));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", year));
                sqlCommand.Parameters.Add(new SqlParameter("@WEEKID", weekID));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsBillability::GetBillableHoursByMonth::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<clsBillables> GetBillableHoursByWeek(int empID, int weekID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetBillableHoursByWeek]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMPID", empID));
                sqlCommand.Parameters.Add(new SqlParameter("@WEEKID", weekID));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsBillables::GetBillableHoursByWeek::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public bool InsertLeaveCredits(int empID, int year)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertLeaveCredits]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMPID", empID));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", year));

                MainConnection.Open();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsBillables::InsertLeaveCredits::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        //public List<clsBillables> GetNonBillableHours(string email, int display, int month, int year)
        //{

        //    SqlCommand sqlCommand = new SqlCommand();
        //    sqlCommand.CommandText = "dbo.[sp_GetNonBillableHours]";
        //    sqlCommand.CommandType = CommandType.StoredProcedure;

        //    // Use connection object of base class
        //    sqlCommand.Connection = MainConnection;

        //    try
        //    {
        //        sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", email));
        //        sqlCommand.Parameters.Add(new SqlParameter("@DISPLAY", display));
        //        sqlCommand.Parameters.Add(new SqlParameter("@MONTH", month));
        //        sqlCommand.Parameters.Add(new SqlParameter("@YEAR", year));

        //        MainConnection.Open();
        //        IDataReader dataReader = sqlCommand.ExecuteReader();
        //        return PopulateObjectsFromReader2(dataReader);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("clsBillables::GetNonBillableHours::Error occured.", ex);
        //    }
        //    finally
        //    {
        //        MainConnection.Close();
        //        sqlCommand.Dispose();
        //    }
        //}

        #endregion

        #region Private Methods

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader(clsBillables businessObject, IDataReader dataReader)
        {
            businessObject.NAME = dataReader.GetString(dataReader.GetOrdinal(clsBillables.clsBillabilityFields.NAME.ToString()));
            businessObject.TOTAL_HOURS = dataReader.GetDouble(dataReader.GetOrdinal(clsBillables.clsBillabilityFields.TOTAL_HOURS.ToString()));
            businessObject.BILL_STATUS = dataReader.GetInt16(dataReader.GetOrdinal(clsBillables.clsBillabilityFields.BILL_STATUS.ToString()));
        }

        //internal void PopulateBusinessObjectFromReader2(clsBillables businessObject, IDataReader dataReader)
        //{
        //    businessObject.EMPID = dataReader.GetInt32(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.EMPID.ToString()));

        //    businessObject.NICK_NAME = (String)dataReader.GetString(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.NICK_NAME.ToString()));

        //    businessObject.VL = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.VL.ToString()));

        //    businessObject.SL = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.SL.ToString()));

        //    businessObject.HOLIDAY = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.HOLIDAY.ToString()));

        //    //businessObject.IBP = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.IBP.ToString()));

        //    businessObject.HALFDAY = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.HALFDAY.ToString()));

        //    businessObject.HALFVL = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.HALFVL.ToString()));

        //    businessObject.HALFSL = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.HALFSL.ToString()));

        //    businessObject.TOTAL = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.TOTAL.ToString()));

        //}

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsBillables</returns>
        /// 
        internal List<clsBillables> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsBillables> list = new List<clsBillables>();

            while (dataReader.Read())
            {
                clsBillables businessObject = new clsBillables();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsBillables> PopulateObjectsFromReader2(IDataReader dataReader)
        {
            List<clsBillables> list = new List<clsBillables>();

            while (dataReader.Read())
            {
                clsBillables businessObject = new clsBillables();
                //PopulateBusinessObjectFromReader2(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion

	}
}
