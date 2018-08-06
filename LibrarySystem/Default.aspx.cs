using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;


public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        string user = tbUser.Text;
        string pass = tbPass.Text;
        if (String.IsNullOrEmpty(user) || String.IsNullOrEmpty(pass))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Username and Password Are Required.')", true);
        }
        else
        {

        }
    }
}