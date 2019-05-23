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

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROJ_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROJ_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@DATE_CREATED", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATE_CREATED));
                sqlCommand.Parameters.Add(new SqlParameter("@START_PERIOD", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.START_PERIOD));
                sqlCommand.Parameters.Add(new SqlParameter("@END_PERIOD", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.END_PERIOD));


                MainConnection.Open();

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

       

        

        

      

        

        #endregion

        #region Private Methods

        #endregion

    }
}
