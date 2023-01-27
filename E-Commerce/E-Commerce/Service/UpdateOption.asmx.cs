using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Configuration;
using System.Web.Services;
using System.Data.SqlClient;

namespace E_Commerce.Service
{
    /// <summary>
    /// update sp
    /*      Create procedure SpUpdateOption
               @Id int,
               @ChosenOption nvarchar(15)
               AS
               UPDATE Products SET ChosenOption=@ChosenOption
             WHERE Id = @Id; */
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class UpdateOption : System.Web.Services.WebService
    {
        [WebMethod]
        public string UpdateData(int id, string option)
        {
            string conString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ECommerceDB1; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;";


            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("SPUpdateOption", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@ChosenOption", option);

            con.Open();


            try
            {
                cmd.ExecuteNonQuery();
                return "Record Updated";
            }
            catch
            {
                return "Record Couldnt Updated";
            }
            finally
            {
                con.Close();
            }
        }
    }
}
