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


        public List<clsBillables> sp_getBillabilityHoursAll(clsBillablesKeys keys)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_getBillabilityHoursAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@dateStart", keys.DATESTART));
                sqlCommand.Parameters.Add(new SqlParameter("@dateFinish", keys.DATEFINISH));
                sqlCommand.Parameters.Add(new SqlParameter("@userChoice", keys.USERCHOICE));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAttendance::sp_getBillabilityHoursAll::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }


        public List<clsBillables> sp_getBillabilityHoursByEmpID(clsBillablesKeys keys)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_getBillabilityHoursByEmpID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@empID", keys.EMPID));
                sqlCommand.Parameters.Add(new SqlParameter("@dateStart", keys.DATESTART));
                sqlCommand.Parameters.Add(new SqlParameter("@dateFinish", keys.DATEFINISH));
                sqlCommand.Parameters.Add(new SqlParameter("@userChoice", keys.USERCHOICE));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAttendance::sp_getBillabilityHoursByEmpID::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<clsBillables> sp_getBillableSummary(clsBillablesKeys keys)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_getBillableSummary]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@Month", keys.MONTH));
                sqlCommand.Parameters.Add(new SqlParameter("@Year", keys.YEAR));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader2(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAttendance::sp_getBillableSummary::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }



        #endregion

        #region Private Methods

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader(clsBillables businessObject, IDataReader dataReader)
        {
				businessObject.EMPID = dataReader.GetInt32(dataReader.GetOrdinal(clsBillables.clsAttendanceFields.EMPID.ToString()));

                businessObject.MONTH = dataReader.GetInt32(dataReader.GetOrdinal(clsBillables.clsAttendanceFields.MONTH.ToString()));

                businessObject.YEAR = dataReader.GetInt32(dataReader.GetOrdinal(clsBillables.clsAttendanceFields.YEAR.ToString()));

            	businessObject.HOURS = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceFields.HOURS.ToString()));

                businessObject.NICK_NAME = (String)dataReader.GetString(dataReader.GetOrdinal(clsBillables.clsAttendanceFields.NICK_NAME.ToString()));
        }

        internal void PopulateBusinessObjectFromReader2(clsBillables businessObject, IDataReader dataReader)
        {
            businessObject.EMPID = dataReader.GetInt32(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.EMPID.ToString()));

            businessObject.NICK_NAME = (String)dataReader.GetString(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.NICK_NAME.ToString()));

            businessObject.VL = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.VL.ToString()));

            businessObject.SL = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.SL.ToString()));

            businessObject.HOLIDAY = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.HOLIDAY.ToString()));

            //businessObject.IBP = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.IBP.ToString()));

            businessObject.HALFDAY = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.HALFDAY.ToString()));

            businessObject.HALFVL = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.HALFVL.ToString()));

            businessObject.HALFSL = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.HALFSL.ToString()));

            businessObject.TOTAL = dataReader.GetDecimal(dataReader.GetOrdinal(clsBillables.clsAttendanceSummaryFields.TOTAL.ToString()));



        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsAttendance</returns>
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
                PopulateBusinessObjectFromReader2(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
