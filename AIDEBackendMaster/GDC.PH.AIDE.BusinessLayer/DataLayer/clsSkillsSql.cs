using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    class clsSkillsSql : DataLayerBase
    {
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public clsSkillsSql()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// insert new row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true of successfully insert</returns>
        public bool InsertSkillsProf(clsSkills businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertSkillsProf]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@SKILL_ID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SKILL_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROF_LVL", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROF_LVL));
                sqlCommand.Parameters.Add(new SqlParameter("@LAST_REVIEWED", SqlDbType.Date, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LAST_REVIEWED));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsSkills::Insert::Error occured.", ex);
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
        public bool UpdateSkills(clsSkills businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateSkillsProfByEmpId]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@SKILL_ID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SKILL_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROF_LVL", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROF_LVL));
                sqlCommand.Parameters.Add(new SqlParameter("@LAST_REVIEWED", SqlDbType.Date, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LAST_REVIEWED));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsSkills::Update::Error occured.", ex);
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
        /// <returns>clsContacts business object</returns>
        public clsSkills GetSkillsProfByEmpID(clsSkillsKeys keys)
        {
            SqlDataAdapter da;
            DataTable dt;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetSkillsProfByEmpID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(sqlCommand);
            dt = new DataTable();
            da.Fill(dt);
            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.EMP_ID));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    clsSkills businessObject = new clsSkills();

                    PopulateBusinessObjectSkillsFromReader2(businessObject, dataReader);

                    return businessObject;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsSkills::GetSkillsProfByEmpID::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public clsSkills GetProfLvlByEmpIDSkillID(int empID, int skillID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetSkillIDByEmpID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@SKILL_ID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, skillID));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    clsSkills businessObject = new clsSkills();

                    PopulateBusinessObjectSkillsFromReader4(businessObject, dataReader);

                    return businessObject;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsSkills::GetSkillIDByEmpID::Error occured.", ex);
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
        /// <returns>list of clsContacts</returns>
        public List<clsSkills> SelectSkillList()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetSkillsList]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;
            try
            {
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsSkillsFromReader(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsSkills::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }


        public List<clsSkills> GetSkillsProfByEmpID(int id)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetSkillsProfByEmpID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, id));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsSkillsFromReader2(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsSkills::GetSkillsProfByEmpID::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsSkills> ViewEmployeeSkills(int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_EmployeeSkillsByDeptID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@empID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsSkillsFromReader2(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsSkills::ViewEmployeeSkills::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public clsSkills GetSkillsLastReviewByEmpIDSkillID(int empID, int skillID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetSkillsLastReviewByEmpIDSkillID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                sqlCommand.Parameters.Add(new SqlParameter("@SKILL_ID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, skillID));
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    clsSkills businessObject = new clsSkills();

                    PopulateBusinessObjectSkillsFromReader6(businessObject, dataReader);

                    return businessObject;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsSkills::GetSkillsLastReviewByEmpIDSkillID::Error occured.", ex);
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
        internal void PopulateBusinessObjectSkillsFromReader(clsSkills businessObject, IDataReader dataReader)
        {
            //if (!dataReader.IsDBNull(dataReader.GetOrdinal((clsSkills.clsSkillsFields.SKILL_ID.ToString()))))
            //{
            //    businessObject.SKILL_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsSkills.clsSkillsFields.SKILL_ID.ToString()));
            //}
            //if (!dataReader.IsDBNull(dataReader.GetOrdinal((clsSkills.clsSkillsFields.DESCR.ToString()))))
            //{
            //    businessObject.DESCR = dataReader.GetString(dataReader.GetOrdinal(clsSkills.clsSkillsFields.DESCR.ToString()));
            //}
            //if (!dataReader.IsDBNull(dataReader.GetOrdinal((clsSkills.clsSkillsFields.EMP_ID.ToString()))))
            //{
            //    businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsSkills.clsSkillsFields.EMP_ID.ToString()));
            //}
            businessObject.SKILL_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsSkills.clsSkillsFields.SKILL_ID.ToString()));
            businessObject.DESCR = dataReader.GetString(dataReader.GetOrdinal(clsSkills.clsSkillsFields.DESCR.ToString()));
        }

        internal void PopulateBusinessObjectSkillsFromReader2(clsSkills businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsSkills.clsSkillsFields.EMP_ID.ToString()));
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsSkills.clsSkillsFields.EMPLOYEE_NAME.ToString()));
            businessObject.PROF_LVL = dataReader.GetInt32(dataReader.GetOrdinal(clsSkills.clsSkillsFields.PROF_LVL.ToString()));
            businessObject.DESCR = dataReader.GetString(dataReader.GetOrdinal(clsSkills.clsSkillsFields.DESCR.ToString()));
            businessObject.LAST_REVIEWED = dataReader.GetDateTime(dataReader.GetOrdinal(clsSkills.clsSkillsFields.LAST_REVIEWED.ToString()));
        }

        internal void PopulateBusinessObjectSkillsFromReader3(clsSkills businessObject, IDataReader dataReader)
        {
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsSkills.clsSkillsFields.EMPLOYEE_NAME.ToString()));
            businessObject.PROF_LVL = dataReader.GetInt32(dataReader.GetOrdinal(clsSkills.clsSkillsFields.PROF_LVL.ToString()));
            businessObject.SKILL_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsSkills.clsSkillsFields.SKILL_ID.ToString()));
            businessObject.LAST_REVIEWED = dataReader.GetDateTime(dataReader.GetOrdinal(clsSkills.clsSkillsFields.LAST_REVIEWED.ToString()));
        }
        internal void PopulateBusinessObjectSkillsFromReader4(clsSkills businessObject, IDataReader dataReader)
        {
            businessObject.PROF_LVL = dataReader.GetInt32(dataReader.GetOrdinal(clsSkills.clsSkillsFields.PROF_LVL.ToString()));
        }

        internal void PopulateBusinessObjectSkillsFromReader5(clsSkills businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsSkills.clsSkillsFields.EMP_ID.ToString()));
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsSkills.clsSkillsFields.EMPLOYEE_NAME.ToString()));
            businessObject.IMAGE_PATH = dataReader.GetString(dataReader.GetOrdinal(clsSkills.clsSkillsFields.IMAGE_PATH.ToString()));
            //businessObject.DESCR = dataReader.GetString(dataReader.GetOrdinal(clsSkills.clsSkillsFields.DESCR.ToString()));
        }

        internal void PopulateBusinessObjectSkillsFromReader6(clsSkills businessObject, IDataReader dataReader)
        {
            businessObject.PROF_LVL = dataReader.GetInt32(dataReader.GetOrdinal(clsSkills.clsSkillsFields.PROF_LVL.ToString()));
            businessObject.LAST_REVIEWED = dataReader.GetDateTime(dataReader.GetOrdinal(clsSkills.clsSkillsFields.LAST_REVIEWED.ToString()));
        }
        
        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of clsSkills</returns>
        internal List<clsSkills> PopulateObjectsSkillsFromReader(IDataReader dataReader)
        {
            List<clsSkills> list = new List<clsSkills>();

            while (dataReader.Read())
            {
                clsSkills businessObject = new clsSkills();
                PopulateBusinessObjectSkillsFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal List<clsSkills> PopulateObjectsSkillsFromReader2(IDataReader dataReader)
        {
            List<clsSkills> list = new List<clsSkills>();

            while (dataReader.Read())
            {
                clsSkills businessObject = new clsSkills();
                PopulateBusinessObjectSkillsFromReader2(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        #endregion
    }
}
