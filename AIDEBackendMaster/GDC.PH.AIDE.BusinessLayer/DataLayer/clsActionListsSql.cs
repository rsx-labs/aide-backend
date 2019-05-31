using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
/* By Jester Sanchez */
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    class clsActionListsSql : DataLayerBase
    {
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsActionListsSql()
        {
            // Nothing for now.
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// insert new row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true of successfully insert</returns>
        public bool Insert(clsActionLists businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertActionList]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@REFERENCE", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTREF));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTION_TEXT", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACT_MESSAGE));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTION_ASSIGNEE", SqlDbType.Int, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTION_DUE_DATE", SqlDbType.DateTime, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DUE_DATE));
                sqlCommand.Parameters.Add(new SqlParameter("@NICK_NAME", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.NICK_NAME));
               

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsActionLists::Insert::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(clsActionLists businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateActionLists]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@REFERENCE", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTREF));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTION_TEXT", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACT_MESSAGE));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTION_ASSIGNEE", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTION_DUE_DATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DUE_DATE));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTION_DATE_CLOSED", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_CLOSED));
                sqlCommand.Parameters.Add(new SqlParameter("@NICK_NAME", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.NICK_NAME));
               
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsActionLists::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Select by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>clsAssignedProjects business object</returns>
        public List<clsActionLists> SelectActionListByMessage(clsActionListsKeys keys, string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetActionListsMessage]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                sqlCommand.Parameters.Add(new SqlParameter("@MESSAGE", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.ACT_Message));

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader(dataReader);
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

        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsAssignedProjects</returns>
        public List<clsActionLists> SelectAllActionLists(string email)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetActionListsAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, email));
                
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsActionLists::SelectAllActionLists::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsActionLists businessObject, IDataReader dataReader)
        {

            businessObject.ACTREF = dataReader.GetString(dataReader.GetOrdinal(clsActionLists.clsActionListsFields.ACTREF.ToString()));

            businessObject.ACT_MESSAGE = dataReader.GetString(dataReader.GetOrdinal(clsActionLists.clsActionListsFields.ACT_MESSAGE.ToString()));

            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsActionLists.clsActionListsFields.EMP_ID.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsActionLists.clsActionListsFields.NICK_NAME.ToString())))
            {
                businessObject.NICK_NAME = dataReader.GetString(dataReader.GetOrdinal(clsActionLists.clsActionListsFields.NICK_NAME.ToString()));
            }
            else
            {
                businessObject.NICK_NAME = "";
            }

            businessObject.DUE_DATE = dataReader.GetDateTime(dataReader.GetOrdinal(clsActionLists.clsActionListsFields.DUE_DATE.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(clsActionLists.clsActionListsFields.DATE_CLOSED.ToString())))
            {
                businessObject.DATE_CLOSED = dataReader.GetString(dataReader.GetOrdinal(clsActionLists.clsActionListsFields.DATE_CLOSED.ToString()));
            }

        }


        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsAssignedProjects</returns>
        internal List<clsActionLists> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<clsActionLists> list = new List<clsActionLists>();

            while (dataReader.Read())
            {
                clsActionLists businessObject = new clsActionLists();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion
    }
}
