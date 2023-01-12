using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using MyWeb.YeniService;

namespace MyWeb
{
    /// <summary>
    /// Summary description for MyWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public void Delete(string ID)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0BJTEAC\SQLEXPRESS; Initial Catalog=OrnekDB; Integrated Security=true");
            conn.Open();

            SqlCommand cmd = new SqlCommand("Delete from Kisiler where ID = @p1", conn);
            cmd.Parameters.AddWithValue("@p1", ID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        [WebMethod]
        public string Print()
        {
            BetterService obj = new BetterService();
            string str = obj.HelloWorld();
            return str;
        }
    }
}
