using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

///////////////////////////////////
//   JHUNELL BARCENAS            //
///////////////////////////////////
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsContacts
    /// </summary>
    class clsLateSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </clsLateSql>
        public clsLateSql()
        {
            // Nothing for now.
        }

        #endregion

        #region Public Methods

        public List<clsLate> sp_GetLate(int empID, int month, int year, int toDisplay)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetLate]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.Int, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, month));
                sqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, year));
                sqlCommand.Parameters.Add(new SqlParameter("@ToDisplay", SqlDbType.Int, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, toDisplay));

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                if (toDisplay == 1)
                {
                    return PopulateObjectsFromReader(dataReader);
                }
                else
                {
                    return PopulateObjectsFromReader2(dataReader);
                }

                
            }
            catch (Exception ex)
            {
                throw new Exception("clsLate::GetLate::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsLate businessObject, IDataReader dataReader)
        {
            businessObject.FIRST_NAME = dataReader.GetString(dataReader.GetOrdinal(clsLate.clsLateFields.FIRST_NAME.ToString()));
            businessObject.STATUS = dataReader.GetInt32(dataReader.GetOrdinal(clsLate.clsLateFields.STATUS.ToString()));
        }

        internal void PopulateBusinessObjectFromReader2(clsLate businessObject, IDataReader dataReader)
        {
            businessObject.MONTH = dataReader.GetString(dataReader.GetOrdinal(clsLate.clsLateFields.MONTH.ToString()));
            businessObject.NUMBER_OF_LATE = dataReader.GetInt32(dataReader.GetOrdinal(clsLate.clsLateFields.NUMBER_OF_LATE.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsContacts</returns>
        internal List<clsLate> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsLate> list = new List<clsLate>();

            while (dataReader.Read())
            {
                clsLate businessObject = new clsLate();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsLate> PopulateObjectsFromReader2(IDataReader dataReader)
        {
            List<clsLate> list = new List<clsLate>();

            while (dataReader.Read())
            {
                clsLate businessObject = new clsLate();
                PopulateBusinessObjectFromReader2(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion

    }
}
///////////////////////////////////
//   AEVAN CAMILLE BATONGBACAL   //
///////////////////////////////////
