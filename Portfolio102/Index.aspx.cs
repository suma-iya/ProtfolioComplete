using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio102
{
    public partial class Index : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindSocialMediaLinks();
            BindProjects();
            BindActivities();

        }

        private void BindActivities()
        {
            string query = "SELECT Link, LinkTitle, Title, SolvedProblems FROM ActivitiesName";

            using (SqlConnection connection = new SqlConnection(strcon))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable activitiesTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(activitiesTable);

                    if (activitiesTable.Rows.Count > 0)
                    {
                        rptActivities.DataSource = activitiesTable;
                        rptActivities.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine("An error occurred while fetching activities: " + ex.Message);
                }
            }
        }

        private void BindProjects()
        {
            string query = "SELECT Title, Link, ImagePath, AltText FROM Projects";

            using (SqlConnection connection = new SqlConnection(strcon))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable projectsTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(projectsTable);

                    if (projectsTable.Rows.Count > 0)
                    {
                        rptProjects.DataSource = projectsTable;
                        rptProjects.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine("An error occurred while fetching projects: " + ex.Message);
                }
            }
        }


        protected void BindSocialMediaLinks()
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                string query = "SELECT AltText, Link, ImagePath FROM SocialMediaLinks";

                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlDataAdapter
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Find the SocialMediaRepeater control
                        Repeater SocialMediaRepeater = (Repeater)FindControl("SocialMediaRepeater");

                        // Bind the data to the Repeater control
                        SocialMediaRepeater.DataSource = dataTable;
                        SocialMediaRepeater.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }


        protected void btnSend_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Contact_Section ([Name], [Email], [Subject], [Message]) VALUES(@Name, @Email, @Subject, @msg)", con);

            cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@Subject", txtSubject.Text.Trim());
            cmd.Parameters.AddWithValue("@msg", txtMessage.Text.Trim());

            cmd.ExecuteNonQuery();

            // Close the connection
            con.Close();

            // Clear text fields
            txtName.Text = "";
            txtEmail.Text = "";
            txtSubject.Text = "";
            txtMessage.Text = "";

            // Success message in alerts
            Response.Write("<script>alert('Message sent!');</script>");
        }
    }
}