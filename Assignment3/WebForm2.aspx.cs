using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace Assignment3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Trey\Documents\Visual Studio 2015\Projects\Assignment3\Assignment3\App_Data\Database1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into [Table] values('"+nameTextBox.Text+"','"+genderRadioButtonList.Text+"','"+Calendar1.SelectedDate.ToShortDateString()+"','"+pobDropDownList.Text+"','"+commentTextBox.Text+"')";
            cmd.ExecuteNonQuery();

            

            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from [Table]", con);
                da.Fill(ds, "table");
            }
            catch
            {
                Label1.Text = "Error while connecting to a database";
            }
            XmlDataDocument doc = new XmlDataDocument(ds);
            doc.Save(MapPath("XMLS//xmlData.xml"));

            con.Close();
        }
    }
}