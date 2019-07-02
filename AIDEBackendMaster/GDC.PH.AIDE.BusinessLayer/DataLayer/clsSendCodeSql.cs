using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
/* By Jester Sanchez */
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    class clsSendCodeSql : DataLayerBase
    {

         #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsSendCodeSql()
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
        public clsSendCode SelectWorkEmailbyEmail(clsSendCodeKey keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetEmployeeEmail]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.SEND_CODE_EMAIL_ADDRESS));

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    clsSendCode businessObject = new clsSendCode();

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
        internal void PopulateBusinessObjectFromReader(clsSendCode businessObject, IDataReader dataReader)
        {

            businessObject.WORK_EMAIL = dataReader.GetString(dataReader.GetOrdinal(clsSendCode.clsSendCodeFields.WORK_EMAIL.ToString()));

            businessObject.FNAME = dataReader.GetString(dataReader.GetOrdinal(clsSendCode.clsSendCodeFields.FNAME.ToString()));

            businessObject.LNAME = dataReader.GetString(dataReader.GetOrdinal(clsSendCode.clsSendCodeFields.LNAME.ToString()));

        }


        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsAssignedProjects</returns>
        internal List<clsSendCode> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<clsSendCode> lists = new List<clsSendCode>();

            while (dataReader.Read())
            {
               clsSendCode businessObject = new clsSendCode();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                lists.Add(businessObject);
            }
            return lists;

        }

        #endregion

    }
}
