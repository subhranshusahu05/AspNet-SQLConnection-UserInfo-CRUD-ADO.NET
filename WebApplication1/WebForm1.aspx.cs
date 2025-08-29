using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userinfoConnectionString"].ConnectionString);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insert into userinfo (roll,name,class,addres) values (@roll,@name,@class,@addres)", con);

            cmd.CommandType=CommandType.Text;
            cmd.Parameters.AddWithValue("@roll", TextBox1.Text);
            cmd.Parameters.AddWithValue("@name", TextBox2.Text);
            cmd.Parameters.AddWithValue("@class", TextBox3.Text);
            cmd.Parameters.AddWithValue("@addres", TextBox4.Text);

           if( cmd.ExecuteNonQuery() == 1)
            {
                Response.Write("<script>alert('Data Inserted Successfully')</script>");
            }
            else
            {
                Response.Write("<script>alert('Data Not Inserted')</script>");
            }
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userinfoConnectionString"].ConnectionString);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("UPDATE userinfo SET name = @name, class = @class, addres = @addres WHERE roll = @roll", con);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@roll", TextBox1.Text);
            cmd.Parameters.AddWithValue("@name", TextBox2.Text);
            cmd.Parameters.AddWithValue("@class", TextBox3.Text);
            cmd.Parameters.AddWithValue("@addres", TextBox4.Text);

            if (cmd.ExecuteNonQuery() == 1)
            {
                Response.Write("<script>alert('Data updated Successfully')</script>");
            }
            else
            {
                Response.Write("<script>alert(' no record found with this roll no')</script>");
            }
            con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userinfoConnectionString"].ConnectionString);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("DELETE userinfo  WHERE roll = @roll", con);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@roll", TextBox1.Text);
           

            if (cmd.ExecuteNonQuery() == 1)
            {
                Response.Write("<script>alert('Data Delete Successfully')</script>");
            }
            else
            {
                Response.Write("<script>alert(' no record found with this roll no')</script>");
            }
            con.Close();

        }
    }
}