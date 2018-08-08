/// <summary>
/// This class is the code behind the Search Book page for searching books in the system by Author or title and requesting the book
/// 
/// By Matthew Erenberg
/// </summary>
/// 
using System;
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
    /// <summary>
    /// Page load sets it up to hide any information at the start to have a cleaner design
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        lblBookInfo.Visible = false;
        lblBookSyn.Visible = false;
        btnRequest.Visible = false;
    }
    /// <summary>
    /// A method set up to add % to the beginning and end of a work to find any instance of that search
    /// </summary>
    /// <param name="searchWord"></param>
    /// <returns></returns>
    public string mergeSearch(string searchWord)
    {
        string temp = "%";
        temp += searchWord;
        searchWord = temp;
        searchWord += "%";
        return searchWord;
    }
    /// <summary>
    /// This will execute the search feature of the code allowing to find by title or author
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //grabs the text values from text feilds
        string title = txtTitle.Text;
        string authorLast = txtAuthor.Text;
        string genre = ddlGenre.SelectedValue.ToString();
        //checks if they are null/empty
        if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(authorLast))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Either Title or Author need to be filled to search')", true);
        }
        else
        {
        string sqlCommand= "SELECT b.BookID, b.Title, LastName + ', ' + FirstName AS 'Author', g.Title AS 'Genre' FROM Author a INNER JOIN Book b ON b.AuthorID = a.AuthorID INNER JOIN Genre g ON b.GenreID = g.GenreID WHERE b.Title LIKE @Title AND a.LastName LIKE @LastName AND g.GenreID = @Genre";
        conn.ConnectionString = conString;
        SqlCommand cmd = conn.CreateCommand();

        try
        {
            title = mergeSearch(title);
            authorLast = mergeSearch(authorLast);
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
                if (!reader.HasRows)
                {
                    lblBookInfo.Text = "There is Currently No Books Found";
                    lblBookInfo.Visible = true;
                }

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
     }

    }

    /// <summary>
    /// Set up
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
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
                var pub = reader.GetDateTime(4);
                string publish = pub.ToString();
                htmlstr.Append("Title: " + reader.GetString(0) + "<br> By:" + reader.GetString(1) + ", " + reader.GetString(2) + ", " + reader.GetString(3)
                    + "<br> Published On: " + publish + "<br> Cover Type: " + reader.GetString(5));

            }
            lblBookInfo.Text = htmlstr.ToString();
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
        lblBookInfo.Visible = true;
        lblBookSyn.Visible = true;
        btnRequest.Visible = true;
        int numOfBooks = bookCount(bookID);
        if (numOfBooks < 1)
        {
            btnRequest.Enabled = false;
        }
        else
        {
            btnRequest.Enabled = true;
        }
    }

    public int bookCount(int bookID)
    {
        string sqlCommand = "SELECT Count(BookID) FROM Issue WHERE BookID = " + bookID + " AND Status = 'Available'";
        int count = 0;
        conn.ConnectionString = conString;
        SqlCommand cmd = conn.CreateCommand();

        try
        {
            cmd.CommandText = sqlCommand;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                count = reader.GetInt32(0);
            }
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
        lblBookSyn.Text = "Book Count: " + count;
        return count;
    }

    protected void btnRequest_Click(object sender, EventArgs e)
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
                int memberID = Convert.ToInt32(dr["UserId"].ToString());
                int bookRentals = booksRented(memberID);
                if (bookRentals >= Convert.ToInt32(dr["BookLimit"].ToString()))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Max Book Limit", "alert('You have reached the limit of books rented, please return a book to request this book')", true);
                }
                else
                {
                    DateTime dateReq = DateTime.Now;
                    int bookId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);//grabs the book id from the gridview
                    int issueId = findIssue(bookId);//grabs all issues that have an available issue for the corresponding book
                    //
                    string sqlCommand = "INSERT INTO Request VALUES ('" + dateReq.ToString() + "', " + issueId + ", " + memberID + ")";
                    conn.ConnectionString = conString;
                    SqlCommand cmd = conn.CreateCommand();

                    try
                    {
                        cmd.CommandText = sqlCommand;
                        conn.Open();
                        cmd.ExecuteScalar();

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
                    changeStatus(issueId);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Book Requested", "alert('The Book has been requested!')", true);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("default.aspx");
        }
    }

    private void changeStatus(int issueId)
    {
        string sqlCommand = "UPDATE Issue SET Status = 'Reserved' WHERE IssueId =" + issueId;
        conn.ConnectionString = conString;
        SqlCommand cmd = conn.CreateCommand();

        try
        {
            cmd.CommandText = sqlCommand;
            conn.Open();
            cmd.ExecuteScalar();

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
    }

    private int findIssue(int bookId)
    {
        int issueId = 0;
        try
        {
            DataRow dr = UserTool.GetUserInfo(Session["User"].ToString());
            if (dr == null)
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                    string sqlCommand = "SELECT * FROM Issue WHERE BookId ="+ bookId + " AND Status = 'Available'";
                    conn.ConnectionString = conString;
                    SqlCommand cmd = conn.CreateCommand();

                    try
                    {
                    cmd.CommandText = sqlCommand;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            issueId = reader.GetInt32(0);
                        }
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
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("default.aspx");
        }
        return issueId;
    }

    public int booksRented(int memberID)
    {
        int booksRented = 100;

        string sqlCommand = "SELECT Count(*) FROM Rental WHERE UserId = " + memberID;
        conn.ConnectionString = conString;
        SqlCommand cmd = conn.CreateCommand();

        try
        {
            cmd.CommandText = sqlCommand;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                booksRented = reader.GetInt32(0);
            }
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

        return booksRented;
    }
}