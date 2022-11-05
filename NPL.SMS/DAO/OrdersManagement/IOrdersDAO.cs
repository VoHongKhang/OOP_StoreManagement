using System;
using System.Collections.Generic;
using System.Text;

namespace R2S.Training.DAO.OrdersManagement
{
    interface IOrdersDAO
    {
        public List<Order> GetAllOrdersByCustomerId(int CustomerId);
        public bool AddOrder(Order order);
        public bool UpdateOrtherTotal(int ortherId);

    }
}
