using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member : System.Web.UI.Page
{
    private SqlConnection conn = new SqlConnection();
    private string conString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
    private SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblHistoryMissing.Visible = false;
        lblRentalMissing.Visible = false;
        loadCurrentRentals();
        loadHistory();
        amountOwing();
    }

    private void amountOwing()
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
                if (dr["AccountType"].ToString().Equals("Member"))
                {
                    string sqlCommand = "SELECT AmountOwing FROM [User] WHERE UserId = @UserId";
                    conn.ConnectionString = conString;
                    SqlCommand cmd = conn.CreateCommand();
                    int userId = Convert.ToInt32(dr["UserId"].ToString());

                    try
                    {
                        cmd.CommandText = sqlCommand;
                        conn.Open();
                        SqlParameter userIdParam = new SqlParameter();
                        userIdParam.ParameterName = "@UserId";
                        userIdParam.Value = userId;
                        cmd.Parameters.Add(userIdParam);
                        SqlDataReader reader = cmd.ExecuteReader();
                        string fee = " ";
                        while (reader.Read())
                        {
                            fee = reader.GetDouble(0).ToString();
                            lblOwing.Text = "Amount Owing: $" + fee;
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
                }
                else
                {
                    Response.Redirect("default.aspx");
                }
            }

        }
        catch (Exception ex)
        {
            Response.Redirect("default.aspx");
        }
    }

    private void loadHistory()
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
                if (dr["AccountType"].ToString().Equals("Member"))
                {
                    string sqlCommand = "SELECT Rental.RentalId, Rental.IssueId, Rental.RentalDate, Rental.DueDate, Rental.Fees, Rental.Comments, Issue.Status, Book.Title, Book.CoverType, Author.FirstName + ', ' + Author.LastName AS Author, Genre.Title AS Genre FROM Rental INNER JOIN Issue ON Rental.IssueId = Issue.IssueId INNER JOIN Book ON Issue.BookId = Book.BookId INNER JOIN Author ON Book.AuthorId = Author.AuthorId INNER JOIN Genre ON Book.GenreId = Genre.GenreId "
                + " WHERE Rental.UserId = @UserId AND Rental.ReturnDate IS NOT NULL";
                    conn.ConnectionString = conString;
                    SqlCommand cmd = conn.CreateCommand();
                    int userId = Convert.ToInt32(dr["UserId"].ToString());

                    try
                    {
                        cmd.CommandText = sqlCommand;
                        conn.Open();
                        SqlParameter userIdParam = new SqlParameter();
                        userIdParam.ParameterName = "@UserId";
                        userIdParam.Value = userId;
                        cmd.Parameters.Add(userIdParam);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            lblHistoryMissing.Visible = true;
                        }
                        else
                        {
                            lblHistoryMissing.Visible = false;
                        }
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        GridView2.DataSource = dt;
                        GridView2.DataBind();
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
                else
                {
                    Response.Redirect("default.aspx");
                }
            }

        }
        catch (Exception ex)
        {
            Response.Redirect("default.aspx");
        }
    }

    private void loadCurrentRentals()
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
                if (dr["AccountType"].ToString().Equals("Member"))
                {
                    string sqlCommand = "SELECT Rental.RentalId, Rental.IssueId, Rental.RentalDate, Rental.DueDate, Rental.Fees, Rental.Comments, Issue.Status, Book.Title, Book.CoverType, Author.FirstName + ', ' + Author.LastName AS Author, Genre.Title AS Genre FROM Rental INNER JOIN Issue ON Rental.IssueId = Issue.IssueId INNER JOIN Book ON Issue.BookId = Book.BookId INNER JOIN Author ON Book.AuthorId = Author.AuthorId INNER JOIN Genre ON Book.GenreId = Genre.GenreId "
                + " WHERE Rental.UserId = @UserId AND Rental.ReturnDate IS NULL";
                    conn.ConnectionString = conString;
                    SqlCommand cmd = conn.CreateCommand();
                    int userId = Convert.ToInt32(dr["UserId"].ToString());

                    try
                    {
                        cmd.CommandText = sqlCommand;
                        conn.Open();
                        SqlParameter userIdParam = new SqlParameter();
                        userIdParam.ParameterName = "@UserId";
                        userIdParam.Value = userId;
                        cmd.Parameters.Add(userIdParam);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            lblRentalMissing.Visible = true;
                        }
                        else
                        {
                            lblRentalMissing.Visible = false;
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
                else
                {
                    Response.Redirect("default.aspx");
                }
            }

        }
        catch (Exception ex)
        {
            Response.Redirect("default.aspx");
        }
    }
}