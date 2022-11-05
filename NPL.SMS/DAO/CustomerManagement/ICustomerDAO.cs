using System;
using System.Collections.Generic;
using System.Text;

namespace R2S.Training.DAO.CustomerManagement
{
    interface ICustomerDAO
    {
       public List<Customer> GetAllCustomer();
        public bool AddCustomer(Customer customer);
        public bool DeleteCustomer(int customerId);
        public bool UpdateCustomer(Customer customer);
    }
}
