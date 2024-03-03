using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio102
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if there is an existing cookie for the email address
                if (Request.Cookies["Email"] != null)
                {
                    // If a cookie exists, populate the email textbox with the cookie value
                    txtEmail.Text = Request.Cookies["Email"].Value;
                }

                // Check if there is an existing session for the password
                if (Session["Password"] != null)
                {
                    // If a session exists, populate the password textbox with the session value
                    txtPassword.Text = Session["Password"].ToString();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Get the entered email and password
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Check if the email and password match the specific credentials
            if (email == "sumaiya.rahim234@gmail.com" && password == "12345")
            {
                // Create a cookie for the email address to remember it
                HttpCookie emailCookie = new HttpCookie("Email", email);
                emailCookie.Expires = DateTime.Now.AddDays(7); // Set cookie expiration to 7 days
                Response.Cookies.Add(emailCookie);

                // Store the password in a session variable
                Session["LoggedIn"] = true;

                // Redirect to the admin.aspx page upon successful login
                Response.Redirect("admin.aspx");
            }
            else
            {
                // Display an error message if the email or password is incorrect
                // You can customize this error message as per your requirement
                Response.Write("<script>alert('Invalid email or password. Please try again.');</script>");
            }
        }
    }
}