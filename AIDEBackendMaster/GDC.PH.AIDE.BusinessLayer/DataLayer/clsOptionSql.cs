using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsOption
    /// </summary>
    class clsOptionSql : DataLayerBase
    {
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsOptionSql()
        {
            // Nothing for now.
        }

        #endregion

        #region Public Methods

        public List<clsOption> GetOption(int optionID, int moduleID, int functionID)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetOption]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@OPTION_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, optionID));
                sqlCommand.Parameters.Add(new SqlParameter("@MODULE_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, moduleID));
                sqlCommand.Parameters.Add(new SqlParameter("@FUNCTION_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, functionID));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsOption::GetOption::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsOption businessObject, IDataReader dataReader)
        {
            businessObject.OPTION_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsOption.clsOptionFields.OPTION_ID.ToString()));
            businessObject.VALUE = dataReader.GetString(dataReader.GetOrdinal(clsOption.clsOptionFields.VALUE.ToString()));
            businessObject.MODULE_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsOption.clsOptionFields.MODULE_DESCR.ToString()));
            businessObject.FUNCTION_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsOption.clsOptionFields.FUNCTION_DESCR.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of GetOption</returns>
        /// 
        internal List<clsOption> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsOption> list = new List<clsOption>();

            while (dataReader.Read())
            {
                clsOption businessObject = new clsOption();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion
    }
}
