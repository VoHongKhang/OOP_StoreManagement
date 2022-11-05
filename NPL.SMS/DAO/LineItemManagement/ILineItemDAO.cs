using System;
using System.Collections.Generic;
using System.Text;

namespace R2S.Training.DAO.LineItemManagement
{
    interface ILineItemDAO
    {
        public List<LineItem> GetAllItemsByCustomerId(int OrderId);
        public double ComputeOrderTotal(int orderId);
        public bool AddLineItem(LineItem lineItem);

    }
}
