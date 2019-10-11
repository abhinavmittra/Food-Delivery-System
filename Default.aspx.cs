using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_PreInit(Object sender,EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["Themes"];
        if (cookie == null)
        {
            Page.Theme = "Day";
        }
        else
        {
            Page.Theme = cookie["Theme"];
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Abhinav\IT_PROJECT\FoodDelivery\Food.mdf;Integrated Security=True;Connect Timeout=30";
        string authText = "select * from Users where Name=@uname and Password=@pass and Isadmin=1 ";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand(authText, conn))
            {
                cmd.Parameters.AddWithValue("@uname", AdminID.Text);
                cmd.Parameters.AddWithValue("@pass", AdminPass.Text);
                conn.Open();



                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Response.Redirect("Default4.aspx");
                        //Session["adminname"] = AdminID.Text;
                        //Session["username"] = AdminID.Text;

                        //Response.Redirect("Default3.aspx?username=" + Session["username"].ToString());
                    }
                    else
                    {
                        //Display Error msg;
                    }
                }
            }
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Abhinav\IT_PROJECT\FoodDelivery\Food.mdf;Integrated Security=True;Connect Timeout=30";
        string authText = "select * from Users where Name=@uname and Password=@pass and Isadmin=0 ";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand(authText, conn))
            {
                cmd.Parameters.AddWithValue("@uname", UserID.Text);
                cmd.Parameters.AddWithValue("@pass", Password.Text);
                conn.Open();



                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                       
                            Session["username"] = UserID.Text;
                        Response.Redirect("Default3.aspx");
                       // Response.Redirect("Default3.aspx?username="+Session["username"].ToString());
                    }
                    else
                    {
                        //Display Error msg;
                    }

                }

            }
        }
    }
}