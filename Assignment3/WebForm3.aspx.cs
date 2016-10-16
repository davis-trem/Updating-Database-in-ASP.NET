using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment3.ServiceReference1;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace Assignment3
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        ServiceReference1.Interface1Client proxy;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Trey\Documents\Visual Studio 2015\Projects\Assignment3\Assignment3\App_Data\Database1.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            proxy = new ServiceReference1.Interface1Client();
            Database1.DeleteCommand = proxy.getDelete();
            Database1.UpdateCommand = proxy.getUpdate();

            con.Open();
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