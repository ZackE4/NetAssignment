﻿/// <summary>
/// This class is the code behind a simple welcome page that displays a greeting to the user and allows them to navigate to the
/// page associated with their Account Type
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
using System.Data;

public partial class Welcome : System.Web.UI.Page
{
    /// <summary>
    /// Gets userId from the session and pulls the row from the user table for the selected user to be used to dynamically
    /// populate the users name for the greeting message, and decide which buttons to show the user based on their Account Type
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataRow dr = UserTool.GetUserInfo(Session["User"].ToString());
            if (dr == null)
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                lblWelcome.Text = "Welcome " + dr["FirstName"].ToString() + ",";
            }

            if (dr["AccountType"].ToString() == "Administrator")
            {
                btnAdminPage.Visible = true;
            }
            else if (dr["AccountType"].ToString() == "Librarian")
            {
                btnLibrarianPage.Visible = true;
            }
            else
            {
                btnMemberPage.Visible = true;
            }
        }
        catch
        {
            Response.Redirect("default.aspx");
        }
    }

    /// <summary>
    /// Redirect to member page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnMemberPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberPage.aspx");
    }

    /// <summary>
    /// Redirect to librarian page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLibrarianPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("LibrarianPage.aspx");
    }

    /// <summary>
    /// Redirect to Admin Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdminPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminPage.aspx");
    }
}