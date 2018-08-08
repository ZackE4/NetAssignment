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

    private void dataBindGrid()
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
    }

    protected void btnRequests_Click(object sender, EventArgs e)
    {
        dataBindGrid();
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
                int requestId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
                DataRow dr = UserTool.GetUserInfo(Session["User"].ToString());
                if (dr["AccountType"].ToString().Equals("Librarian"))
                {
                    if (dr == null)
                    {
                        Response.Redirect("default.aspx");
                    }
                    else
                    {
                        int[] ids = grabRequest(requestId);
                        DateTime rentalDate = DateTime.Now;
                        DateTime dueDate = rentalDate.AddDays(7);
                        string sqlCommand = "INSERT INTO Rental (IssueId, UserId, RentalDate, DueDate, Fees) VALUES (" + ids[0] + "," + ids[1] + ",'" + rentalDate.ToString() + "','" + dueDate.ToString() + "'," + 0 + ")";
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
                    dataBindGrid();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Request has been Approved", "alert('The Book has been Approved!')", true);
                 }
                }
                else
                {
                    Response.Redirect("default.aspx");
                }
        } 
    }

    private void deleteRequest(int requestId)
    {
                    string sqlCommand = "DELETE FROM Request WHERE RequestId ="+requestId;
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

    protected void btnUsers_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex =2;
        dataBindGrid2();
        lblNewDate.Visible = false;
        txtNewDate.Visible = false;
        btnDateChange.Visible = false;
    }

    private void dataBindGrid2()
    {
            string sqlCommand = "SELECT Rental.RentalId, Rental.UserId, [User].Username, [User].FirstName, [User].LastName,  Rental.RentalDate, Rental.DueDate, Rental.ReturnDate, Rental.Fees, Rental.Comments FROM Rental INNER JOIN [User] ON Rental.UserId = [User].UserId";
            conn.ConnectionString = conString;
            SqlCommand cmd = conn.CreateCommand();

            try
            {
                cmd.CommandText = sqlCommand;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
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

    protected void btnDate_Click(object sender, EventArgs e)
    {
        if (GridView2.SelectedIndex == -1)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", "alert('An Error has occoured')", true);
        }
        else
        {
            lblNewDate.Visible = true;
            txtNewDate.Visible = true;
            btnDateChange.Visible = true;
            grabDate(GridView2.SelectedIndex);
        }
    }

    private void grabDate(int selectedIndex)
    {
        int rentalId = Convert.ToInt32(GridView2.SelectedRow.Cells[1].Text);
        string sqlCommand = "SELECT * FROM Rental WHERE RentalId = "+rentalId;
        conn.ConnectionString = conString;
        SqlCommand cmd = conn.CreateCommand();

        try
        {
            cmd.CommandText = sqlCommand;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DateTime published = reader.GetDateTime(4);
                txtNewDate.Text = published.ToShortDateString();
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

    protected void btnSearchUserId_Click(object sender, EventArgs e)
    {
        string userID = txtRentalUserId.Text;
        int userId = 0;
        if (!int.TryParse(userID, out userId))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('User Id for search needs to be a number')", true);
        }
        else
        {
            if (userId == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('User Id for search can not be empty or Zero')", true);
            }
            else
            {
                string sqlCommand = "SELECT Rental.RentalId, Rental.UserId, [User].Username, [User].FirstName, [User].LastName,  Rental.RentalDate, Rental.DueDate, Rental.ReturnDate, Rental.Fees, Rental.Comments FROM Rental INNER JOIN [User] ON Rental.UserId = [User].UserId WHERE Rental.UserId = @UserId";
                conn.ConnectionString = conString;
                SqlCommand cmd = conn.CreateCommand();

                try
                {
                    SqlParameter userParam = new SqlParameter();
                    userParam.ParameterName = "@UserId";
                    userParam.Value = userId;
                    cmd.CommandText = sqlCommand;
                    cmd.Parameters.Add(userParam);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
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
        }

        
    }



    protected void btnDateChange_Click(object sender, EventArgs e)
    {
        string published = txtNewDate.Text;
        DateTime publishedDate;
        if (!DateTime.TryParse(published, out publishedDate))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('You must enter a valid date for Published Date')", true);
        }
        else
        {
            int rentalId = Convert.ToInt32(GridView2.SelectedRow.Cells[1].Text);
            string sqlCommand = "UPDATE Rental SET DueDate = @DueDate WHERE RentalId =" + rentalId;
            conn.ConnectionString = conString;
            SqlCommand cmd = conn.CreateCommand();

            try
            {
                cmd.CommandText = sqlCommand;
                conn.Open();
                SqlParameter dueDateParam = new SqlParameter();
                dueDateParam.ParameterName = "@DueDate";
                dueDateParam.Value = publishedDate.ToString("yyyy-MM-dd");
                cmd.Parameters.Add(dueDateParam);
                cmd.ExecuteScalar();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Success", "alert('The Due Date has been changed!')", true);
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
            dataBindGrid2();
        }
    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        dataBindGrid2();
        grabDate(GridView2.SelectedIndex);
    }

    protected void btnSearchIssue_Click(object sender, EventArgs e)
    {
        string issueID = txtIssueId.Text;
        int issueId = 0;
        float dateDiff = 0;
        if (!int.TryParse(issueID, out issueId))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Issue Id for search needs to be a number')", true);
        }
        else
        {
            if (issueId == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Issue Id for search needs to be a number')", true);
            }
            else
            {
                string sqlCommand = "SELECT b.Title, i.Status, r.RentalDate, r.DueDate, r.ReturnDate, r.Fees, r.Comments, a.FirstName, a.LastName, Genre.Title, r.RentalId, r.IssueId, r.UserId AS Genre FROM Issue AS i INNER JOIN Rental AS r ON i.IssueId = r.IssueId INNER JOIN Book AS b ON i.BookId = b.BookId INNER JOIN Author AS a ON b.AuthorId = a.AuthorId INNER JOIN Genre ON b.GenreId = Genre.GenreId WHERE r.IssueId = @Issue";
                conn.ConnectionString = conString;
                SqlCommand cmd = conn.CreateCommand();

                try
                {
                    SqlParameter issueParam = new SqlParameter();
                    issueParam.ParameterName = "@Issue";
                    issueParam.Value = issueId;
                    cmd.CommandText = sqlCommand;
                    cmd.Parameters.Add(issueParam);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        lblIssueInfo.Text = "No Issue Found";
                    }
                    while (reader.Read())
                    {
                        dateDiff = (float)(DateTime.Now - reader.GetDateTime(3)).Days;
                        if (dateDiff <= 0)
                        {
                            dateDiff = 0;
                        }
                        string comments = reader.IsDBNull(6) ? null : reader.GetString(6);
                        if (reader.GetInt32(10) == 0 || reader.GetInt32(11) == 0 || reader.GetInt32(12) == 0)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", "alert('There was an issue getting the correct Record')", true);
                            btnReturnBook.Enabled = false;
                        }
                        else
                        {
                            lblIssueInfo.Text = "Book being returned is: <br/> Book Title: " + reader.GetString(0) + "<br/> Book Status: " + reader.GetString(1)
                                + "<br/> Rental Date: " + reader.GetDateTime(2).ToString() + "<br/> Due Date: " + reader.GetDateTime(3).ToString() + "<br/> Return Date: "
                                + DateTime.Now.ToString() + "<br/> Fees: $" + dateDiff + " <br/> Comments: " + comments + "<br/> Name of User Renting: "
                                + reader.GetString(7) + ", " + reader.GetString(8) + "<br/>  Genre: " + reader.GetString(9);
                            btnReturnBook.Enabled = true;
                        }
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
        }

    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
    }

    protected void btnFees_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;
        lblFee.Visible = false;
    }

    private void searchFee()
    {
        string userId = txtUserId.Text;
        int userID = 0;
        if (!int.TryParse(userId, out userID))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Issue Id for search needs to be a number')", true);
        }
        else
        {
            if (userID == 0)
            {

            }
            else
            {
                string sqlCommand = "SELECT AmountOwing FROM [User] WHERE UserId = @UserId";
                conn.ConnectionString = conString;
                SqlCommand cmd = conn.CreateCommand();

                try
                {
                    cmd.CommandText = sqlCommand;
                    conn.Open();
                    SqlParameter userIdParam = new SqlParameter();
                    userIdParam.ParameterName = "@UserId";
                    userIdParam.Value = txtUserId.Text;
                    cmd.Parameters.Add(userIdParam);
                    SqlDataReader reader = cmd.ExecuteReader();
                    string fee = " ";
                    if (!reader.HasRows)
                    {
                        lblFee.Text = "The Fee for the user is: 0";
                    }
                    while (reader.Read())
                    {
                        fee = reader.GetDouble(0).ToString();
                        lblFee.Text = "The Fee for the user is: " + fee;
                    }
                    lblFee.Visible = true;
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
    }

    protected void btnReturnBook_Click(object sender, EventArgs e)
    {
        int[] ids = getIds();
        float fee = updateUserAmountOwing(ids[2], ids[0]);
        updateIssue(ids[1]);
        updateRental(ids[0], fee);
    }

    private int[] getIds()
    {
                int[] ids = new int[3];
                string issueID = txtIssueId.Text;
                string sqlCommand = "SELECT RentalId, IssueId, UserId FROM Rental WHERE IssueId = @Issue";
                conn.ConnectionString = conString;
                SqlCommand cmd = conn.CreateCommand();

                try
                {
                    SqlParameter issueParam = new SqlParameter();
                    issueParam.ParameterName = "@Issue";
                    issueParam.Value = issueID;
                    cmd.CommandText = sqlCommand;
                    cmd.Parameters.Add(issueParam);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ids[0] = reader.GetInt32(0);
                        ids[1] = reader.GetInt32(1);
                        ids[2] = reader.GetInt32(2);
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
        return ids;
    }

    private float updateUserAmountOwing(int returnUserId, int returnRentalId)
    {
        float amountOwing = grabAmount(returnRentalId);
        if (amountOwing == 0)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", "alert('User Account remains the same amount owing')", true);
        }
        else
        {
            string sqlCommand = "UPDATE [User] SET AmountOwing = AmountOwing + @AmountOwe WHERE UserId=@UserId";
            conn.ConnectionString = conString;
            SqlCommand cmd = conn.CreateCommand();

            try
            {
                cmd.CommandText = sqlCommand;
                conn.Open();
                SqlParameter userParam = new SqlParameter();
                userParam.ParameterName = "@UserId";
                userParam.Value = returnUserId;
                SqlParameter amountParam = new SqlParameter();
                amountParam.ParameterName = "@AmountOwe";
                amountParam.Value = amountOwing;
                cmd.Parameters.Add(amountParam);
                cmd.Parameters.Add(userParam);
                cmd.ExecuteScalar();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Success", "alert('User Account updated!')", true);

            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", "alert('Updating amount owing has encountered an error')", true);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }
        return amountOwing;
    }

    private float grabAmount(int returnRentalId)
    {
        float dateDiff = 0;
                string sqlCommand = "SELECT Fees, DueDate FROM Rental WHERE RentalId = @RentalId";
                conn.ConnectionString = conString;
                SqlCommand cmd = conn.CreateCommand();

                try
                {
                    SqlParameter rentalParam = new SqlParameter();
                    rentalParam.ParameterName = "@RentalId";
                    rentalParam.Value = returnRentalId;
                    cmd.CommandText = sqlCommand;
                    cmd.Parameters.Add(rentalParam);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dateDiff = (float)(DateTime.Now - reader.GetDateTime(1)).Days;
                        dateDiff += (float) reader.GetInt32(0);
                        if (dateDiff <= 0)
                        {
                            dateDiff = 0;
                        } 
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
        return dateDiff;
    }

    private void updateRental(int returnRentalId, float fee)
    {
        string sqlCommand = "UPDATE Rental SET ReturnDate = @ReturnDate, Fees = @Fees WHERE RentalId=@RentalId";
        conn.ConnectionString = conString;
        SqlCommand cmd = conn.CreateCommand();

        try
        {
            cmd.CommandText = sqlCommand;
            conn.Open();
            SqlParameter rentalParam = new SqlParameter();
            rentalParam.ParameterName = "@RentalId";
            rentalParam.Value = returnRentalId;
            SqlParameter returnDateParam = new SqlParameter();
            returnDateParam.ParameterName = "@ReturnDate";
            returnDateParam.Value = DateTime.Now.ToString("yyyy-MM-dd");
            SqlParameter feeParam = new SqlParameter();
            feeParam.ParameterName = "@Fees";
            feeParam.Value = fee;
            cmd.Parameters.Add(feeParam);
            cmd.Parameters.Add(returnDateParam);
            cmd.Parameters.Add(rentalParam);
            cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", "alert('Deleting Rental Record has encountered an error')", true);
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }
    }

    private void updateIssue(int returnIssueId)
    {
        string sqlCommand = "UPDATE Issue SET Status = 'Available' WHERE IssueId=@IssueId";
        conn.ConnectionString = conString;
        SqlCommand cmd = conn.CreateCommand();

        try
        {
            cmd.CommandText = sqlCommand;
            conn.Open();
            SqlParameter issueParam = new SqlParameter();
            issueParam.ParameterName = "@IssueId";
            issueParam.Value = returnIssueId;
            cmd.Parameters.Add(issueParam);
            cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", "alert('Updating status for issue has encountered an error')", true);
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }
    }

    protected void btnFeesFind_Click(object sender, EventArgs e)
    {
        searchFee();
    }

    protected void btnPayFees_Click(object sender, EventArgs e)
    {
        string userId = txtUserId.Text;
        int userID = 0;
        int RentalId = 0;
        float fees = 0;
        Boolean insertP = false;
        if (!int.TryParse(userId, out userID))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Issue Id for search needs to be a number')", true);
        }
        else
        {
            if (userID == 0)
            {

            }
            else
            {
                string sqlCommand = "SELECT * FROM Rental WHERE UserId = @UserId";
                conn.ConnectionString = conString;
                SqlCommand cmd = conn.CreateCommand();

                try
                {
                    cmd.CommandText = sqlCommand;
                    conn.Open();
                    SqlParameter userIdParam = new SqlParameter();
                    userIdParam.ParameterName = "@UserId";
                    userIdParam.Value = userID;
                    cmd.Parameters.Add(userIdParam);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        insertP = true;
                        RentalId = reader.GetInt32(0);
                        fees = (float) reader.GetInt32(6);
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
                if (insertP)
                {
                    insertPayment(userID, RentalId, fees);
                }
            }
        }
    }

    private void insertPayment(int userID, int rentalId, float fees)
    {
               string sqlCommand = "INSERT INTO Payment (RentalId, UserId, Fees, AmountPaid, DateOfPayment) SET (@RentalId, @UserId, @Fees, @Fees, GETDATE())  WHERE UserId = @UserId";
                conn.ConnectionString = conString;
                SqlCommand cmd = conn.CreateCommand();
                try
                {
                    cmd.CommandText = sqlCommand;
                    conn.Open();
                    SqlParameter userIdParam = new SqlParameter();
                    userIdParam.ParameterName = "@UserId";
                    userIdParam.Value = userID;
                    SqlParameter rentalParam = new SqlParameter();
                    rentalParam.ParameterName = "@RentalId";
                    rentalParam.Value = rentalId;
                    SqlParameter feesParam = new SqlParameter();
                    feesParam.ParameterName = "@Fees";
                    feesParam.Value = rentalId;
                    cmd.Parameters.Add(feesParam);
                    cmd.Parameters.Add(rentalParam);
                    cmd.Parameters.Add(userIdParam);
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
        subtractUser(userID);
    }

    private void subtractUser(int userId)
    {
        string sqlCommand = "UPDATE [User] SET AmountOwing = 0 WHERE UserId = @UserId";
        conn.ConnectionString = conString;
        SqlCommand cmd = conn.CreateCommand();
        try
        {
            cmd.CommandText = sqlCommand;
            conn.Open();
            SqlParameter userIdParam = new SqlParameter();
            userIdParam.ParameterName = "@UserId";
            userIdParam.Value = userId;
            cmd.Parameters.Add(userIdParam);
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

    protected void btnReport1_Click(object sender, EventArgs e)
    {
        Response.Redirect(".aspx");
    }

    protected void btnReport2_Click(object sender, EventArgs e)
    {
        Response.Redirect(".aspx");
    }

    protected void btnReport3_Click(object sender, EventArgs e)
    {
        Response.Redirect(".aspx");
    }
}