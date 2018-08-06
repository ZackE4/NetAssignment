using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchBook : System.Web.UI.Page
{
    private SqlConnection conn = new SqlConnection();
    private string conString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString; 
    private string conString = "Server=ME\\SQLEXPRESS; Database=NetAssign; User=Matt; Password=Welcome123"; 

    private SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        ListView1.Visible = false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string title = txtTitle.Text;
        string authorLast = txtAuthor.Text;
        int genre = Convert.ToInt32(ddlGenre.SelectedValue.ToString());

        if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(authorLast))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Either Title or Author need to be filled to search')", true);
        }
        string sqlCommand= "SELECT b.Title, FirstName, SecondName, LastName, PublishedDate, g.Title AS 'Genre' FROM Author a INNER JOIN Book b ON b.AuthorID = a.AuthorID INNER JOIN Genre g ON b.GenreID = g.GenreID WHERE b.Title Contains @Title AND LastName Contains @LastName AND GenreID = @Genre";
        conn.ConnectionString = conString;
        SqlCommand cmd = conn.CreateCommand();

        try
        {
            SqlParameter titleParam = new SqlParameter();
            titleParam.ParameterName = "@Title";
            titleParam.Value = title;

            SqlParameter authorLParam = new SqlParameter();
            authorLParam.ParameterName = "@LastName";
            authorLParam.Value = authorLast;

            SqlParameter genreParam = new SqlParameter();
            genreParam.ParameterName = "@Genre";
            genreParam.Value = genre;

            cmd.CommandText = sqlCommand;

            cmd.Parameters.Add(titleParam);
            cmd.Parameters.Add(authorLParam);
            cmd.Parameters.Add(genreParam);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            ListView1.DataSource = dt;
            reader.Close();
        }
        catch (Exception ex)
        {
            //error
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }

        ListView1.Visible = true;
    }
}