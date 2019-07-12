using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    class clsMessageSql : DataLayerBase
    {
         #region Constructor
        /// <summary>
        /// Class constructor
        /// </clsMessageSql>
        public clsMessageSql()
        {
            // Nothing for now.
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsContacts</returns>
        public List<clsMessage> GetMessage(int msg_id,int sec_id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllMessage]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@MESSAGE_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, msg_id));
                sqlCommand.Parameters.Add(new SqlParameter("@SEC_ID", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, sec_id));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsCommendations::sp_GetCommendations::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsMessage businessObject, IDataReader dataReader)
        {     
            businessObject.MESSAGE_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsMessage.clsMessageFields.MESSAGE_DESCR.ToString()));
            businessObject.TITLE = dataReader.GetString(dataReader.GetOrdinal(clsMessage.clsMessageFields.TITLE.ToString()));       
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsContacts</returns>
        internal List<clsMessage> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsMessage> list = new List<clsMessage>();

            while (dataReader.Read())
            {
                clsMessage businessObject = new clsMessage();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion
    }
}
