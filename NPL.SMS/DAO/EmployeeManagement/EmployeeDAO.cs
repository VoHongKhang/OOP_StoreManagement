using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace R2S.Training.DAO.EmployeeManagement
{
    internal class EmployeeDAO
    {
        // Hỗ trợ chức năng 8
        private const string SELECT = "Select * From Employee";

        public List<Employee> GetAllEmployee()
        {
            // Create list LineItem
            List<Employee> list = new List<Employee>();

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
                    Employee employee = new Employee
                    {
                        EmployeeId = reader.GetInt32(0),
                        EmployeeName = reader.GetString(1),
                        Salary = reader.GetDouble(2),
                        SpvId = reader.GetInt32(3),
                    };
                    // Add into list
                    list.Add(employee);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        //Search employee_id in Employee
        public bool SearchEmployeeId(int employee_id)
        {
            foreach (Employee t in GetAllEmployee())
            {
                if (t.EmployeeId == employee_id)
                    return true;
            }
            return false;
        }
    }
}
