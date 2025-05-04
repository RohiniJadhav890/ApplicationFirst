using System.Data.SqlClient;

namespace ApplicationFirst.Models
{
    public class ProductsDAL
    {
        private readonly IConfiguration _configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public ProductsDAL(IConfiguration configuration)
        {
            // read the connection string
            _configuration = configuration;
            con = new SqlConnection(_configuration.GetConnectionString("DefaultConnections"));
        }
        public int AddProduct(Products product)
        {
            int result = 0;
            try
            {

                product.isActive = 1;
                con.Open();
                cmd = new SqlCommand("Insert into Products values(@Pname,@Price,@Total,@isActive)", con);
                cmd.Parameters.AddWithValue("@Pname", product.Pname);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Total", product.Total);
                cmd.Parameters.AddWithValue("@isActive", product.isActive);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;


        }

        // Update Emp
        public int UpdateProduct(Products product)
        {
            int result = 0;
            try
            {
                product.isActive = 1;
                con.Open();
                cmd = new SqlCommand("update  Products set pname=@Pname,price=@Price,total=@Total,isActive=@isActive where id=@Pid", con);
                cmd.Parameters.AddWithValue("@Pname", product.Pname);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Total", product.Total);
                cmd.Parameters.AddWithValue("@isActive", product.isActive);
                cmd.Parameters.AddWithValue("@Pid", product.Pid);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        // Delete Emp
        public int DeleteProduct(int id)
        {
            int result = 0;
            try
            {
                //student.isActive = 0;
                con.Open();
                cmd = new SqlCommand("update  Products set isActive=@isActive where id=@Pid", con);
                cmd.Parameters.AddWithValue("@isActive", 0);
                cmd.Parameters.AddWithValue("@Pid", id);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        // Show All
        public List<Products> GetProducts()
        {
            List<Products> products1 = new List<Products>();
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from  Products where isActive=1", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Products product = new Products();
                    product.Pid = Convert.ToInt32(dr["Pid"]);
                    product.Pname = dr["Pname"].ToString();
                    product.Price = Convert.ToInt32(dr["Price"]);
                    product.Total = Convert.ToInt32(dr["Total"]);
                    product.isActive = Convert.ToInt32(dr["isActive"]);
                    products1.Add(product);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return products1;
        }
        // Show Emp by Id
        public Products GetProductById(int id)
        {
            Products product = new Products();
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from  Products where isActive=1 and pid=@Pid", con);
                cmd.Parameters.AddWithValue("@Pid", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    product.Pid = Convert.ToInt32(dr["Pid"]);
                    product.Pname = dr["Pname"].ToString();
                    product.Price = Convert.ToInt32(dr["Price"]);
                    product.Total = Convert.ToInt32(dr["Total"]);
                    product.isActive = Convert.ToInt32(dr["isActive"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return product;
        }
    }
}