using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    class clsContributorsSql : DataLayerBase
    {
                #region Constructor

        /// <summary>
        /// Class constructor
        /// </clsCommendationsSql>
        public clsContributorsSql()
        {
            // Nothing for now.
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsContributors</returns>
        public List<clsContributors> GetAllMainContributors(int level)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllContributors]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@LEVEL", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, level));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsContributors::sp_GetAllMainContributor::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(clsContributors businessObject, IDataReader dataReader)
        {
            businessObject.FULL_NAME = dataReader.GetString(dataReader.GetOrdinal(clsContributors.clsContributorsFields.FULL_NAME.ToString()));
            businessObject.DEPARTMENT = dataReader.GetString(dataReader.GetOrdinal(clsContributors.clsContributorsFields.DEPARTMENT.ToString()));
            businessObject.DIVISION = dataReader.GetString(dataReader.GetOrdinal(clsContributors.clsContributorsFields.DIVISION.ToString()));
            businessObject.POSITION = dataReader.GetString(dataReader.GetOrdinal(clsContributors.clsContributorsFields.POSITION.ToString()));
            businessObject.IMAGE_PATH = dataReader.GetString(dataReader.GetOrdinal(clsContributors.clsContributorsFields.IMAGE_PATH.ToString()));

        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsContacts</returns>
        internal List<clsContributors> PopulateObjectsFromReader(IDataReader dataReader)
        {
            List<clsContributors> list = new List<clsContributors>();

            while (dataReader.Read())
            {
                clsContributors businessObject = new clsContributors();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion
    }
}
