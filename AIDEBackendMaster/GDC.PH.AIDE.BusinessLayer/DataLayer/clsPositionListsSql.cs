using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    class clsPositionListsSql : DataLayerBase
    {
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </clsCommendationsSql>
        public clsPositionListsSql()
        {
            // Nothing for now.
        }

        #endregion

        #region Public Methods
        #region Position Sql
        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsContacts</returns>
        public List<clsPositionList> GetAllPosition()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllPosition]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderPosition(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsPositionList::clsPositionList::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        #endregion

        #region Permission Sql
        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsContacts</returns>
        public List<clsPermissionList> GetAllPermission()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllPermission]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderPermission(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsPermissionList::clsPermissionList::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        #endregion

        #region Department Sql
        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsContacts</returns>
        public List<clsDepartmentList> GetAllDeparment()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllDepartment]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderDepartment(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsDepartmentList::clsDepartmentList::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        #endregion

        #region Division Sql
        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsDivision</returns>
        public List<clsDivisionList> GetAllDivision()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllDivision]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderDivision(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsDivisionList::clsDivisionList::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        #endregion

        #region Status Sql
        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of clsDivision</returns>
        public List<clsStatusList> GetAllStatus(string statusName)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllStatus]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                sqlCommand.Parameters.Add(new SqlParameter("@STATUSNAME", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, statusName));

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderStatus(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsStatusList::clsStatusList::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        #endregion

        #region Location Sql
        public List<clsLocationList> GetAllLocation()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllLocation]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderLocation(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsLocationList::clsPositionList::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        #endregion

        #region Fiscal Year
        public List<clsFiscalYearList> GetAllFiscalYear()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetFiscalYear]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReaderFY(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("clsFiscalYearList::clsFiscalYearList::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        #endregion

        #endregion

        #region Private Methods
        #region Position Object
        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReaderPosition(clsPositionList businessObject, IDataReader dataReader)
        {
            businessObject.POS_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsPositionList.clsPositionListFields.POS_ID.ToString()));
            businessObject.POS_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsPositionList.clsPositionListFields.POS_DESCR.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsPositionLists</returns>
        internal List<clsPositionList> PopulateObjectsFromReaderPosition(IDataReader dataReader)
        {
            List<clsPositionList> list = new List<clsPositionList>();

            while (dataReader.Read())
            {
                clsPositionList businessObject = new clsPositionList();
                PopulateBusinessObjectFromReaderPosition(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
        #endregion

        #region Permission Object
        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReaderPermission(clsPermissionList businessObject, IDataReader dataReader)
        {
            businessObject.GRP_ID = dataReader.GetInt16(dataReader.GetOrdinal(clsPermissionList.clsPermissionListFields.GRP_ID.ToString()));
            businessObject.GRP_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsPermissionList.clsPermissionListFields.GRP_DESCR.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsPositionLists</returns>
        internal List<clsPermissionList> PopulateObjectsFromReaderPermission(IDataReader dataReader)
        {
            List<clsPermissionList> list = new List<clsPermissionList>();

            while (dataReader.Read())
            {
                clsPermissionList businessObject = new clsPermissionList();
                PopulateBusinessObjectFromReaderPermission(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
        #endregion

        #region Department Object
        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReaderDepartment(clsDepartmentList businessObject, IDataReader dataReader)
        {
            businessObject.DEPT_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsDepartmentList.clsDepartmentListFields.DEPT_ID.ToString()));
            businessObject.DEPT_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsDepartmentList.clsDepartmentListFields.DEPT_DESC.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsPositionLists</returns>
        internal List<clsDepartmentList> PopulateObjectsFromReaderDepartment(IDataReader dataReader)
        {
            List<clsDepartmentList> list = new List<clsDepartmentList>();

            while (dataReader.Read())
            {
                clsDepartmentList businessObject = new clsDepartmentList();
                PopulateBusinessObjectFromReaderDepartment(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
        #endregion

        #region Division Object
        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReaderDivision(clsDivisionList businessObject, IDataReader dataReader)
        {
            businessObject.DIV_ID = dataReader.GetInt16(dataReader.GetOrdinal(clsDivisionList.clsDivisionListFields.DIV_ID.ToString()));
            businessObject.DIV_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsDivisionList.clsDivisionListFields.DIV_DESCR.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsPositionLists</returns>
        internal List<clsDivisionList> PopulateObjectsFromReaderDivision(IDataReader dataReader)
        {
            List<clsDivisionList> list = new List<clsDivisionList>();

            while (dataReader.Read())
            {
                clsDivisionList businessObject = new clsDivisionList();
                PopulateBusinessObjectFromReaderDivision(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
        #endregion

        #region Status Object
        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReaderStatus(clsStatusList businessObject, IDataReader dataReader)
        {
            businessObject.STATUS_ID = dataReader.GetInt16(dataReader.GetOrdinal(clsStatusList.clsStatusListFields.STATUS_ID.ToString()));
            businessObject.STATUS_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsStatusList.clsStatusListFields.STATUS_DESCR.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsStatusLists</returns>
        internal List<clsStatusList> PopulateObjectsFromReaderStatus(IDataReader dataReader)
        {
            List<clsStatusList> list = new List<clsStatusList>();

            while (dataReader.Read())
            {
                clsStatusList businessObject = new clsStatusList();
                PopulateBusinessObjectFromReaderStatus(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
        #endregion

        #region Location Object
        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReaderLocation(clsLocationList businessObject, IDataReader dataReader)
        {
            businessObject.LOCATION_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsLocationList.clsLocationListFields.LOCATION_ID.ToString()));
            businessObject.LOCATION = dataReader.GetString(dataReader.GetOrdinal(clsLocationList.clsLocationListFields.LOCATION.ToString()));
            businessObject.ONSITE_FLG = dataReader.GetInt16(dataReader.GetOrdinal(clsLocationList.clsLocationListFields.ONSITE_FLG.ToString()));
        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsPositionLists</returns>
        internal List<clsLocationList> PopulateObjectsFromReaderLocation(IDataReader dataReader)
        {
            List<clsLocationList> list = new List<clsLocationList>();

            while (dataReader.Read())
            {
                clsLocationList businessObject = new clsLocationList();
                PopulateBusinessObjectFromReaderLocation(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion

        #region Fiscal Year Object
        internal void PopulateBusinessObjectFromReaderFiscalYear(clsFiscalYearList businessObject, IDataReader dataReader)
        {
            businessObject.FISCAL_YEAR = dataReader.GetString(dataReader.GetOrdinal(clsFiscalYearList.clsFiscalYearListFields.FISCAL_YEAR.ToString()));
        }

        internal List<clsFiscalYearList> PopulateObjectsFromReaderFY(IDataReader dataReader)
        {
            List<clsFiscalYearList> list = new List<clsFiscalYearList>();

            while (dataReader.Read())
            {
                clsFiscalYearList businessObject = new clsFiscalYearList();
                PopulateBusinessObjectFromReaderFiscalYear(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }
        #endregion

        #endregion

    }
}
