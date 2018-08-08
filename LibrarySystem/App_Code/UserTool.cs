/// <summary>
/// This class is a static helper class for pulling the currently logged in user's information from the user table so each page
/// that requires information about the user to dynamically generate the page can use the GetUserInfo Method
/// 
/// By Zack Eichler
/// </summary>
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for UserTool
/// </summary>
public static class UserTool
{
    static UserTool()
    {

    }

    /// <summary>
    /// Selects the row from the user table for the given user and returns it
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static DataRow GetUserInfo(string userId)
    {
        DataRow dr = null;
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        try
        {
            string query = "Select * FROM [User] WHERE UserId=@User";
            SqlParameter userParam = new SqlParameter();
            userParam.ParameterName = "@User";
            userParam.Value = userId;

            cmd.CommandText = query;
            cmd.Parameters.Add(userParam);

            LibConnect.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
        }
        catch(Exception ex)
        {

        }
        finally
        {
            cmd.Dispose();
            LibConnect.Close();
        }

        return dr;
    }
}