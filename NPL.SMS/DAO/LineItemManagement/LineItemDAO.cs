using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace R2S.Training.DAO.LineItemManagement
{
    internal class LineItemDAO 
    {
        private const string SELECTLINEITEM = "Select * From LineItem Where order_id=@orderId";     // Chức năng 3
        private const string TOTAL = "select dbo.fc_TotalPrice(@order_id)"; // Chức năng 4
        private const string CREATE_LINEITEM = "Insert Into LineItem (order_id,product_id,quantity,price) values(@orderId,@productId, @quantity, @price)"; // Chức năng 9
        private const string UPDATE_TOTAL = "Update Orders Set total = @total Where order_id = @orderId";     // Chức năng 10
                                                                                                              
        private const string SELECT = "Select * From LineItem";

        // Chức năng 3
        public List<LineItem> GetAllLineItem()
        {
            // Create list LineItem
            List<LineItem> list = new List<LineItem>();

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
                    LineItem lineItem = new LineItem
                    {
                        OrderId = reader.GetInt32(0),
                        ProductId = reader.GetInt32(1),
                        Quantity = reader.GetInt32(2),
                        Price = reader.GetDouble(3),
                    };
                    // Add into list
                    list.Add(lineItem);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        //Search order_id in LineItem
        public bool SearchOrderId(int order_id)
        {
            foreach (LineItem t in GetAllLineItem())
            {
                if (t.OrderId == order_id)
                    return true;
            }
            return false;
        }
        public bool SearchProductId(int product_id)
        {
            foreach (LineItem t in GetAllLineItem())
            {
                if (t.ProductId == product_id)
                    return true;
            }
            return false;
        }
        public List<LineItem> GetAllItemsByCustomerId(int OrderId)
        {
            // Create a connection
            using SqlConnection conn = Common.Common.GetSqlConnection();

            // Open a connection
            conn.Open();

            // Create a sql command
            using SqlCommand cmd = Common.Common.GetSqlCommand(SELECTLINEITEM, conn);

            cmd.Parameters.Add(new SqlParameter("@orderId", OrderId));

            using SqlDataReader dataReader = cmd.ExecuteReader();

            // Create list LineItem
            List<LineItem> list = new List<LineItem>();
            while (dataReader.Read())
            {
                LineItem lineitem = new LineItem
                {
                    OrderId = dataReader.GetInt32(0),
                    ProductId = dataReader.GetInt32(1),
                    Quantity = dataReader.GetInt32(2),
                    Price = dataReader.GetDouble(3),
                };
                // Add into list
                list.Add(lineitem);
            }
            return list;
        }
        // Chức năng 4
        public double ComputeOrderTotal(int orderId)
        {
            // Create a connection
            using SqlConnection conn = Common.Common.GetSqlConnection();

            // Open a connection
            conn.Open();

            // Create a sql command
            using SqlCommand cmd = Common.Common.GetSqlCommand(TOTAL, conn);

            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@order_id",orderId)
            });
            try
            {
                return (double)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        // Chức năng 9
        public bool AddLineItem(LineItem lineItem)
        {
            // Create a connection
            using SqlConnection conn = Common.Common.GetSqlConnection();

            // Create a sql command
            using SqlCommand cmd = Common.Common.GetSqlCommand(CREATE_LINEITEM, conn);

            // Open a connection
            conn.Open();

            cmd.Parameters.AddRange(new[]
            {
                    new SqlParameter("@orderId", lineItem.OrderId),
                    new SqlParameter("@productId", lineItem.ProductId),
                    new SqlParameter("@quantity", lineItem.Quantity),
                    new SqlParameter("@price", lineItem.Price)
                });

            if (cmd.ExecuteNonQuery() <= 0)
                return false;

            else
                return true;
        }
        // Chức năng 10
        public bool UpdateOrderTotal(int ortherId)
        {
            // Create a connection
            using SqlConnection conn = Common.Common.GetSqlConnection();

            // Create a sql command
            using SqlCommand cmd = Common.Common.GetSqlCommand(UPDATE_TOTAL, conn);

            // Open a connection
            conn.Open();

            // Create total
            double total;

            total = ComputeOrderTotal(ortherId);

            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@orderId", ortherId),
                new SqlParameter("@total",total)
            });

            if (cmd.ExecuteNonQuery() <= 0)
                return false;

            else
                return true;
        }
    }
}
