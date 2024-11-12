using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Loginpage : System.Web.UI.Page
{
    SqlConnection cn;
    SqlCommand cm;
    SqlDataReader dr;

    protected void Page_Load(object sender, EventArgs e)
    {


    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    

        string path = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True";
        cn = new SqlConnection(path);
        cn.Open();

        string k1 = "SELECT * FROM registration WHERE email=@email1 and password=@password1";

        cm = new SqlCommand(k1, cn);
        cm.Parameters.AddWithValue("email1", TextBox1.Text);
        cm.Parameters.AddWithValue("password1", TextBox2.Text);
        dr = cm.ExecuteReader();

        
        if (dr.Read())
        {
            Session["email"] = dr["email"].ToString();

            Session["password"] = dr["password"].ToString();
            Response.Redirect("viewdata.aspx");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password did not match')", true);

        }

        dr.Close();
        
    }


   
}