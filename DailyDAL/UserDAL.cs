using DailyDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyDAL
{
    public class UserDAL
    {
        SqlConnection conObj;
        string conStr = ConfigurationManager.ConnectionStrings["Entities"].ConnectionString;
        public UserDAL()
        {
            conObj = new SqlConnection(conStr);
        }
      
        public List<UserDTO> FetchAllUser()
        {
            try
            {
                List<UserDTO> lstUsers = new List<UserDTO>();

                SqlConnection conObj = new SqlConnection();
                conObj.ConnectionString = conStr;

                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"SELECT [FullName],Email FROM [user]";
                queryObj.CommandType = System.Data.CommandType.Text;
                queryObj.Connection = conObj;

                conObj.Open();
                SqlDataReader drUser = queryObj.ExecuteReader();
                while (drUser.Read())
                {
                    lstUsers.Add(new UserDTO()
                    {
                        FullName = drUser["FullName"].ToString(),
                        Email = drUser["Email"].ToString(),
                       
                    });
                }
                return lstUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserDTO> FetchUserByName(string FullName)
        {

            try
            {
                List<UserDTO> lstUsers = new List<UserDTO>();

                SqlConnection conObj = new SqlConnection();
                conObj.ConnectionString = conStr;

                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"SELECT [FullName],Email FROM [user] WHERE [FullName] LIKE @FullName";
                queryObj.Parameters.AddWithValue("@FullName", "%" + FullName + "%");
                queryObj.CommandType = System.Data.CommandType.Text;
                queryObj.Connection = conObj;

                conObj.Open();
                SqlDataReader drUser = queryObj.ExecuteReader();
                while (drUser.Read())
                {
                    lstUsers.Add(new UserDTO()
                    {
                        FullName = drUser["FullName"].ToString(),
                        Email = drUser["Email"].ToString(),
                       

                    });
                }
                return lstUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertUser(UserDTO deptObj)
        {
            try
            {
                SqlConnection conObj = new SqlConnection();
                conObj.ConnectionString = conStr;

                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"usp__AddNewUser";
                queryObj.CommandType = System.Data.CommandType.StoredProcedure;
                queryObj.Connection = conObj;
                
                queryObj.Parameters.AddWithValue("@FullName", deptObj.FullName);
                queryObj.Parameters.AddWithValue("@Email", deptObj.Email);
                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = SqlDbType.Int;
                queryObj.Parameters.Add(prmReturn);
                conObj.Open();
                queryObj.ExecuteNonQuery();
                return Convert.ToInt32(prmReturn.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
