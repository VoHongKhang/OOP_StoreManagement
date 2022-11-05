using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace R2S.Training.DAO.CustomerManagement
{
    internal class CustomerDAO : ICustomerDAO
    {
        // SQL command
        const string SELECTCUSTOMER = "Select * From Customer Where Exists(Select Orders.customer_id From Orders Where Orders.customer_id=Customer.customer_id)";     // Chức năng 1
        const string INSERT = "sp_AddCustomer";                     // Chức năng 5
        private const string DELETE = "sp_delete_customer";                 // Chức năng 6
        private const string UPDATE = "Sp_UpdateCustomer @customerID, @customerName"; // Chức năng 7
        private const string SELECT= "Select * From Customer";

        // Chức năng 1
        public List<Customer> GetAllCustomer()
        {
            // In a using statement, acquire the SqlConnection as a resource
            using SqlConnection conn = Common.Common.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // Sql command
            using SqlCommand cmd = Common.Common.GetSqlCommand(SELECTCUSTOMER, conn);
            using SqlDataReader dataReader = cmd.ExecuteReader();

            // Create list Customer
            List<Customer> list = new List<Customer>();

            while (dataReader.Read())
            {
                // Create new a customer
                Customer customer = new Customer
                {
                    CustomerId = dataReader.GetInt32(0),
                    CustomerName = dataReader.GetString(1)
                };

                // Add into list
                list.Add(customer);
            }
            return list;
        }
        public List<Customer> GetAllCustomer1()
        {
            // In a using statement, acquire the SqlConnection as a resource
            using SqlConnection conn = Common.Common.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // Sql command
            using SqlCommand cmd = Common.Common.GetSqlCommand(SELECT, conn);
            using SqlDataReader dataReader = cmd.ExecuteReader();

            // Create list Customer
            List<Customer> list = new List<Customer>();

            while (dataReader.Read())
            {
                // Create new a customer
                Customer customer = new Customer
                {
                    CustomerId = dataReader.GetInt32(0),
                    CustomerName = dataReader.GetString(1)
                };

                // Add into list
                list.Add(customer);
            }
            return list;
        }

        //Search customer_id in Customer
        public bool SearchCustomerId(int customer_id)
        {
            foreach (Customer t in GetAllCustomer1())
            {
                if (t.CustomerId == customer_id)
                    return true;
            }
            return false;
        }

        // Chức năng 5
        public bool AddCustomer(Customer customer)
        {
            // In a using statement, acquire the SqlConnection as a resource
            using SqlConnection conn = Common.Common.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // Create parameter
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@customer_name",
                Value = customer.CustomerName
            };

            // Sql command
            using SqlCommand cmd = Common.Common.GetSqlCommand(INSERT, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(param);

            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }
        // Chức năng 6
        public bool DeleteCustomer(int customerId)
        {
            // In a using statement, acquire the SqlConnection as a resource
            using SqlConnection conn = Common.Common.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // Create parameter
            SqlParameter param = new SqlParameter
            {
                ParameterName = "@Id",
                Value = customerId
            };

            // Sql command
            using SqlCommand cmd = Common.Common.GetSqlCommand(DELETE, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(param);

            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }
        // Chức năng 7
        public bool UpdateCustomer(Customer customer)
        {
            // In a using statement, acquire the SqlConnection as a resource
            using SqlConnection conn = Common.Common.GetSqlConnection();

            // Open the SqlConnection
            conn.Open();

            // Sql command
            using SqlCommand cmd = Common.Common.GetSqlCommand(UPDATE, conn);

            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@customerID", customer.CustomerId),
                new SqlParameter("@customerName", customer.CustomerName)
            });

            if (cmd.ExecuteNonQuery() <= 0)
                return false;
            else
                return true;
        }
    }
}
