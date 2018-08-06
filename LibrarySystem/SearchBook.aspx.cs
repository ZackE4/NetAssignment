﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchBook : System.Web.UI.Page
{
    private SqlConnection conn = new SqlConnection();
    private string conString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString; 
    private SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblBookInfo.Visible = false;
        lblBookSyn.Visible = false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string title = txtTitle.Text;
        string authorLast = txtAuthor.Text;
        string genre = ddlGenre.SelectedValue.ToString();

        if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(authorLast))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Either Title or Author need to be filled to search')", true);
        }
        else
        {
        string sqlCommand= "SELECT b.BookID, b.Title, LastName + ',' + FirstName AS 'Author', g.Title AS 'Genre' FROM Author a INNER JOIN Book b ON b.AuthorID = a.AuthorID INNER JOIN Genre g ON b.GenreID = g.GenreID WHERE b.Title LIKE @Title AND a.LastName LIKE @LastName AND g.GenreID = @Genre";
        conn.ConnectionString = conString;
        SqlCommand cmd = conn.CreateCommand();

        try
        {
            title += "%";
            authorLast += "%";
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
                
           /* if (dt.Rows.Count.Equals(0))
            {

            }*/
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
     }

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
            
            int bookID = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            string sqlCommand = "SELECT b.Title, FirstName, SecondName, LastName, PublishedDate, b.CoverType, g.Title AS 'Genre' FROM Author a INNER JOIN Book b ON b.AuthorID = a.AuthorID INNER JOIN Genre g ON b.GenreID = g.GenreID WHERE b.BookID = " + bookID;
            conn.ConnectionString = conString;
            SqlCommand cmd = conn.CreateCommand();

            try
            {
                cmd.CommandText = sqlCommand;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                StringBuilder htmlstr = new StringBuilder("");
                while (reader.Read())
                {
                    htmlstr.Append(reader.GetString(0) + "\n " + reader.GetString(1)); 
                }
                lblBookInfo.Text = htmlstr.ToString();
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
        lblBookInfo.Visible = true;
        lblBookSyn.Visible = true;
        

    }
}