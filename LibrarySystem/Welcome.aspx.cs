using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Welcome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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
        }else if (dr["AccountType"].ToString() == "Librarian")
        {
            btnLibrarianPage.Visible = true;
        }
        else
        {
            btnMemberPage.Visible = true;
        }
    }

    protected void btnMemberPage_Click(object sender, EventArgs e)
    {

    }
}