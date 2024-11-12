using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Registrationpage : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cm;
    SqlDataReader dr;


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {


        Session["email"] = TextBox2.Text;
        Session["password"] = TextBox5.Text;

        string path = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True";
        cn = new SqlConnection(path);
        cn.Open();

        string k1 = "SELECT * FROM registration WHERE email='" + TextBox2.Text + "'";
        cm = new SqlCommand(k1, cn);
        dr = cm.ExecuteReader();
        if (dr.Read())
        {
            dr.Close();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record already exists')", true);
        }
        else
        {
            dr.Close();



            string k2 = "insert into registration (name,email,mobile,address,password)values(@name1,@email1,@mobile1,@address1,@password1)";
            cm = new SqlCommand(k2, cn);
            {

                cm.Parameters.AddWithValue("@name1", TextBox1.Text);
                cm.Parameters.AddWithValue("@email1", TextBox2.Text);
                cm.Parameters.AddWithValue("@mobile1", TextBox3.Text);
                cm.Parameters.AddWithValue("@address1", TextBox4.Text);
                cm.Parameters.AddWithValue("@password1", TextBox5.Text);
                cm.ExecuteNonQuery();
            }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Registration')", true);
            
        }
        dr.Close();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Loginpage.aspx");
    }
}