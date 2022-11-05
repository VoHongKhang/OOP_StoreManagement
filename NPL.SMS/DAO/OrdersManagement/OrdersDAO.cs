using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace R2S.Training.DAO.OrdersManagement
{
    internal class OrdersDAO 
    {
        // Chức năng 2
        private const string SELECTORDER = "Select * From Orders Where  customer_id=@customerId";
        // Chức năng 8
        private const string CREATE_ORDER = "Insert Into Orders (oder_date,customer_id,employee_id,total) values(@orderDate, @customerId, @employeeId, @total)"; // Chức năng 8
                                                                                                                                                                 // Chức năng 2
        private const string SELECT = "Select * From Orders";
        public List<Order> GetAllOrder()
        {
            // Create list Order
            List<Order> list = new List<Order>();

            // Create a connection
            using SqlConnection conn = Common.Common.GetSqlConnection();

            // Create a sql command
            using SqlCommand cmd = Common.Common.GetSqlCommand(SELECT, conn);

            try
            {
                // Open a connection
                conn.Open();

                // Execute sql statement
                using SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Order order = new Order
                    {
                        OrderId = dataReader.GetInt32(0),
                        OrderDate = dataReader.GetDateTime(1),
                        CustomerId = dataReader.GetInt32(2),
                        EmployeeId = dataReader.GetInt32(3),
                        Total = dataReader.GetDouble(4)
                    };
                    // Add into list
                    list.Add(order);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        //Search customer_id in Order
        public bool SearchCustomerId(int customer_id)
        {
            foreach (Order t in GetAllOrder())
            {
                if (t.CustomerId == customer_id)
                    return true;
            }
            return false;
        }

        //Search order_id in Order
        public bool SearchOrderId(int order_id)
        {
            foreach (Order t in GetAllOrder())
            {
                if (t.OrderId == order_id)
                    return true;
            }
            return false;
        }

        public List<Order> GetAllOrdersByCustomerId(int CustomerId)
        {
            // Create sql connction
            using SqlConnection conn = Common.Common.GetSqlConnection();

            // Open connection
            conn.Open();

            // Create sql command
            using SqlCommand cmd = Common.Common.GetSqlCommand(SELECTORDER, conn);

            cmd.Parameters.Add(new SqlParameter("@customerId", CustomerId));

            // Execute sql statement
            using SqlDataReader dataReader = cmd.ExecuteReader();

            // Create list Order
            List<Order> list = new List<Order>();

            while (dataReader.Read())
            {
                Order order = new Order
                {
                    OrderId = dataReader.GetInt32(0),
                    OrderDate = dataReader.GetDateTime(1),
                    CustomerId = dataReader.GetInt32(2),
                    EmployeeId = dataReader.GetInt32(3),
                    Total = dataReader.GetDouble(4)
                };
                // Add into list
                list.Add(order);
            }
            return list;
        }
        // Chức năng 8
        public bool AddOrder(Order order)
        {
            // Create sql connction
            using SqlConnection conn = Common.Common.GetSqlConnection();

            // Open connection
            conn.Open();

            // Create sql command
            using SqlCommand cmd = Common.Common.GetSqlCommand(CREATE_ORDER, conn);

            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@orderDate", order.OrderDate),
                new SqlParameter("@customerId", order.CustomerId),
                new SqlParameter("@employeeId", order.EmployeeId),
                new SqlParameter("@total", order.Total)
            });

            if (cmd.ExecuteNonQuery() <= 0)
                return false;
            else
                return true;
        }
    }
}
