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
    private string conString = "Server=ME\\SQLEXPRESS; Database=NetAssign; User=Matt; Password=Welcome123"; 
    private SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        ListView1.Visible = false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sqlCommand= "SELECT b.Title, FirstName, SecondName, LastName, PublishedDate, g.Title AS 'Genre' FROM Author a INNER JOIN Book b ON b.AuthorID = a.AuthorID INNER JOIN Genre g ON b.GenreID = g.GenreID WHERE b.Title Contains @Title AND LastName Contains @LastName";
        conn.ConnectionString = conString;
        SqlCommand cmd = conn.CreateCommand();

        try
        {
            SqlParameter titleParam = new SqlParameter();
            titleParam.ParameterName = "@Title";
            titleParam.Value = txtTitle.Text;

            SqlParameter authorLParam = new SqlParameter();
            authorLParam.ParameterName = "@LastName";
            authorLParam.Value = txtAuthor.Text;

            cmd.CommandText = sqlCommand;

            cmd.Parameters.Add(titleParam);
            cmd.Parameters.Add(authorLParam);

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