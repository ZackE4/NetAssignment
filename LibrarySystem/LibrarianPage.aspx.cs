using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LibrarianPage : System.Web.UI.Page
{
    private SqlConnection conn = new SqlConnection();
    private string conString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
    private SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        //MultiView1.ActiveViewIndex = 0;
    }

    protected void btnRequests_Click(object sender, EventArgs e)
    {
        
            string sqlCommand = "SELECT Request.RequestId, Request.DateOfRequest, [User].Username, [User].BookLimit, [User].ReIssueLimit, [User].FirstName, [User].LastName, [User].AmountOwing, Book.Title, Book.CoverType, Author.FirstName + ', ' + Author.LastName AS Author FROM Request INNER JOIN [User] ON Request.UserId = [User].UserId INNER JOIN Issue ON Request.IssueId = Issue.IssueId INNER JOIN Book ON Issue.BookId = Book.BookId INNER JOIN Author ON Book.AuthorId = Author.AuthorId";
            conn.ConnectionString = conString;
            SqlCommand cmd = conn.CreateCommand();

            try
            {
                cmd.CommandText = sqlCommand;
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
        MultiView1.ActiveViewIndex = 1;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string userName = txtUser.Text;
        if (string.IsNullOrEmpty(userName))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('User Name for search can not be empty')", true);
        }
        else
        {
            string sqlCommand = "SELECT Request.RequestId, Request.DateOfRequest, [User].Username, [User].BookLimit, [User].ReIssueLimit, [User].FirstName, [User].LastName, [User].AmountOwing, Book.Title, Book.CoverType, Author.FirstName + ', ' + Author.LastName AS Author FROM Request INNER JOIN [User] ON Request.UserId = [User].UserId INNER JOIN Issue ON Request.IssueId = Issue.IssueId INNER JOIN Book ON Issue.BookId = Book.BookId INNER JOIN Author ON Book.AuthorId = Author.AuthorId WHERE [User].Username LIKE @User";
            conn.ConnectionString = conString;
            SqlCommand cmd = conn.CreateCommand();

            try
            {
                string temp = "%";
                temp += userName;
                userName = temp + "%";
                SqlParameter userParam = new SqlParameter();
                userParam.ParameterName = "@User";
                userParam.Value = userName;
                cmd.CommandText = sqlCommand;
                cmd.Parameters.Add(userParam);
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
        }
    }

    protected void btnAssign_Click(object sender, EventArgs e)
    {
        if (GridView1.SelectedIndex == -1)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", "alert('An Error has occoured')", true);
        }
        else
        {
            try
            {
                int requestId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
                DataRow dr = UserTool.GetUserInfo(Session["Librarian"].ToString());
                if (dr == null)
                {
                    Response.Redirect("default.aspx");
                }
                else
                {
                        int[] ids = grabRequest(requestId);
                        DateTime rentalDate = DateTime.Now;
                        DateTime dueDate = rentalDate.AddDays(7);
                        string sqlCommand = "INSERT INTO Rental VALUES ("+ids[0]+"," + ids[1] + "," + rentalDate + "," + dueDate + ")";
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
                        deleteRequest(requestId);
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Request has been Approved", "alert('The Book has been Approved!')", true);
                    
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("default.aspx");
            }
        } 
    }

    private void deleteRequest(int requestId)
    {
                    string sqlCommand = "";
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

    private int[] grabRequest(int requestId)
    {
        int[] ids = new int[2];
        try
        {
                    string sqlCommand = "SELECT IssueId, UserId FROM Request WHERE RequestId ="+requestId;
                    conn.ConnectionString = conString;
                    SqlCommand cmd = conn.CreateCommand();

                    try
                    {
                        cmd.CommandText = sqlCommand;
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                          ids[0] = reader.GetInt32(0);
                          ids[1] = reader.GetInt32(1);
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
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Book Requested", "alert('The Book has been requested!')", true);
        }
        catch (Exception ex)
        {
            Response.Redirect("default.aspx");
        }
        return ids;
    }
}