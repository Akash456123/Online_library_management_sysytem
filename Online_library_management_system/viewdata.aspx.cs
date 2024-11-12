using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class viewprofile : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cm;
    SqlDataReader dr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
        }
    }

    private void BindGridView()
    {
        string path = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True";
        using (cn = new SqlConnection(path))
        {
            cn.Open();

            string k = "select * from registration";
            using (cm = new SqlCommand(k, cn))
            {
                dr = cm.ExecuteReader();

                GridView1.DataSource = dr;
                GridView1.DataBind();
            }
        }
    }

    protected void btn1_click(object sender, EventArgs e)
    {
        string path = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True";
        using (cn = new SqlConnection(path))
        {
            cn.Open();

            GridViewRow s1 = ((Button)sender).NamingContainer as GridViewRow;

            TextBox txtname = (TextBox)s1.FindControl("TextBox1");
            TextBox txtpassword = (TextBox)s1.FindControl("TextBox2");

            string k = "UPDATE registration SET name=@name WHERE password=@password";
            using (cm = new SqlCommand(k, cn))
            {
                cm.Parameters.AddWithValue("@name", txtname.Text);
                cm.Parameters.AddWithValue("@password", txtpassword.Text);

                cm.ExecuteNonQuery();
            }

            // Rebind the GridView after updating
            BindGridView();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Record Updated')", true);
        }
    }

    protected void btn2_click(object sender, EventArgs e)
    {
        string path = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True";
        using (cn = new SqlConnection(path))
        {
            cn.Open();

            GridViewRow s1 = ((Button)sender).NamingContainer as GridViewRow;
            TextBox lblname = (TextBox)s1.FindControl("TextBox1");

            string k = "DELETE FROM registration  WHERE name=@name";
            using (cm = new SqlCommand(k, cn))
            {
                cm.Parameters.AddWithValue("@name", lblname.Text);

                cm.ExecuteNonQuery();
            }

            // Rebind the GridView after deleting
            BindGridView();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Record Deleted')", true);
        }
    }
}
