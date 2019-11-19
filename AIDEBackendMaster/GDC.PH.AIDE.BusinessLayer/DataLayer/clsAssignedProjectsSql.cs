using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// BY GIANN CARLO CAMILO
/// </summary>
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for clsAssignedProjects
    /// </summary>
    class clsAssignedProjectsSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsAssignedProjectsSql()
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
        public bool Insert(clsAssignedProjects businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_insertAssignedProjects]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROJ_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_CREATED", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_CREATED));
                sqlCommand.Parameters.Add(new SqlParameter("@START_PERIOD", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.START_PERIOD));
                sqlCommand.Parameters.Add(new SqlParameter("@END_PERIOD", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.END_PERIOD));


                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsAssignedProjects::Insert::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// insert new row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true of successfully delete</returns>
        public List<clsAssignedProjects> GetAssignedProjects(int projId)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.sp_GetAssignedProjectsByProjectId";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, projId));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsAssignedProjects::GetAssignedProjects::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// insert new row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true of successfully delete</returns>
        public bool Delete(int empID, int projectId)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.sp_DeleteAssignedProjects";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, projectId));
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsAssignedProjects::Delete::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }


        /// <summary>
        /// insert new row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true of successfully delete</returns>
        public bool DeleteAll(int projectId)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.sp_DeleteAllAssignedProjects";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, projectId));


                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsAssignedProjects::DeleteAll::Error occured.", ex);
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
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsAssignedProjects</returns>
        internal List<clsAssignedProjects> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsAssignedProjects> list = new List<clsAssignedProjects>();

            while (dataReader.Read())
            {
                clsAssignedProjects businessObject = new clsAssignedProjects();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader(clsAssignedProjects businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAssignedProjects.clsAssignedProjectsFields.EMP_ID.ToString()));
            businessObject.EMPLOYEENAME = dataReader.GetString(dataReader.GetOrdinal(clsAssignedProjects.clsAssignedProjectsFields.EMPLOYEENAME.ToString()));
            businessObject.PROJ_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsAssignedProjects.clsAssignedProjectsFields.PROJ_ID.ToString()));
            businessObject.PROJ_NAME = dataReader.GetString(dataReader.GetOrdinal(clsAssignedProjects.clsAssignedProjectsFields.PROJ_NAME.ToString()));
            businessObject.DATE_CREATED = dataReader.GetDateTime(dataReader.GetOrdinal(clsAssignedProjects.clsAssignedProjectsFields.DATE_CREATED.ToString()));
            businessObject.START_PERIOD = dataReader.GetDateTime(dataReader.GetOrdinal(clsAssignedProjects.clsAssignedProjectsFields.START_PERIOD.ToString()));
            businessObject.END_PERIOD = dataReader.GetDateTime(dataReader.GetOrdinal(clsAssignedProjects.clsAssignedProjectsFields.END_PERIOD.ToString()));

        }

        #endregion

    }
}
