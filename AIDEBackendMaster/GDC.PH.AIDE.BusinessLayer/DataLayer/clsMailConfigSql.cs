using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
/* By Jester Sanchez */
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    class clsMailConfigSql : DataLayerBase 
    {

         #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsMailConfigSql()
        {
            // Nothing for now.
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Select by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>clsAssignedProjects business object</returns>
        public clsMailConfig GetMailConfig()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetSendCodeConfig]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    clsMailConfig businessObject = new clsMailConfig();

                    PopulateBusinessObjectFromReader(businessObject, dataReader);

                    return businessObject;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsActionLists::SelectActionListByMessage::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsMailConfig businessObject, IDataReader dataReader)
        {
            businessObject.SC_SENDER_EMAIL = dataReader.GetString(dataReader.GetOrdinal(clsMailConfig.clsMailConfigFields.SC_SENDER_EMAIL.ToString()));
            businessObject.SC_SUBJECT = dataReader.GetString(dataReader.GetOrdinal(clsMailConfig.clsMailConfigFields.SC_SUBJECT.ToString()));
            businessObject.SC_BODY = dataReader.GetString(dataReader.GetOrdinal(clsMailConfig.clsMailConfigFields.SC_BODY.ToString()));
            businessObject.SC_PORT = dataReader.GetInt32(dataReader.GetOrdinal(clsMailConfig.clsMailConfigFields.SC_PORT.ToString()));
            businessObject.SC_HOST = dataReader.GetString(dataReader.GetOrdinal(clsMailConfig.clsMailConfigFields.SC_HOST.ToString()));
            businessObject.SC_ENABLE_SSL = dataReader.GetInt32(dataReader.GetOrdinal(clsMailConfig.clsMailConfigFields.SC_ENABLE_SSL.ToString()));
            businessObject.SC_TIMEOUT = dataReader.GetInt32(dataReader.GetOrdinal(clsMailConfig.clsMailConfigFields.SC_TIMEOUT.ToString()));
            businessObject.SC_USE_DFLT_CREDENTIALS = dataReader.GetInt32(dataReader.GetOrdinal(clsMailConfig.clsMailConfigFields.SC_USE_DFLT_CREDENTIALS.ToString()));
            businessObject.SC_SENDER_PASSWORD = dataReader.GetString(dataReader.GetOrdinal(clsMailConfig.clsMailConfigFields.SC_SENDER_PASSWORD.ToString()));
            businessObject.SC_PASSWORD_EXPIRY = dataReader.GetInt32(dataReader.GetOrdinal(clsMailConfig.clsMailConfigFields.SC_PASSWORD_EXPIRY.ToString()));
        }

        #endregion
    }
}
