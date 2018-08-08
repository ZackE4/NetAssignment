/// <summary>
/// This class is the code behind the login page for verifying username and password and logging the user in
/// 
/// By Zack Eichler
/// </summary>
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    /// <summary>
    /// Checks if the page was redirected from create user page and shows a success message for registering if it was
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        bool newuser = false;
        try { newuser = Convert.ToBoolean(Request["newuser"].ToString()); }
        catch { }

        if (newuser)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Registration Success, Please login')", true);
        }
    }

    /// <summary>
    /// Verifies username and password and logs user in if successful, otherwise shows error message
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        bool loginSuccess = false;
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        string userId = "";
        string user = tbUser.Text;
        string pass = tbPass.Text;
        if (String.IsNullOrEmpty(user) || String.IsNullOrEmpty(pass))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Username and Password Are Required.')", true);
        }
        else
        {
            try
            {
                string query = "Select * FROM [User] WHERE Username=@User";
                SqlParameter userParam = new SqlParameter();
                userParam.ParameterName = "@User";
                userParam.Value = user;

                cmd.CommandText = query;
                cmd.Parameters.Add(userParam);

                LibConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt.Rows.Count < 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Username not found, please check your spelling or register an account.')", true);
                }
                else
                {
                    DataRow dr = dt.Rows[0];
                    if (dr["Password"].ToString() != pass)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Incorrect Username or Password.')", true);
                    }
                    else
                    {
                        userId = dr["UserId"].ToString();
                        loginSuccess = true;
                    }
                }
            }
            catch(Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something went wrong, Oops.')", true);
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();
                if (loginSuccess)
                {
                    Session["User"] = userId;
                    //Go To Home page
                    Response.Redirect("Welcome.aspx");
                }
            }
        }
    }
}