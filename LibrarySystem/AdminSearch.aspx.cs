using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ddSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = ddSelector.SelectedIndex;
    }

    protected void btnSearchUser_Click(object sender, EventArgs e)
    {
        string username = tbUserName.Text;
        string lName = tbLastName.Text;
        string email = tbEmail.Text;

        if(String.IsNullOrEmpty(username) && String.IsNullOrEmpty(lName) && String.IsNullOrEmpty(email))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('You must provide either username, email or last name.')", true);
        }
        else
        {
            SqlConnection LibConnect = new SqlConnection();
            LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
            SqlCommand cmd = LibConnect.CreateCommand();

            try
            {
                string query = "Select UserId, Username, AccountType, FirstName, LastName FROM [User] WHERE Username Like @User OR LastName Like @LName OR email Like @Email";
                SqlParameter userParam = new SqlParameter();
                userParam.ParameterName = "@User";
                userParam.Value = username;
                SqlParameter lnameparam = new SqlParameter();
                lnameparam.ParameterName = "@LName";
                lnameparam.Value = lName;
                SqlParameter emailparam = new SqlParameter();
                emailparam.ParameterName = "@Email";
                emailparam.Value = email;

                cmd.CommandText = query;
                cmd.Parameters.Add(userParam);
                cmd.Parameters.Add(lnameparam);
                cmd.Parameters.Add(emailparam);


                LibConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                GridView1.DataSource = dt;
                GridView1.DataBind();
                reader.Close();

            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();
            }
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        try
        {
            string query = "Select * From [User] WHERE UserId = @User";
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
                DataRow dr = dt.Rows[0];
                tbEditFName.Text = dr["FirstName"].ToString();
                tbEditLastName.Text = dr["LastName"].ToString();
                ddEditAccType.SelectedValue = dr["AccountType"].ToString();
                tbEditAddress.Text = dr["Address"].ToString();
                tbEditEmail.Text = dr["Email"].ToString();
                tbEditBookLimit.Text = dr["BookLimit"].ToString();
                tbEditReIssue.Text = dr["ReIssueLimit"].ToString();
                tbEditComments.Text = dr["Comments"].ToString();
            }
            reader.Close();

        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
        }
        finally
        {
            cmd.Dispose();
            LibConnect.Close();
        }

    }

    protected void btnUserEditSubmit_Click(object sender, EventArgs e)
    {
        string fname = tbEditFName.Text;
        string lname = tbEditLastName.Text;
        string accountType = ddEditAccType.SelectedValue;
        string address = tbEditAddress.Text;
        string email = tbEditEmail.Text;
        string bookLimit = tbEditBookLimit.Text;
        string reissuelimit = tbEditReIssue.Text;
        string comments = tbEditComments.Text;

        if (String.IsNullOrEmpty(fname) ||
            String.IsNullOrEmpty(lname) ||
            String.IsNullOrEmpty(accountType) ||
            String.IsNullOrEmpty(address) ||
            String.IsNullOrEmpty(email) ||
            String.IsNullOrEmpty(bookLimit) ||
            String.IsNullOrEmpty(reissuelimit))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('All User fields must have values')", true);
        }
        else
        {
            int userId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            SqlConnection LibConnect = new SqlConnection();
            LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
            SqlCommand cmd = LibConnect.CreateCommand();

            try
            {
                string query = "Update [User] Set FirstName = @fname, LastName = @lname, AccountType = @actype, Address = @addr, Email = @email, BookLimit = @booklimit, ReIssueLimit = @relimit, Comments = @Comments WHERE UserId = @userid";
                SqlParameter userParam = new SqlParameter();
                userParam.ParameterName = "@userid";
                userParam.Value = userId;

                SqlParameter fnameparam = new SqlParameter();
                fnameparam.ParameterName = "@fname";
                fnameparam.Value = fname;

                SqlParameter lnameparam = new SqlParameter();
                lnameparam.ParameterName = "@lname";
                lnameparam.Value = lname;

                SqlParameter actparam = new SqlParameter();
                actparam.ParameterName = "@actype";
                actparam.Value = accountType;

                SqlParameter addrParam = new SqlParameter();
                addrParam.ParameterName = "@addr";
                addrParam.Value = address;

                SqlParameter emailParam = new SqlParameter();
                emailParam.ParameterName = "@email";
                emailParam.Value = email;

                SqlParameter booklimitparam = new SqlParameter();
                booklimitparam.ParameterName = "@booklimit";
                booklimitparam.Value = Convert.ToInt32(bookLimit);

                SqlParameter reissueparam = new SqlParameter();
                reissueparam.ParameterName = "@relimit";
                reissueparam.Value = Convert.ToInt32(reissuelimit);

                SqlParameter commentparam = new SqlParameter();
                commentparam.ParameterName = "@Comments";
                commentparam.Value = comments;

                cmd.CommandText = query;
                cmd.Parameters.Add(userParam);
                cmd.Parameters.Add(fnameparam);
                cmd.Parameters.Add(lnameparam);
                cmd.Parameters.Add(actparam);
                cmd.Parameters.Add(addrParam);
                cmd.Parameters.Add(emailParam);
                cmd.Parameters.Add(booklimitparam);
                cmd.Parameters.Add(reissueparam);
                cmd.Parameters.Add(commentparam);


                LibConnect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong, please verify all fields and try again.')", true);

            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('User Updated.')", true);
            }
        }
    }
}