using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Configuration;
using System.Web.Services;
using System.Data.SqlClient;
using E_Commerce.Models;

namespace E_Commerce.Service
{
    /// <summary>
    /*
     Alter PROCEDURE SearchProduct
        @Name nvarchar(50)
        AS
        SELECT * FROM dbo.Products where Products.Name LIKE '%'+@Name+'%'
    */
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SearchProduct : System.Web.Services.WebService
    {

        [WebMethod]
        public List<ProductModel> SearchProducts(string name)
        {
            string conString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ECommerceDB1; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;";
            List<ProductModel> productModels = new List<ProductModel>();

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("SearchProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);
            
            con.Open();
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProductModel products = new ProductModel();
                            products.Id = reader.GetInt32(0);
                            products.Name = reader.GetString(2);
                            products.Price = reader.GetInt32(8);
                            products.Image = reader.GetString(16);
                            productModels.Add(products);
                        }
                    }
                }

                return productModels;

            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
