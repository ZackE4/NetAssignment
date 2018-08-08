/// <summary>
/// This class is the code behind the my profile page for users to edit their personal info or change their profile picture
/// 
/// By Zack Eichler
/// </summary>
/// 

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyProfile : System.Web.UI.Page
{
    DataRow userRow;

    /// <summary>
    /// Gets userId from the session and pulls the row from the user table for the selected user to be used to dynamically
    /// populate the page with the user's information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            userRow = UserTool.GetUserInfo(Session["User"].ToString());
            if (userRow == null)
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    tbFName.Text = userRow["FirstName"].ToString();
                    tblName.Text = userRow["LastName"].ToString();
                    tbAddress.Text = userRow["Address"].ToString();
                    tbEmail.Text = userRow["Email"].ToString();
                    ddProfilePic.SelectedIndex = Convert.ToInt32(userRow["ProfilePicture"].ToString());
                    imgProfilePic.ImageUrl = "Images/" + userRow["ProfilePicture"].ToString() + ".png";
                }
            }
        }
        catch
        {
            Response.Redirect("default.aspx");
        }
    }

    /// <summary>
    /// Updates the image based on the selected picture title
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddProfilePic_SelectedIndexChanged(object sender, EventArgs e)
    {
        imgProfilePic.ImageUrl = "Images/" + ddProfilePic.SelectedIndex.ToString() + ".png";
    }

    /// <summary>
    /// Updates row in the user table for logged in user with new information from textboxes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string fName = tbFName.Text;
        string lName = tblName.Text;
        string addr = tbAddress.Text;
        string email = tbEmail.Text;
        string profilePic = ddProfilePic.SelectedValue;

        if (String.IsNullOrEmpty(fName) ||
            String.IsNullOrEmpty(lName) ||
            String.IsNullOrEmpty(addr) ||
            String.IsNullOrEmpty(email))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('All Fields require values.')", true);
        }
        else
        {
            int userId = Convert.ToInt32(userRow["UserId"].ToString());
            SqlConnection LibConnect = new SqlConnection();
            LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
            SqlCommand cmd = LibConnect.CreateCommand();

            try
            {
                string query = "Update [User] Set FirstName = @FirstName, LastName = @LastName, Address = @Address, Email = @Email, ProfilePicture = @ProfilePicture WHERE UserId = @UserId";
                SqlParameter fNameParam = new SqlParameter();
                fNameParam.ParameterName = "@FirstName";
                fNameParam.Value = fName;
                SqlParameter lNameParam = new SqlParameter();
                lNameParam.ParameterName = "@LastName";
                lNameParam.Value = lName;
                SqlParameter addrParam = new SqlParameter();
                addrParam.ParameterName = "@Address";
                addrParam.Value = addr;
                SqlParameter emailParam = new SqlParameter();
                emailParam.ParameterName = "@Email";
                emailParam.Value = email;
                SqlParameter userParam = new SqlParameter();
                userParam.ParameterName = "@UserId";
                userParam.Value = userId;
                SqlParameter profilePicParam = new SqlParameter();
                profilePicParam.ParameterName = "@ProfilePicture";
                profilePicParam.Value = profilePic;

                cmd.CommandText = query;
                cmd.Parameters.Add(fNameParam);
                cmd.Parameters.Add(lNameParam);
                cmd.Parameters.Add(addrParam);
                cmd.Parameters.Add(emailParam);
                cmd.Parameters.Add(userParam);
                cmd.Parameters.Add(profilePicParam);

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
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Profile has been Updated.')", true);
            }
        }
    }
}