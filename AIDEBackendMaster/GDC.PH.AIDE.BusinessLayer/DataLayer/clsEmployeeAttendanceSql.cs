using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
using GDC.PH.AIDE.BusinessLayer.DataLayer;

namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    class clsEmployeeAttendanceSql : DataLayerBase
    {
        #region Constructor

        public clsEmployeeAttendanceSql()
        {

        }
        #endregion

        public List<clsEmployeeAttendance> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_getEmployeeAttendance]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAttendance::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }


        #region Private Methods

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader(clsEmployeeAttendance businessObject, IDataReader dataReader)
        {


            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsEmployeeAttendance.clsEmployeeAttendanceFields.EMP_ID.ToString()));

            businessObject.LAST_NAME = dataReader.GetString(dataReader.GetOrdinal(clsEmployeeAttendance.clsEmployeeAttendanceFields.LAST_NAME.ToString()));

            businessObject.FIRST_NAME = dataReader.GetString(dataReader.GetOrdinal(clsEmployeeAttendance.clsEmployeeAttendanceFields.FIRST_NAME.ToString()));

            businessObject.POSITION = dataReader.GetString(dataReader.GetOrdinal(clsEmployeeAttendance.clsEmployeeAttendanceFields.POSITION.ToString()));
 
            businessObject.MONTH = (byte)dataReader.GetInt16(dataReader.GetOrdinal(clsEmployeeAttendance.clsEmployeeAttendanceFields.MONTH.ToString()));

            businessObject.YEAR = (byte)dataReader.GetInt16(dataReader.GetOrdinal(clsEmployeeAttendance.clsEmployeeAttendanceFields.YEAR.ToString()));

            businessObject.DateNow  = (byte)dataReader.GetInt16(dataReader.GetOrdinal(clsEmployeeAttendance.clsEmployeeAttendanceFields.DateNow.ToString()));

        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsAttendance</returns>
        internal List<clsEmployeeAttendance> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<clsEmployeeAttendance> list = new List<clsEmployeeAttendance>();

            while (dataReader.Read())
            {
                clsEmployeeAttendance businessObject = new clsEmployeeAttendance();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion
    }
}
