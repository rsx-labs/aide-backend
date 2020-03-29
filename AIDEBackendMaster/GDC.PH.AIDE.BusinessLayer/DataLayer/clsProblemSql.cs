using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GDC.PH.AIDE.BusinessLayer.DataLayer
{
    class clsProblemSql : DataLayerBase
    {
		#region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public clsProblemSql()
		{
			// Nothing for now.
		}

        #endregion

        #region Public Methods - Problem

        public bool InsertProblem(clsProblem businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertProblem]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.EMP_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM_DESCR", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM_DESCR));
                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM_INVOLVE", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM_INVOLVE));
               
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsProblem::Insert::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public bool UpdateProblem(clsProblem businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateProblems]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM_DESCR", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM_DESCR));
                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM_INVOLVE", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM_INVOLVE));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsProblem::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsProblem> GetAllProblems(int empID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllProblems]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, empID));
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReaderProblem(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetAllEmpResourcePlanner::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        internal List<clsProblem> PopulateObjectsFromReaderProblem(IDataReader dataReader)
        {
            List<clsProblem> list = new List<clsProblem>();

            while (dataReader.Read())
            {
                clsProblem businessObject = new clsProblem();
                PopulateBusinessObjectFromReaderProblem(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal void PopulateBusinessObjectFromReaderProblem(clsProblem businessObject, IDataReader dataReader)
        {
            businessObject.EMP_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.EMP_ID.ToString()));
            businessObject.EMPLOYEE_NAME = dataReader.GetString(dataReader.GetOrdinal(clsProblem.clsProblemFields.EMPLOYEE_NAME.ToString()));
            businessObject.PROBLEM_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.PROBLEM_ID.ToString()));
            businessObject.PROBLEM_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsProblem.clsProblemFields.PROBLEM_DESCR.ToString()));
            businessObject.PROBLEM_INVOLVE = dataReader.GetString(dataReader.GetOrdinal(clsProblem.clsProblemFields.PROBLEM_INVOLVE.ToString()));
        }

        #endregion

        #region Public Methods - Problem Cause
        public bool InsertProblemCause(clsProblem businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertProblemCause]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@CAUSE_DESCR", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CAUSE_DESCR));
                sqlCommand.Parameters.Add(new SqlParameter("@CAUSE_WHY", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CAUSE_WHY));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsProblem::Insert::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }
        public bool UpdateProblemCause(clsProblem businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateProblemCause]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@CAUSE_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CAUSE_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@CAUSE_DESCR", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CAUSE_DESCR));
                sqlCommand.Parameters.Add(new SqlParameter("@CAUSE_WHY", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CAUSE_WHY));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsProblem::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsProblem> GetAllProblemCause()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllProblemCause]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReaderProblemCause(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsResourcePlanner::GetAllProblemCause::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }
        internal List<clsProblem> PopulateObjectsFromReaderProblemCause(IDataReader dataReader)
        {
            List<clsProblem> list = new List<clsProblem>();

            while (dataReader.Read())
            {
                clsProblem businessObject = new clsProblem();
                PopulateBusinessObjectFromReaderProblemCause(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal void PopulateBusinessObjectFromReaderProblemCause(clsProblem businessObject, IDataReader dataReader)
        {
            businessObject.CAUSE_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.CAUSE_ID.ToString()));
            businessObject.PROBLEM_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.PROBLEM_ID.ToString()));
            businessObject.CAUSE_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsProblem.clsProblemFields.CAUSE_DESCR.ToString()));
            businessObject.CAUSE_WHY = dataReader.GetString(dataReader.GetOrdinal(clsProblem.clsProblemFields.CAUSE_WHY.ToString()));
        }
        #endregion

        #region Public Methods - Problem Option
        public bool InsertProblemOption(clsProblem businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertProblemOption]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@OPTION_DESCR", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OPTION_DESCR));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsProblem::Insert::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsProblem> GetAllProblemOption()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllProblemOption]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReaderProblemOption(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsProblem::GetAllProblemOption::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public bool UpdateProblemOption(clsProblem businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateProblemOption]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@OPTION_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OPTION_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@OPTION_DESCR", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OPTION_DESCR));
               
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsProblem::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }
        internal List<clsProblem> PopulateObjectsFromReaderProblemOption(IDataReader dataReader)
        {
            List<clsProblem> list = new List<clsProblem>();

            while (dataReader.Read())
            {
                clsProblem businessObject = new clsProblem();
                PopulateBusinessObjectFromReaderProblemOption(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal void PopulateBusinessObjectFromReaderProblemOption(clsProblem businessObject, IDataReader dataReader)
        {
            businessObject.OPTION_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.OPTION_ID.ToString()));
            businessObject.PROBLEM_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.PROBLEM_ID.ToString()));
            businessObject.OPTION_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsProblem.clsProblemFields.OPTION_DESCR.ToString()));
        }
        #endregion

        #region Public Methods - Problem Solution
        public bool InsertProblemSolution(clsProblem businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertProblemSolution]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@OPTION_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OPTION_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@SOLUTION_DESCR", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SOLUTION_DESCR));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsProblem::Insert::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public bool UpdateProblemSolution(clsProblem businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateProblemSolution]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@SOLUTION_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SOLUTION_ID));            
                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@OPTION_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OPTION_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@SOLUTION_DESCR", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SOLUTION_DESCR));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsProblem::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsProblem> GetAllProblemSolution()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllProblemSolution]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
               
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReaderProblemSolution(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsProblem::GetAllProblemOption::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }
        internal List<clsProblem> PopulateObjectsFromReaderProblemSolution(IDataReader dataReader)
        {
            List<clsProblem> list = new List<clsProblem>();

            while (dataReader.Read())
            {
                clsProblem businessObject = new clsProblem();
                PopulateBusinessObjectFromReaderProblemSolution(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal void PopulateBusinessObjectFromReaderProblemSolution(clsProblem businessObject, IDataReader dataReader)
        {
            businessObject.SOLUTION_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.SOLUTION_ID.ToString()));
            businessObject.PROBLEM_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.PROBLEM_ID.ToString()));
            businessObject.OPTION_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.OPTION_ID.ToString()));
            businessObject.SOLUTION_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsProblem.clsProblemFields.SOLUTION_DESCR.ToString()));
        }
        #endregion

        #region Public Methods - Problem Implement
        public bool InsertProblemImplement(clsProblem businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertProblemImplement]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@OPTION_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OPTION_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@IMPLEMENT_DESCR", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IMPLEMENT_DESCR));
                sqlCommand.Parameters.Add(new SqlParameter("@IMPLEMENT_ASSIGNEE", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IMPLEMENT_ASSIGNEE));
                sqlCommand.Parameters.Add(new SqlParameter("@IMPLEMENT_VALUE", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IMPLEMENT_VALUE));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsProblem::Insert::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public bool UpdateProblemImplement(clsProblem businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_UpdateProblemImplement]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@IMPLEMENT_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IMPLEMENT_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@OPTION_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OPTION_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@IMPLEMENT_DESCR", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IMPLEMENT_DESCR));
                sqlCommand.Parameters.Add(new SqlParameter("@IMPLEMENT_ASSIGNEE", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IMPLEMENT_ASSIGNEE));
                sqlCommand.Parameters.Add(new SqlParameter("@IMPLEMENT_VALUE", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IMPLEMENT_VALUE));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsProblem::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsProblem> GetAllProblemImplement()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllProblemImplement]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReaderProblemImplement(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsProblem::GetAllProblemOption::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }
        internal List<clsProblem> PopulateObjectsFromReaderProblemImplement(IDataReader dataReader)
        {
            List<clsProblem> list = new List<clsProblem>();

            while (dataReader.Read())
            {
                clsProblem businessObject = new clsProblem();
                PopulateBusinessObjectFromReaderProblemImplement(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal void PopulateBusinessObjectFromReaderProblemImplement(clsProblem businessObject, IDataReader dataReader)
        {
            businessObject.IMPLEMENT_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.IMPLEMENT_ID.ToString()));
            businessObject.PROBLEM_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.PROBLEM_ID.ToString()));
            businessObject.OPTION_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.OPTION_ID.ToString()));
            businessObject.IMPLEMENT_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsProblem.clsProblemFields.IMPLEMENT_DESCR.ToString()));
            businessObject.IMPLEMENT_ASSIGNEE = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.IMPLEMENT_ASSIGNEE.ToString()));
            businessObject.IMPLEMENT_VALUE = dataReader.GetString(dataReader.GetOrdinal(clsProblem.clsProblemFields.IMPLEMENT_VALUE.ToString()));
        }
        #endregion

        #region Public Methods - Problem Result
        public bool InsertProblemResult(clsProblem businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_InsertProblemResult]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROBLEM_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@OPTION_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OPTION_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@RESULT_DESCR", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RESULT_DESCR));
                sqlCommand.Parameters.Add(new SqlParameter("@RESULT_VALUE", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.RESULT_VALUE));

                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clsProblem::Insert::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        public List<clsProblem> GetAllProblemResult(int problemID, int optionID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[sp_GetAllProblemResult]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@PROBLEM_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, problemID));
                sqlCommand.Parameters.Add(new SqlParameter("@OPTION_ID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, optionID));

                MainConnection.Open();
                IDataReader dataReader = sqlCommand.ExecuteReader();
                return PopulateObjectsFromReaderProblemResult(dataReader);
            }
            catch (Exception ex)
            {
                throw new Exception("clsProblem::GetAllProblemOption::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }
        internal List<clsProblem> PopulateObjectsFromReaderProblemResult(IDataReader dataReader)
        {
            List<clsProblem> list = new List<clsProblem>();

            while (dataReader.Read())
            {
                clsProblem businessObject = new clsProblem();
                PopulateBusinessObjectFromReaderProblemResult(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;
        }

        internal void PopulateBusinessObjectFromReaderProblemResult(clsProblem businessObject, IDataReader dataReader)
        {
            businessObject.RESULT_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.RESULT_ID.ToString()));
            businessObject.PROBLEM_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.PROBLEM_ID.ToString()));
            businessObject.OPTION_ID = dataReader.GetInt32(dataReader.GetOrdinal(clsProblem.clsProblemFields.OPTION_ID.ToString()));
            businessObject.RESULT_DESCR = dataReader.GetString(dataReader.GetOrdinal(clsProblem.clsProblemFields.RESULT_DESCR.ToString()));
            businessObject.RESULT_VALUE = dataReader.GetString(dataReader.GetOrdinal(clsProblem.clsProblemFields.RESULT_VALUE.ToString()));

        }
        #endregion
    }
}
