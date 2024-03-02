using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio102
{
    public partial class admin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSocialMediaLinks();
                BindMailData();
                BindProjects();
                BindActivities();
            }
        }

        protected void BindSocialMediaLinks()
        {
            try
            {
                string query = "SELECT AltText, ImagePath, Link FROM SocialMediaLinks";

                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        socialLinksTable.DataSource = dataTable;
                        socialLinksTable.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        protected void AddSocialLink_Click(object sender, EventArgs e)
        {
            try
            {
                string altTextValue = altText.Text;
                string imagePathValue = imagePath.Text;
                string linkValue = link.Text;

                if (string.IsNullOrEmpty(altTextValue) || string.IsNullOrEmpty(imagePathValue) || string.IsNullOrEmpty(linkValue))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Validation", "alert('Please fill in all fields.');", true);
                    return;
                }

                string query = "INSERT INTO SocialMediaLinks (AltText, ImagePath, Link) VALUES (@AltText, @ImagePath, @Link)";

                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AltText", altTextValue);
                        command.Parameters.AddWithValue("@ImagePath", imagePathValue);
                        command.Parameters.AddWithValue("@Link", linkValue);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                altText.Text = "";
                imagePath.Text = "";
                link.Text = "";

                BindSocialMediaLinks();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        protected void EditSocialLink_Click(object sender, EventArgs e)
        {
            try
            {
                string altText = editAltText.Text;
                string imagePath = editImagePath.Text;
                string link = editLink.Text;

                string query = "UPDATE SocialMediaLinks SET AltText = @AltText , Link=@Link WHERE ImagePath = @ImagePath ";

                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AltText", altText);
                        command.Parameters.AddWithValue("@ImagePath", imagePath);
                        command.Parameters.AddWithValue("@Link", link);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            BindSocialMediaLinks();
                            ScriptManager.RegisterStartupScript(this, GetType(), "editSuccess", "alert('Social link updated successfully.'); closeSocialLinkeditModal();", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "editError", "alert('No social links were updated.');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "editError", $"alert('An error occurred: {ex.Message}');", true);
            }
        }

        protected void deleteSocialLink_Click(object sender, EventArgs e)
        {
            try
            {
                Button deleteButton = (Button)sender;
                GridViewRow row = (GridViewRow)deleteButton.NamingContainer;
                string altText = ((Label)row.FindControl("lblAltText")).Text;
                string imagePath = ((Label)row.FindControl("lblImagePath")).Text;
                string link = ((Label)row.FindControl("lblLink")).Text;

                string query = "DELETE FROM SocialMediaLinks WHERE AltText = @AltText AND ImagePath = @ImagePath AND Link = @Link";

                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AltText", altText);
                        command.Parameters.AddWithValue("@ImagePath", imagePath);
                        command.Parameters.AddWithValue("@Link", link);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            BindSocialMediaLinks();
                            ScriptManager.RegisterStartupScript(this, GetType(), "deleteSuccess", "alert('Social link deleted successfully.');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "deleteError", "alert('Social link not found or already deleted.');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "deleteError", $"alert('An error occurred: {ex.Message}');", true);
            }
        }














        // Mail Section



        protected void BindMailData()
        {
            try
            {
                // Connection string to your database
                string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

                // SQL query to select data from the Contact table
                string query = "SELECT [Name], [Email], [Subject], [Message] FROM Contact_Section";

                // Establishing connection and command objects
                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Opening the connection
                        connection.Open();

                        // Creating a SqlDataAdapter to fill the DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Creating a DataTable to hold the retrieved data
                            DataTable mailData = new DataTable();

                            // Filling the DataTable with data from the database
                            adapter.Fill(mailData);

                            // Binding the DataTable to the GridView
                            mailGridView.DataSource = mailData;
                            mailGridView.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("An error occurred while retrieving mail data: " + ex.Message);
            }
        }


        protected void deleteMail_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the button that raised the event
                Button deleteButton = (Button)sender;

                // Find the row in which the delete button was clicked
                GridViewRow row = (GridViewRow)deleteButton.NamingContainer;

                // Get the email address of the mail to be deleted from the row's data
                string email = row.Cells[1].Text; // Assuming the email address is in the second cell

                // Construct the SQL query to delete the mail
                string query = "DELETE FROM Contact_Section WHERE Email = @Email";

                // Connection string to your database
                string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

                // Establish connection and command objects
                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter to the command
                        command.Parameters.AddWithValue("@Email", email);

                        // Open the connection
                        connection.Open();

                        // Execute the command to delete the mail
                        int rowsAffected = command.ExecuteNonQuery();

                        // Optionally, check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            // Provide feedback to the user
                            ScriptManager.RegisterStartupScript(this, GetType(), "deleteSuccess", "alert('Mail deleted successfully.');", true);

                            // Rebind the GridView to reflect the changes
                            BindMailData();
                        }
                        else
                        {
                            // Provide feedback if no rows were affected (record not found)
                            ScriptManager.RegisterStartupScript(this, GetType(), "deleteError", "alert('Mail not found or already deleted.');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ScriptManager.RegisterStartupScript(this, GetType(), "deleteError", $"alert('An error occurred: {ex.Message}');", true);
            }
        }


        
        
        
        
        
        
        
        
        //Project Section
        protected void BindProjects()
        {
            try
            {
                string query = "SELECT Title, Link, ImagePath, AltText FROM Projects";

                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            projectGridView.DataSource = dataTable;
                            projectGridView.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ScriptManager.RegisterStartupScript(this, GetType(), "BindError", $"alert('An error occurred while binding projects: {ex.Message}');", true);
            }
        }

        protected void AddProject_Click(object sender, EventArgs e)
        {
            try
            {
                string title = addTitle.Text;
                string link = addLink.Text;
                string imagePath = addImagePath.Text;
                string altText = addAltText.Text;

                if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(link) || string.IsNullOrEmpty(imagePath) || string.IsNullOrEmpty(altText))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Validation", "alert('Please fill in all fields.');", true);
                    return;
                }

                string query = "INSERT INTO Projects (Title, Link, ImagePath, AltText) VALUES (@Title, @Link, @ImagePath, @AltText)";

                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Link", link);
                        command.Parameters.AddWithValue("@ImagePath", imagePath);
                        command.Parameters.AddWithValue("@AltText", altText);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // Clear the textboxes
                addTitle.Text = "";
                addLink.Text = "";
                addImagePath.Text = "";
                addAltText.Text = "";

                BindProjects(); // Rebind the data to update the GridView
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ScriptManager.RegisterStartupScript(this, GetType(), "AddError", $"alert('An error occurred while adding project: {ex.Message}');", true);
            }
        }

        protected void EditProject_Click(object sender, EventArgs e)
        {
            try
            {
                string title = editTitle.Text;
                string link = TextBox1.Text;
                string imagePath = TextBox2.Text;
                string altText = TextBox3.Text;


                string query = "UPDATE Projects SET Title = @Title, Link = @Link, AltText = @AltText WHERE ImagePath = @ImagePath";

                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Link", link);
                        command.Parameters.AddWithValue("@ImagePath", imagePath);
                        command.Parameters.AddWithValue("@AltText", altText);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            BindProjects();
                            ScriptManager.RegisterStartupScript(this, GetType(), "EditSuccess", "alert('Project updated successfully.'); closeEditProjectModal();", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "EditError", "alert('No projects were updated.');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "EditError", $"alert('An error occurred while editing project: {ex.Message}');", true);
            }
        }

        protected void deleteProject_Click(object sender, EventArgs e)
        {
            try
            {
                Button deleteButton = (Button)sender;
                GridViewRow row = (GridViewRow)deleteButton.NamingContainer;

                string title = row.Cells[0].Text;
                string link = row.Cells[1].Text;
                string imagePath = row.Cells[2].Text;
                string altText = row.Cells[3].Text;

                string query = "DELETE FROM Projects WHERE Title = @Title AND Link = @Link AND ImagePath = @ImagePath AND AltText = @AltText";

                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Link", link);
                        command.Parameters.AddWithValue("@ImagePath", imagePath);
                        command.Parameters.AddWithValue("@AltText", altText);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            BindProjects();
                            ScriptManager.RegisterStartupScript(this, GetType(), "DeleteSuccess", "alert('Project deleted successfully.');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DeleteError", "alert('Project not found or already deleted.');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DeleteError", $"alert('An error occurred while deleting project: {ex.Message}');", true);
            }
        }






        //Extra - Activity


        protected void BindActivities()
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                string query = "SELECT Title, LinkTitle, Link, SolvedProblems FROM ActivitiesName";

                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        activitiesGridView.DataSource = dataTable;
                        activitiesGridView.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }





        protected void addActivity_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve values from the textboxes using their server-side IDs
                string title = activityTitle.Text;
                string linkTitle = activityLinkTitle.Text;
                string link = activityLink.Text;
                string solvedProblems = activitySolvedProblems.Text;

                // Check if any of the textboxes are empty
                if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(linkTitle) || string.IsNullOrEmpty(link) || string.IsNullOrEmpty(solvedProblems))
                {
                    // Display a message indicating that all fields are required
                    ScriptManager.RegisterStartupScript(this, GetType(), "Validation", "alert('Please fill in all fields.');", true);
                    return;
                }

                // Construct the SQL query
                string query = "INSERT INTO ActivitiesName (Title, LinkTitle, Link, SolvedProblems) VALUES (@Title, @LinkTitle, @Link, @SolvedProblems)";

                // Establish connection and command objects
                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@LinkTitle", linkTitle);
                        command.Parameters.AddWithValue("@Link", link);
                        command.Parameters.AddWithValue("@SolvedProblems", solvedProblems);

                        // Open connection and execute the command
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // Clear the textboxes
                activityTitle.Text = "";
                activityLinkTitle.Text = "";
                activityLink.Text = "";
                activitySolvedProblems.Text = "";

                // Rebind the data to update the GridView
                BindActivities();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        protected void updateActivity_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the values from the textboxes
                string title = editActivityTitle.Text;
                string linkTitle = editActivityLinkTitle.Text;
                string link = editActivityLink.Text;
                string solvedProblems = editActivitySolvedProblems.Text;

                // Construct the SQL query to update the record based on the values in the current row
                string query = "UPDATE ActivitiesName SET LinkTitle = @LinkTitle, Title = @Title, SolvedProblems = @SolvedProblems WHERE Link = @Link";

                // Establish connection and command objects
                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@LinkTitle", linkTitle);
                        command.Parameters.AddWithValue("@Link", link);
                        command.Parameters.AddWithValue("@SolvedProblems", solvedProblems);

                        // Open the connection
                        connection.Open();

                        // Execute the command to update the record
                        int rowsAffected = command.ExecuteNonQuery();

                        // Rebind the GridView to reflect the changes
                        if (rowsAffected > 0)
                        {
                            BindActivities();
                            ScriptManager.RegisterStartupScript(this, GetType(), "editSuccess", "alert('Activity updated successfully.'); closeEditActivityModal();", true);
                        }
                        else
                        {
                            // Optionally, provide feedback if no rows were affected (record not found)
                            ScriptManager.RegisterStartupScript(this, GetType(), "editError", "alert('No activities were updated.');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ScriptManager.RegisterStartupScript(this, GetType(), "editError", $"alert('An error occurred: {ex.Message}');", true);
            }
        }



        protected void deleteActivity_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the button that raised the event
                Button deleteButton = (Button)sender;

                // Find the row in which the delete button was clicked
                GridViewRow row = (GridViewRow)deleteButton.NamingContainer;

                // Check if row is null and ensure there are enough cells
                if (row != null && row.Cells.Count >= 4)
                {
                    // Get the data values of the row to identify the record to delete
                    string title = ((Label)row.FindControl("lblTitle")).Text.Trim();
                    string linkTitle = ((Label)row.FindControl("lblLinkTitle")).Text.Trim();
                    string link = ((Label)row.FindControl("lblLink")).Text.Trim();
                    string solvedProblems = ((Label)row.FindControl("lblSolvedProblems")).Text.Trim();

                    // Assuming strcon is your connection string
                    using (SqlConnection connection = new SqlConnection(strcon))
                    {
                        string checkQuery = "SELECT COUNT(*) FROM ActivitiesName WHERE Title = @Title AND LinkTitle = @LinkTitle AND Link = @Link AND SolvedProblems = @SolvedProblems";
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@Title", title);
                            checkCommand.Parameters.AddWithValue("@LinkTitle", linkTitle);
                            checkCommand.Parameters.AddWithValue("@Link", link);
                            checkCommand.Parameters.AddWithValue("@SolvedProblems", solvedProblems);

                            connection.Open();
                            int rowCount = (int)checkCommand.ExecuteScalar();

                            if (rowCount > 0)
                            {
                                // Record exists, proceed with deletion
                                string deleteQuery = "DELETE FROM ActivitiesName WHERE Title = @Title AND LinkTitle = @LinkTitle AND Link = @Link AND SolvedProblems = @SolvedProblems";
                                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@Title", title);
                                    command.Parameters.AddWithValue("@LinkTitle", linkTitle);
                                    command.Parameters.AddWithValue("@Link", link);
                                    command.Parameters.AddWithValue("@SolvedProblems", solvedProblems);

                                    int rowsAffected = command.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        // Optionally, you can rebind the GridView or perform other actions here
                                        BindActivities();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "deleteSuccess", "alert('Activity deleted successfully.');", true);
                                    }
                                    else
                                    {
                                        // Optionally, provide feedback if no rows were affected (record not found)
                                        ScriptManager.RegisterStartupScript(this, GetType(), "deleteError", "alert('Activity not found or already deleted.');", true);
                                    }
                                }
                            }
                            else
                            {
                                // Record not found, show error message
                                ScriptManager.RegisterStartupScript(this, GetType(), "deleteError", "alert('Activity not found or already deleted.');", true);
                            }
                        }
                    }
                }
                else
                {
                    // Row or cells not found, show error message
                    ScriptManager.RegisterStartupScript(this, GetType(), "deleteError", "alert('Activity not found or already deleted.');", true);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ScriptManager.RegisterStartupScript(this, GetType(), "deleteError", $"alert('An error occurred: {ex.Message}');", true);
            }
        }








    }
}

