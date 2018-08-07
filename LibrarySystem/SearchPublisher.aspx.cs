using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchPublisher : System.Web.UI.Page
{
    private SqlConnection conn = new SqlConnection();
    private string conString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
    private SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.Visible = false;
    }

    public string mergeSearch(string searchWord)
    {
        string temp = "%";
        temp += searchWord;
        searchWord = temp;
        searchWord += "%";
        return searchWord;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string publisherName = txtPublisher.Text;

        if (String.IsNullOrEmpty(publisherName))
        {

        }
        else
        {
            string sqlCommand = "SELECT * FROM Publisher WHERE Name LIKE @Publish";
            conn.ConnectionString = conString;
            SqlCommand cmd = conn.CreateCommand();

            try
            {
                //used to track if the keyword is in any position
                publisherName = mergeSearch(publisherName);

                SqlParameter publishParam = new SqlParameter();
                publishParam.ParameterName = "@Publish";
                publishParam.Value = publisherName;

                cmd.CommandText = sqlCommand;
                cmd.Parameters.Add(publishParam);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                reader.Close();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", "alert('An Error has occoured')", true);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            GridView1.Visible = true;
        }
    }
}