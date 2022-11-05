using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace R2S.Training.DAO.ProductManagement
{
    class ProductDAO
    {
        // Hỗ trợ chức năng 9
        private const string SELECT = "Select * From Product";

        public List<Product> GetAllProduct()
        {
            // Create list LineItem
            List<Product> list = new List<Product>();

            // Create a connection
            using SqlConnection conn = Common.Common.GetSqlConnection();

            // Create a sql command
            using SqlCommand cmd = Common.Common.GetSqlCommand(SELECT, conn);

            try
            {
                // Open a connection
                conn.Open();

                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        ProductPrice = reader.GetDouble(2),
                    };
                    // Add into list
                    list.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        //Search employee_id in Employee
        public bool SearchProductId(int product_id)
        {
            foreach (Product t in GetAllProduct())
            {
                if (t.ProductId == product_id)
                    return true;
            }
            return false;
        }
    }
}

