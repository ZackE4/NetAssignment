/// <summary>
/// This class is the code behind the administrator page for adding new objects for to the database including
/// Genre, Publisher, Book, Author, Issue
/// 
/// By Zack Eichler
/// </summary>

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Changes the multiview to the view for the corresponding object type
    /// </summary>
    protected void ddSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = ddSelector.SelectedIndex;
    }

    /// <summary>
    /// Inserts new genre into the table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddGenre_Click(object sender, EventArgs e)
    {
        bool addSuccess = true;
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        string title = tbAddGenreTitle.Text;
        string rating = tbAddGenreRating.Text;

        if (String.IsNullOrEmpty(title) ||
            String.IsNullOrEmpty(rating))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Please enter data for all fields')", true);
            addSuccess = false;
        }
        else
        {
            try
            {
                string query = "Insert Into [Genre] (Title, Rating) VALUES(@Title, @Rating)";
                SqlParameter titleParam = new SqlParameter();
                titleParam.ParameterName = "@Title";
                titleParam.Value = title;
                SqlParameter ratingParam = new SqlParameter();
                ratingParam.ParameterName = "@Rating";
                ratingParam.Value = rating;

                cmd.CommandText = query;
                cmd.Parameters.Add(titleParam);
                cmd.Parameters.Add(ratingParam);

                LibConnect.Open();
                var result = cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                addSuccess = false;
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();

                if (addSuccess)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Success", "alert('Genre Added.')", true);
                    tbAddGenreTitle.Text = "";
                    tbAddGenreRating.Text = "";
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
                }
            }
        }
    }


    /// <summary>
    /// Inserts new publisher into table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddPub_Click(object sender, EventArgs e)
    {
        bool addSuccess = true;
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        string name = tbAddPubName.Text;
        string addr = tbAddPubAddr.Text;
        string city = tbAddPubCity.Text;
        string prov = tbAddPubProv.Text;
        string country = tbAddPubCountry.Text;



        if (String.IsNullOrEmpty(name) ||
            String.IsNullOrEmpty(addr) ||
            String.IsNullOrEmpty(city) ||
            String.IsNullOrEmpty(prov) ||
            String.IsNullOrEmpty(country))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Please enter data for all fields')", true);
            addSuccess = false;
        }
        else
        {
            try
            {
                string query = "Insert Into [Publisher] (Name, Address, City, [Province/State], Country) VALUES(@Name, @Address, @City, @Prov, @Country)";
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
                cmd.Parameters.Add(nameParam);
                cmd.Parameters.Add(addrParam);
                cmd.Parameters.Add(cityParam);
                cmd.Parameters.Add(provParam);
                cmd.Parameters.Add(countryParam);

                LibConnect.Open();
                var result = cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                addSuccess = false;
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();

                if (addSuccess)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Success", "alert('Publisher Added.')", true);
                    tbAddPubName.Text = "";
                    tbAddPubAddr.Text = "";
                    tbAddPubCity.Text = "";
                    tbAddPubProv.Text = "";
                    tbAddPubCountry.Text = "";
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
                }
            }
        }
    }

    /// <summary>
    /// Inserts new author into table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddAuthor_Click(object sender, EventArgs e)
    {
        bool addSuccess = true;
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        string fname = tbAddAuthorFname.Text;
        string sname = tbAddAuthorSname.Text;
        string lname = tbAddAuthorLname.Text;
        string dob = tbAddAuthorDOB.Text;
        DateTime dobDate;

        if (String.IsNullOrEmpty(fname) ||
            String.IsNullOrEmpty(sname) ||
            String.IsNullOrEmpty(lname) ||
            String.IsNullOrEmpty(dob) ||
            !DateTime.TryParse(dob, out dobDate))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Please enter data for all fields, and ensure the date is valid')", true);
            addSuccess = false;
        }
        else
        {
            try
            {
                string query = "Insert Into [Author] (FirstName, SecondName, LastName, DOB) VALUES(@FirstName, @SecondName, @LastName, @DOB)";
                SqlParameter fNameParam = new SqlParameter();
                fNameParam.ParameterName = "@FirstName";
                fNameParam.Value = fname;
                SqlParameter snameParam = new SqlParameter();
                snameParam.ParameterName = "@SecondName";
                snameParam.Value = sname;
                SqlParameter lnameParam = new SqlParameter();
                lnameParam.ParameterName = "@LastName";
                lnameParam.Value = lname;
                SqlParameter dobParam = new SqlParameter();
                dobParam.ParameterName = "@DOB";
                dobParam.Value = dobDate.ToString("yyyy-MM-dd");

                cmd.CommandText = query;
                cmd.Parameters.Add(fNameParam);
                cmd.Parameters.Add(snameParam);
                cmd.Parameters.Add(lnameParam);
                cmd.Parameters.Add(dobParam);

                LibConnect.Open();
                var result = cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                addSuccess = false;
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();

                if (addSuccess)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Success", "alert('Author Added.')", true);
                    tbAddAuthorFname.Text = "";
                    tbAddAuthorSname.Text = "";
                    tbAddAuthorLname.Text = "";
                    tbAddAuthorDOB.Text = "";
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
                }
            }
        }
    }

    /// <summary>
    /// Inserts new Issue into table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddIssue_Click(object sender, EventArgs e)
    {
        bool addSuccess = true;
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        string bookId = tbAddIssueBookId.Text;
        string printDate = tbAddIssuePrintDate.Text;
        DateTime printDatetime;
        string comments = tbAddIssueComments.Text;

        if (String.IsNullOrEmpty(bookId) ||
            String.IsNullOrEmpty(printDate) ||
            !DateTime.TryParse(printDate, out printDatetime))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Please enter data for all fields and ensure the date is a proper format')", true);
            addSuccess = false;
        }
        else
        {
            try
            {
                string query = "Insert Into [Issue] (BookId, PrintDate, Status, Comments) VALUES(@BookId, @PrintDate, 'Available', @Comments)";
                SqlParameter bookIdParam = new SqlParameter();
                bookIdParam.ParameterName = "@BookId";
                bookIdParam.Value = bookId;
                SqlParameter printDateParam = new SqlParameter();
                printDateParam.ParameterName = "@PrintDate";
                printDateParam.Value = printDatetime.ToString("yyyy-MM-dd");
                SqlParameter commentsParam = new SqlParameter();
                commentsParam.ParameterName = "@Comments";
                commentsParam.Value = comments;


                cmd.CommandText = query;
                cmd.Parameters.Add(bookIdParam);
                cmd.Parameters.Add(printDateParam);
                cmd.Parameters.Add(commentsParam);

                LibConnect.Open();
                var result = cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                addSuccess = false;
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();

                if (addSuccess)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Success", "alert('Issue Added.')", true);
                    tbAddIssueBookId.Text = "";
                    tbAddIssuePrintDate.Text = "";
                    tbAddIssueComments.Text = "";
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
                }
            }
        }
    }

    /// <summary>
    /// Inserts new book into table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddBook_Click(object sender, EventArgs e)
    {
        bool addSuccess = true;
        SqlConnection LibConnect = new SqlConnection();
        LibConnect.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NetClassConnectionString"].ConnectionString;
        SqlCommand cmd = LibConnect.CreateCommand();

        string authorId = tbAddBookAuthorId.Text;
        string genreId = tbAddBookGenreId.Text;
        string pubId = tbAddBookPubId.Text;
        string title = tbAddBookTitle.Text;
        string pubDate = tbAddBookPubDate.Text;
        DateTime pubDateTime;
        string coverType = ddCoverType.SelectedValue;

        if (String.IsNullOrEmpty(authorId) ||
            String.IsNullOrEmpty(genreId) ||
            String.IsNullOrEmpty(pubId) ||
            String.IsNullOrEmpty(pubDate) ||
            String.IsNullOrEmpty(title) ||
            !DateTime.TryParse(pubDate, out pubDateTime))
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Please enter data for all fields, and ensure the publisher date is properly formatted')", true);
            addSuccess = false;
        }
        else
        {
            try
            {
                string query = "Insert Into [Book] (AuthorId, GenreId, PublisherId, Title, PublishedDate, CoverType) VALUES(@AuthorId, @GenreId, @PublisherId, @Title, @PublishedDate, @CoverType)";
                SqlParameter authorIdParam = new SqlParameter();
                authorIdParam.ParameterName = "@AuthorId";
                authorIdParam.Value = authorId;
                SqlParameter genreIdParam = new SqlParameter();
                genreIdParam.ParameterName = "@GenreId";
                genreIdParam.Value = genreId;
                SqlParameter publisherIdParam = new SqlParameter();
                publisherIdParam.ParameterName = "@PublisherId";
                publisherIdParam.Value = pubId;
                SqlParameter titleParam = new SqlParameter();
                titleParam.ParameterName = "@Title";
                titleParam.Value = title;
                SqlParameter pubDateParam = new SqlParameter();
                pubDateParam.ParameterName = "@PublishedDate";
                pubDateParam.Value = pubDateTime.ToString("yyyy-MM-dd");
                SqlParameter coverParam = new SqlParameter();
                coverParam.ParameterName = "@CoverType";
                coverParam.Value = coverType;

                cmd.CommandText = query;
                cmd.Parameters.Add(authorIdParam);
                cmd.Parameters.Add(genreIdParam);
                cmd.Parameters.Add(publisherIdParam);
                cmd.Parameters.Add(titleParam);
                cmd.Parameters.Add(pubDateParam);
                cmd.Parameters.Add(coverParam);


                LibConnect.Open();
                var result = cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                addSuccess = false;
            }
            finally
            {
                cmd.Dispose();
                LibConnect.Close();

                if (addSuccess)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Success", "alert('Book Added.')", true);
                    tbAddBookAuthorId.Text = "";
                    tbAddBookGenreId.Text = "";
                    tbAddBookPubId.Text = "";
                    tbAddBookTitle.Text = "";
                    tbAddBookPubDate.Text = "";
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "InfoMissing", "alert('Something Went Wrong.')", true);
                }
            }
        }
    }
}