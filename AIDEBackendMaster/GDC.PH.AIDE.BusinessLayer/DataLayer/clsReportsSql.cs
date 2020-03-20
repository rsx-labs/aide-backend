using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;
/* By Jester Sanchez */
namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    class clsReportsSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsReportsSql()
        {
            // Nothing for now.
        }

        #endregion

        #region Public Methods

       
        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsAssignedProjects</returns>
        public List<clsReports> GetAllReports()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllReports]";
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
                throw new Exception("clsReports::SelectAllSabaCourses::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsReports businessObject, IDataReader dataReader)
        {

            businessObject.REPORT_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsReports.clsReportsFields.REPORT_ID.ToString()));

            businessObject.OPT_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsReports.clsReportsFields.OPT_ID.ToString()));

            businessObject.MODULE_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsReports.clsReportsFields.MODULE_ID.ToString()));

            businessObject.DESCRIPTION = dataReader.GetString(dataReader.GetOrdinal(clsReports.clsReportsFields.DESCRIPTION.ToString()));

            businessObject.FILE_PATH = dataReader.GetString(dataReader.GetOrdinal(clsReports.clsReportsFields.FILE_PATH.ToString()));

        }


        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsAssignedProjects</returns>
        internal List<clsReports> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<clsReports> list = new List<clsReports>();

            while (dataReader.Read())
            {
                clsReports businessObject = new clsReports();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion
    }
}
