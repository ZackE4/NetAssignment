/// <summary>
/// This class is the code behind the administrator page for searching and editing objects in the database including
/// Genre, Publisher, Book, Author, Issue
/// 
/// By Zack Eichler
/// </summary>

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Selects the object type to search/edit, changes the view of the multiview accordingly
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = ddSelector.SelectedIndex;
    }

    /// <summary>
    /// Selects users from the database and populates a gridview with results based on search conditions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchUser_Click(object sender, EventArgs e)
    {
        string username = tbUserName.Text;
        string lName = tbLastName.Text;
        string email = tbEmail.Text;

        if (String.IsNullOrEmpty(username) && String.IsNullOrEmpty(lName) && String.IsNullOrEmpty(email))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('You must provide either username, email or last name.')", true);
        }
        else
        {
            SqlConnection LibConnect = new SqlConnection();
            LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
            SqlCommand cmd = LibConnect.CreateCommand();

            try
            {
                string query = "Select UserId, Username, AccountType, FirstName, LastName FROM [User] WHERE Username Like @User OR LastName Like @LName OR email Like @Email";
                SqlParameter userParam = new SqlParameter();
                userParam.ParameterName = "@User";
                if (String.IsNullOrEmpty(username))
                {
                    userParam.Value = username;
                }
                else
                {
                    userParam.Value = username + "%";
                }
                SqlParameter lnameparam = new SqlParameter();
                lnameparam.ParameterName = "@LName";
                if (String.IsNullOrEmpty(lName))
                {
                    lnameparam.Value = lName;
                }
                else
                {
                    lnameparam.Value = lName + "%";
                }
                SqlParameter emailparam = new SqlParameter();
                emailparam.ParameterName = "@Email";
                if (String.IsNullOrEmpty(email))
                {
                    emailparam.Value = email;
                }
                else
                {

                    emailparam.Value = email + "%";
                }

                cmd.CommandText = query;
                cmd.Parameters.Add(userParam);
                cmd.Parameters.Add(lnameparam);
                cmd.Parameters.Add(emailparam);


                LibConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                GridView1.DataSource = dt;
                GridView1.DataBind();
                reader.Close();

            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();
            }
        }
    }

    /// <summary>
    /// Populates edit textboxes with data from selected item on the gridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        try
        {
            string query = "Select * From [User] WHERE UserId = @User";
            SqlParameter userParam = new SqlParameter();
            userParam.ParameterName = "@User";
            userParam.Value = userId;

            cmd.CommandText = query;
            cmd.Parameters.Add(userParam);


            LibConnect.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                tbEditFName.Text = dr["FirstName"].ToString();
                tbEditLastName.Text = dr["LastName"].ToString();
                ddEditAccType.SelectedValue = dr["AccountType"].ToString();
                tbEditAddress.Text = dr["Address"].ToString();
                tbEditEmail.Text = dr["Email"].ToString();
                tbEditBookLimit.Text = dr["BookLimit"].ToString();
                tbEditReIssue.Text = dr["ReIssueLimit"].ToString();
                tbEditComments.Text = dr["Comments"].ToString();
            }
            reader.Close();

        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
        }
        finally
        {
            cmd.Dispose();
            LibConnect.Close();
        }

    }

    /// <summary>
    /// Updates book table with new values from edit textboxes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBookEditSubmit_Click(object sender, EventArgs e)
    {
        string title = tbEditBookTitle.Text;
        string published = tbEditPublishedDate.Text;
        DateTime publishedDate;
        string cover = ddCoverType.SelectedValue;

        if (!DateTime.TryParse(published, out publishedDate))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('You must enter a valid date for Published Date')", true);
        }
        else if (String.IsNullOrEmpty(title) || String.IsNullOrEmpty(cover))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('All Fields require values.')", true);
        }
        else
        {
            int bookId = Convert.ToInt32(GridView2.SelectedRow.Cells[1].Text);
            SqlConnection LibConnect = new SqlConnection();
            LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
            SqlCommand cmd = LibConnect.CreateCommand();

            try
            {
                string query = "Update [Book] Set Title = @Title, PublishedDate = @PublishedDate, CoverType = @Cover WHERE BookId = @bookid";
                SqlParameter bookIdParam = new SqlParameter();
                bookIdParam.ParameterName = "@bookid";
                bookIdParam.Value = bookId;
                SqlParameter titleParam = new SqlParameter();
                titleParam.ParameterName = "@Title";
                titleParam.Value = title;
                SqlParameter publishedDateParam = new SqlParameter();
                publishedDateParam.ParameterName = "@PublishedDate";
                publishedDateParam.Value = publishedDate.ToString("yyyy-MM-dd");
                SqlParameter coverTypeParam = new SqlParameter();
                coverTypeParam.ParameterName = "@Cover";
                coverTypeParam.Value = cover;

                cmd.CommandText = query;
                cmd.Parameters.Add(bookIdParam);
                cmd.Parameters.Add(titleParam);
                cmd.Parameters.Add(publishedDateParam);
                cmd.Parameters.Add(coverTypeParam);

                LibConnect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong, please verify all fields and try again.')", true);
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Book Updated.')", true);
                ClearEditBookTextBoxes();
            }
        }
    }

    /// <summary>
    /// Updates user table with new values from edit textboxes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUserEditSubmit_Click(object sender, EventArgs e)
    {
        string fname = tbEditFName.Text;
        string lname = tbEditLastName.Text;
        string accountType = ddEditAccType.SelectedValue;
        string address = tbEditAddress.Text;
        string email = tbEditEmail.Text;
        string bookLimit = tbEditBookLimit.Text;
        string reissuelimit = tbEditReIssue.Text;
        string comments = tbEditComments.Text;

        if (String.IsNullOrEmpty(fname) ||
            String.IsNullOrEmpty(lname) ||
            String.IsNullOrEmpty(accountType) ||
            String.IsNullOrEmpty(address) ||
            String.IsNullOrEmpty(email) ||
            String.IsNullOrEmpty(bookLimit) ||
            String.IsNullOrEmpty(reissuelimit))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('All User fields must have values')", true);
        }
        else
        {
            int userId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            SqlConnection LibConnect = new SqlConnection();
            LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
            SqlCommand cmd = LibConnect.CreateCommand();

            try
            {
                string query = "Update [User] Set FirstName = @fname, LastName = @lname, AccountType = @actype, Address = @addr, Email = @email, BookLimit = @booklimit, ReIssueLimit = @relimit, Comments = @Comments WHERE UserId = @userid";
                SqlParameter userParam = new SqlParameter();
                userParam.ParameterName = "@userid";
                userParam.Value = userId;

                SqlParameter fnameparam = new SqlParameter();
                fnameparam.ParameterName = "@fname";
                fnameparam.Value = fname;

                SqlParameter lnameparam = new SqlParameter();
                lnameparam.ParameterName = "@lname";
                lnameparam.Value = lname;

                SqlParameter actparam = new SqlParameter();
                actparam.ParameterName = "@actype";
                actparam.Value = accountType;

                SqlParameter addrParam = new SqlParameter();
                addrParam.ParameterName = "@addr";
                addrParam.Value = address;

                SqlParameter emailParam = new SqlParameter();
                emailParam.ParameterName = "@email";
                emailParam.Value = email;

                SqlParameter booklimitparam = new SqlParameter();
                booklimitparam.ParameterName = "@booklimit";
                booklimitparam.Value = Convert.ToInt32(bookLimit);

                SqlParameter reissueparam = new SqlParameter();
                reissueparam.ParameterName = "@relimit";
                reissueparam.Value = Convert.ToInt32(reissuelimit);

                SqlParameter commentparam = new SqlParameter();
                commentparam.ParameterName = "@Comments";
                commentparam.Value = comments;

                cmd.CommandText = query;
                cmd.Parameters.Add(userParam);
                cmd.Parameters.Add(fnameparam);
                cmd.Parameters.Add(lnameparam);
                cmd.Parameters.Add(actparam);
                cmd.Parameters.Add(addrParam);
                cmd.Parameters.Add(emailParam);
                cmd.Parameters.Add(booklimitparam);
                cmd.Parameters.Add(reissueparam);
                cmd.Parameters.Add(commentparam);


                LibConnect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong, please verify all fields and try again.')", true);

            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('User Updated.')", true);
                ClearEditUserTextBoxes();
            }
        }
    }

    /// <summary>
    /// Selects Books from the database and populates a gridview with results based on search conditions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchBook_Click(object sender, EventArgs e)
    {
        string bookTitle = tbBookTitle.Text;

        if (String.IsNullOrEmpty(bookTitle))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('You must provide a book title)", true);
        }
        else
        {
            SqlConnection LibConnect = new SqlConnection();
            LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
            SqlCommand cmd = LibConnect.CreateCommand();

            try
            {
                string query = "Select BookId, Title, PublishedDate, CoverType FROM Book WHERE Title Like @bookTitle";
                SqlParameter booktitleParam = new SqlParameter();
                booktitleParam.ParameterName = "@bookTitle";
                booktitleParam.Value = bookTitle + "%";

                cmd.CommandText = query;
                cmd.Parameters.Add(booktitleParam);

                LibConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                GridView2.DataSource = dt;
                GridView2.DataBind();
                reader.Close();

            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();
            }
        }

    }

    /// <summary>
    /// Populates edit textboxes for Book with data from selected item on the gridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int bookid = Convert.ToInt32(GridView2.SelectedRow.Cells[1].Text);

        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        try
        {
            string query = "Select * From [Book] WHERE BookId = @Book";
            SqlParameter bookParam = new SqlParameter();
            bookParam.ParameterName = "@Book";
            bookParam.Value = bookid;

            cmd.CommandText = query;
            cmd.Parameters.Add(bookParam);


            LibConnect.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);


            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                tbEditBookTitle.Text = dr["Title"].ToString();
                tbEditPublishedDate.Text = Convert.ToDateTime(dr["PublishedDate"].ToString()).ToString("yyyy-MM-dd");
                ddCoverType.SelectedValue = dr["CoverType"].ToString();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
        }
        finally
        {
            cmd.Dispose();
            LibConnect.Close();
        }
    }

    /// <summary>
    /// Selects Authors from the database and populates a gridview with results based on search conditions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAuthorSearch_Click(object sender, EventArgs e)
    {
        string lastname = tbAuthorLastName.Text;

        if (String.IsNullOrEmpty(lastname))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('You must provide a last name to search')", true);
        }
        else
        {
            SqlConnection LibConnect = new SqlConnection();
            LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
            SqlCommand cmd = LibConnect.CreateCommand();

            try
            {
                string query = "Select AuthorId, FirstName, SecondName, LastName, DOB FROM [Author] WHERE LastName like @lastname";
                SqlParameter nameParam = new SqlParameter();
                nameParam.ParameterName = "@lastname";
                nameParam.Value = lastname + "%";

                cmd.CommandText = query;
                cmd.Parameters.Add(nameParam);

                LibConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                GridView3.DataSource = dt;
                GridView3.DataBind();
                reader.Close();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();
            }
        }
    }

    /// <summary>
    /// Clears all textboxes for edit user view
    /// </summary>
    private void ClearEditUserTextBoxes()
    {
        tbEditFName.Text = "";
        tbEditLastName.Text = "";
        tbEditAddress.Text = "";
        tbEditEmail.Text = "";
        tbEditBookLimit.Text = "";
        tbEditReIssue.Text = "";
        tbEditComments.Text = "";
        GridView1.DataSource = null;
        GridView1.DataBind();
        tbUserName.Text = "";
        tbLastName.Text = "";
        tbEmail.Text = "";
    }

    /// <summary>
    /// Clears all textboxes for edit book view
    /// </summary>
    private void ClearEditBookTextBoxes()
    {
        tbEditBookTitle.Text = "";
        tbEditPublishedDate.Text = "";
        tbBookTitle.Text = "";
        GridView2.DataSource = null;
        GridView2.DataBind();
    }

    /// <summary>
    /// Populates edit textboxes for Author with data from selected item on the gridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {
        int authorid = Convert.ToInt32(GridView3.SelectedRow.Cells[1].Text);

        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        try
        {
            string query = "Select * From [Author] WHERE AuthorId = @author";
            SqlParameter authorparam = new SqlParameter();
            authorparam.ParameterName = "@author";
            authorparam.Value = authorid;

            cmd.CommandText = query;
            cmd.Parameters.Add(authorparam);


            LibConnect.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);


            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                tbEditAuthorFirstName.Text = dr["FirstName"].ToString();
                tbEditSecondName.Text = dr["SecondName"].ToString();
                tbEditAuthorLastName.Text = dr["LastName"].ToString();
                tbEditDOB.Text = Convert.ToDateTime(dr["DOB"].ToString()).ToString("yyyy-MM-dd");
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
        }
        finally
        {
            cmd.Dispose();
            LibConnect.Close();
        }
    }

    /// <summary>
    /// Updates Author table with new values from edit textboxes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEditAuthorSubmit_Click(object sender, EventArgs e)
    {
        string firstname = tbEditAuthorFirstName.Text;
        string secondname = tbEditSecondName.Text;
        string lastname = tbEditAuthorLastName.Text;
        string dob = tbEditDOB.Text;
        DateTime dobDate;

        if (!DateTime.TryParse(dob, out dobDate))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('You must enter a valid date for DOB')", true);
        }
        else if (String.IsNullOrEmpty(firstname) || String.IsNullOrEmpty(lastname))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('First and Last name are required.')", true);
        }
        else
        {
            int authorId = Convert.ToInt32(GridView3.SelectedRow.Cells[1].Text);
            SqlConnection LibConnect = new SqlConnection();
            LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
            SqlCommand cmd = LibConnect.CreateCommand();
            try
            {
                string query = "Update [Author] Set FirstName = @FirstName, SecondName = @SecondName, LastName = @LastName, DOB = @DOB WHERE AuthorId = @AuthorId";
                SqlParameter authorParam = new SqlParameter();
                authorParam.ParameterName = "@AuthorId";
                authorParam.Value = authorId;
                SqlParameter firstNameParam = new SqlParameter();
                firstNameParam.ParameterName = "@FirstName";
                firstNameParam.Value = firstname;
                SqlParameter secondNameParam = new SqlParameter();
                secondNameParam.ParameterName = "@SecondName";
                secondNameParam.Value = secondname;
                SqlParameter lastNameParam = new SqlParameter();
                lastNameParam.ParameterName = "@LastName";
                lastNameParam.Value = lastname;
                SqlParameter DOBparam = new SqlParameter();
                DOBparam.ParameterName = "@DOB";
                DOBparam.Value = dobDate.ToString("yyyy-MM-dd");


                cmd.CommandText = query;
                cmd.Parameters.Add(authorParam);
                cmd.Parameters.Add(firstNameParam);
                cmd.Parameters.Add(secondNameParam);
                cmd.Parameters.Add(lastNameParam);
                cmd.Parameters.Add(DOBparam);


                LibConnect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong, please verify all fields and try again.')", true);
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Author Updated.')", true);
                ClearEditAuthorTextBoxes();
            }
        }
    }

    /// <summary>
    /// Clears all textboxes from edit author viw
    /// </summary>
    private void ClearEditAuthorTextBoxes()
    {
        tbEditAuthorFirstName.Text = "";
        tbEditSecondName.Text = "";
        tbEditAuthorLastName.Text = "";
        tbEditDOB.Text = "";
        GridView3.DataSource = null;
        GridView3.DataBind();
        tbAuthorLastName.Text = "";
    }

    /// <summary>
    /// Selects publishers from the database and loads them into a gridview based on search conditions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPublisherSearch_Click(object sender, EventArgs e)
    {
        string pubName = tbPubName.Text;
        if (String.IsNullOrEmpty(pubName))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('You must provide a publisher name)", true);
        }
        else
        {
            SqlConnection LibConnect = new SqlConnection();
            LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
            SqlCommand cmd = LibConnect.CreateCommand();

            try
            {
                string query = "Select PublisherId, Name, City, Country FROM Publisher WHERE Name Like @pubname";
                SqlParameter publisherNameParam = new SqlParameter();
                publisherNameParam.ParameterName = "@pubname";
                publisherNameParam.Value = pubName + "%";

                cmd.CommandText = query;
                cmd.Parameters.Add(publisherNameParam);

                LibConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                GridView4.DataSource = dt;
                GridView4.DataBind();
                reader.Close();

            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();
            }
        }
    }

    /// <summary>
    /// Populates edit publisher textboxes with values from selected publisher
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
    {
        int pubId = Convert.ToInt32(GridView4.SelectedRow.Cells[1].Text);

        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        try
        {
            string query = "Select * From [Publisher] WHERE PublisherId = @pubid";
            SqlParameter pubParam = new SqlParameter();
            pubParam.ParameterName = "@pubid";
            pubParam.Value = pubId;

            cmd.CommandText = query;
            cmd.Parameters.Add(pubParam);


            LibConnect.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);


            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                tbEditPubName.Text = dr["Name"].ToString();
                tbEditPubAddress.Text = dr["Address"].ToString();
                tbEditPubCity.Text = dr["City"].ToString();
                tbEditPubProv.Text = dr["Province/State"].ToString();
                tbEditPubCountry.Text = dr["Country"].ToString();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
        }
        finally
        {
            cmd.Dispose();
            LibConnect.Close();
        }
    }

    /// <summary>
    /// Updates publisher table with new values
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEditPubSubmit_Click(object sender, EventArgs e)
    {
        string name = tbEditPubName.Text;
        string addr = tbEditPubAddress.Text;
        string city = tbEditPubCity.Text;
        string prov = tbEditPubProv.Text;
        string country = tbEditPubCountry.Text;

        if (String.IsNullOrEmpty(name) ||
            String.IsNullOrEmpty(addr) ||
            String.IsNullOrEmpty(prov) ||
            String.IsNullOrEmpty(addr) ||
            String.IsNullOrEmpty(country))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('All Fields require values.')", true);
        }
        else
        {
            int pubId = Convert.ToInt32(GridView4.SelectedRow.Cells[1].Text);
            SqlConnection LibConnect = new SqlConnection();
            LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
            SqlCommand cmd = LibConnect.CreateCommand();

            try
            {
                string query = "Update [Publisher] Set Name = @Name, Address = @Address, City = @City, [Province/State] = @Prov, Country = @Country WHERE PublisherId = @pubid";
                SqlParameter pubIdParam = new SqlParameter();
                pubIdParam.ParameterName = "@pubid";
                pubIdParam.Value = pubId;
                SqlParameter nameParam = new SqlParameter();
                nameParam.ParameterName = "@Name";
                nameParam.Value = name;
                SqlParameter addrParam = new SqlParameter();
                addrParam.ParameterName = "@Address";
                addrParam.Value = addr;
                SqlParameter cityParam = new SqlParameter();
                cityParam.ParameterName = "@City";
                cityParam.Value = city;
                SqlParameter provParam = new SqlParameter();
                provParam.ParameterName = "@Prov";
                provParam.Value = prov;
                SqlParameter countryParam = new SqlParameter();
                countryParam.ParameterName = "@Country";
                countryParam.Value = country;

                cmd.CommandText = query;
                cmd.Parameters.Add(pubIdParam);
                cmd.Parameters.Add(nameParam);
                cmd.Parameters.Add(addrParam);
                cmd.Parameters.Add(cityParam);
                cmd.Parameters.Add(provParam);
                cmd.Parameters.Add(countryParam);


                LibConnect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong, please verify all fields and try again.')", true);
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Publisher Updated.')", true);
                ClearEditPublisherTextBoxes();
            }
        }

    }

    /// <summary>
    /// Clears all textboxes in edit publisher view
    /// </summary>
    private void ClearEditPublisherTextBoxes()
    {
        tbEditPubName.Text = "";
        tbEditPubAddress.Text = "";
        tbEditPubCity.Text = "";
        tbEditPubProv.Text = "";
        tbEditPubCountry.Text = "";
        GridView4.DataSource = null;
        GridView4.DataBind();
        tbPubName.Text = "";
    }
    
    /// <summary>
    /// Selects genres from the database and loads them into a gridview based on genre title
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenreSearch_Click(object sender, EventArgs e)
    {
        string genreName = tbGenreName.Text;
        if (String.IsNullOrEmpty(genreName))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('You must provide a genre name)", true);
        }
        else
        {
            SqlConnection LibConnect = new SqlConnection();
            LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
            SqlCommand cmd = LibConnect.CreateCommand();

            try
            {
                string query = "Select GenreId, Title, Rating FROM Genre WHERE Title Like @genrename";
                SqlParameter genreParam = new SqlParameter();
                genreParam.ParameterName = "@genrename";
                genreParam.Value = genreName + "%";

                cmd.CommandText = query;
                cmd.Parameters.Add(genreParam);

                LibConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                GridView5.DataSource = dt;
                GridView5.DataBind();
                reader.Close();

            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();
            }
        }
    }

    /// <summary>
    /// Populates edit genre textboxes with values from selected genre in gridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
    {
        int genreId = Convert.ToInt32(GridView5.SelectedRow.Cells[1].Text);

        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        try
        {
            string query = "Select * From [Genre] WHERE GenreId = @Genre";
            SqlParameter genreParam = new SqlParameter();
            genreParam.ParameterName = "@Genre";
            genreParam.Value = genreId;

            cmd.CommandText = query;
            cmd.Parameters.Add(genreParam);


            LibConnect.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);


            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                tbEditGenreName.Text = dr["Title"].ToString();
                tbEditRating.Text = dr["Rating"].ToString();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
        }
        finally
        {
            cmd.Dispose();
            LibConnect.Close();
        }
    }

    /// <summary>
    /// Updates genre in the database with new values from edit textboxes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmitEditGenre_Click(object sender, EventArgs e)
    {
        string title = tbEditGenreName.Text;
        string rating = tbEditRating.Text;

        if (String.IsNullOrEmpty(title) ||
            String.IsNullOrEmpty(rating))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('All Fields require values.')", true);
        }
        else
        {
            int genreId = Convert.ToInt32(GridView5.SelectedRow.Cells[1].Text);
            SqlConnection LibConnect = new SqlConnection();
            LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
            SqlCommand cmd = LibConnect.CreateCommand();

            try
            {
                string query = "Update [Genre] Set Title = @Title, Rating = @Rating WHERE GenreId = @GenreId";
                SqlParameter genreIdParam = new SqlParameter();
                genreIdParam.ParameterName = "@GenreId";
                genreIdParam.Value = genreId;
                SqlParameter titleParam = new SqlParameter();
                titleParam.ParameterName = "@Title";
                titleParam.Value = title;
                SqlParameter ratingParam = new SqlParameter();
                ratingParam.ParameterName = "@Rating";
                ratingParam.Value = rating;

                cmd.CommandText = query;
                cmd.Parameters.Add(genreIdParam);
                cmd.Parameters.Add(titleParam);
                cmd.Parameters.Add(ratingParam);

                LibConnect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong, please verify all fields and try again.')", true);
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Genre Updated.')", true);
                ClearEditGenreTextBoxes();
            }
        }
    }

    /// <summary>
    /// Clears all textboxes in the edit genre view
    /// </summary>
    private void ClearEditGenreTextBoxes()
    {
        tbEditGenreName.Text = "";
        tbEditRating.Text = "";
        GridView5.DataSource = null;
        GridView5.DataBind();
        tbGenreName.Text = "";
    }

    /// <summary>
    /// Deletes selected genre in gridview from database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeleteGenre_Click(object sender, EventArgs e)
    {
        int genreId = Convert.ToInt32(GridView5.SelectedRow.Cells[1].Text);
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        try
        {
            string query = "Delete From [Genre] WHERE GenreId = @Genre";
            SqlParameter genreParam = new SqlParameter();
            genreParam.ParameterName = "@Genre";
            genreParam.Value = genreId;

            cmd.CommandText = query;
            cmd.Parameters.Add(genreParam);


            LibConnect.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
        }
        finally
        {
            cmd.Dispose();
            LibConnect.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Genre Deleted.')", true);
            ClearEditGenreTextBoxes();
        }
    }

    /// <summary>
    /// Deletes selected publisher in gridview from database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeletePublisher_Click(object sender, EventArgs e)
    {
        int pubId = Convert.ToInt32(GridView4.SelectedRow.Cells[1].Text);
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        try
        {
            string query = "Delete From [Publisher] WHERE PublisherId = @pubid";
            SqlParameter pubParam = new SqlParameter();
            pubParam.ParameterName = "@pubid";
            pubParam.Value = pubId;

            cmd.CommandText = query;
            cmd.Parameters.Add(pubParam);


            LibConnect.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
        }
        finally
        {
            cmd.Dispose();
            LibConnect.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Publisher Deleted.')", true);
            ClearEditPublisherTextBoxes();
        }
    }

    /// <summary>
    /// Deletes selected Author in gridview from database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeleteAuthor_Click(object sender, EventArgs e)
    {
        int authorId = Convert.ToInt32(GridView3.SelectedRow.Cells[1].Text);
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        try
        {
            string query = "Delete From [Author] WHERE AuthorId = @authorid";
            SqlParameter authParam = new SqlParameter();
            authParam.ParameterName = "@authorid";
            authParam.Value = authorId;

            cmd.CommandText = query;
            cmd.Parameters.Add(authParam);


            LibConnect.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
        }
        finally
        {
            cmd.Dispose();
            LibConnect.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Author Deleted.')", true);
            ClearEditAuthorTextBoxes();
        }
    }

    /// <summary>
    /// Deletes selected Book in gridview from database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeleteBook_Click(object sender, EventArgs e)
    {
        int bookId = Convert.ToInt32(GridView2.SelectedRow.Cells[1].Text);
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        try
        {
            string query = "Delete From [Book] WHERE BookId = @bookid";
            SqlParameter bookParam = new SqlParameter();
            bookParam.ParameterName = "@bookid";
            bookParam.Value = bookId;

            cmd.CommandText = query;
            cmd.Parameters.Add(bookParam);


            LibConnect.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
        }
        finally
        {
            cmd.Dispose();
            LibConnect.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Book Deleted.')", true);
            ClearEditBookTextBoxes();
        }
    }

    /// <summary>
    /// Deletes selected User in gridview from database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeleteUser_Click(object sender, EventArgs e)
    {
        int userId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        try
        {
            string query = "Delete From [User] WHERE UserId = @userid";
            SqlParameter userParam = new SqlParameter();
            userParam.ParameterName = "@userid";
            userParam.Value = userId;

            cmd.CommandText = query;
            cmd.Parameters.Add(userParam);


            LibConnect.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
        }
        finally
        {
            cmd.Dispose();
            LibConnect.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('User Deleted.')", true);
            ClearEditUserTextBoxes();
        }
    }
}