using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibaryManagementSystem.Admin
{
    public partial class adminlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
       
        }

        protected void Btnlogin(object sender, EventArgs e)
        {
            String strCon = "Data Source=DESKTOP-J1NS0B9\\JAHID;Initial Catalog=UniversitySystem;Integrated Security=True";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from LogInInfo where UserName=@userName and Password=@pass", con);
            cmd.Parameters.AddWithValue("@UserName", tbxUserName.Text);
            cmd.Parameters.AddWithValue("@pass", tbxPassword.Text);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            if (dt.Rows.Count > 0)
            {
                Session["UserName"] = dt.Rows[0]["UserName"].ToString();
                Response.Redirect("home.aspx");
            }

            else
            {
                lblError.Text = "error";
            }
        }
    }
}