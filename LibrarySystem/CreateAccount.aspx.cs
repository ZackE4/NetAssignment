using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Data;

public partial class CreateAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool RegistrationSuccess = true;
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        string user = tbUser.Text;
        string pw = tbPass.Text;
        string pwConfirm = tbConfirmPass.Text;
        string fname = tbFirstName.Text;
        string lname = tbLastName.Text;
        string address = tbAddress.Text;
        string email = tbEmail.Text;
        if (pw != pwConfirm)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Password and Confirm Password must match!')", true);
        }
        else
        {
            if (String.IsNullOrEmpty(user) ||
                String.IsNullOrEmpty(pw) ||
                String.IsNullOrEmpty(pwConfirm) ||
                String.IsNullOrEmpty(fname) ||
                String.IsNullOrEmpty(lname) ||
                String.IsNullOrEmpty(address) ||
                String.IsNullOrEmpty(email))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Please enter data for all fields')", true);
                RegistrationSuccess = false;
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

                    if (dt.Rows.Count > 0)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('That username already exists')", true);
                        RegistrationSuccess = false;
                    }

                    string query2 = "Select * FROM [User] WHERE Email=@Email";
                    SqlParameter emailParam = new SqlParameter();
                    emailParam.ParameterName = "@Email";
                    emailParam.Value = email;

                    cmd.CommandText = query2;
                    cmd.Parameters.Add(emailParam);

                    SqlDataReader reader2 = cmd.ExecuteReader();
                    DataTable dt2 = new DataTable();
                    dt2.Load(reader2);

                    if (dt2.Rows.Count > 0)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('That email address is already registered.')", true);
                        RegistrationSuccess = false;
                    }

                    string query3 = "Insert Into [User] (Username, Password, AccountType, FirstName, LastName, Address, Email, BookLimit, ReIssueLimit) VALUES(@User, @Password, 'Member', @Fname, @Lname, @Address, @Email, 3, 3)";
                    SqlParameter fnameParam = new SqlParameter();
                    fnameParam.ParameterName = "@FName";
                    fnameParam.Value = fname;
                    SqlParameter pwParam = new SqlParameter();
                    pwParam.ParameterName = "@Password";
                    pwParam.Value = pw;
                    SqlParameter lnameParam = new SqlParameter();
                    lnameParam.ParameterName = "@LName";
                    lnameParam.Value = lname;
                    SqlParameter addressParam = new SqlParameter();
                    addressParam.ParameterName = "@Address";
                    addressParam.Value = address;
                    SqlParameter emailParam2 = new SqlParameter();
                    emailParam2.ParameterName = "@Email";
                    emailParam2.Value = email;

                    cmd.CommandText = query3;
                    cmd.Parameters.Add(pwParam);
                    cmd.Parameters.Add(fnameParam);
                    cmd.Parameters.Add(lnameParam);
                    cmd.Parameters.Add(addressParam);

                    var result = cmd.ExecuteScalar();

                }
                catch (Exception ex)
                {
                    RegistrationSuccess = false;
                }
                finally
                {
                    cmd.Dispose();
                    LibConnect.Close();

                    if (RegistrationSuccess)
                    {
                        Response.Redirect("default.aspx?newuser=true");
                    }
                }
            }
        }

    }
}