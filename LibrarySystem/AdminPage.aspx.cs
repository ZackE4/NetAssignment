/// <summary>
/// This class is the code behind the administrator page which contains buttons to link to the add new object and search/edit object pages
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

public partial class AdminPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Redirects to admin search page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminSearch.aspx");
    }

    /// <summary>
    /// Redirects to Admin add page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminAdd.aspx");
    }
}