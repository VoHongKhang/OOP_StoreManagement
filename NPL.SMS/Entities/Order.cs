using System;
using System.Collections.Generic;
using System.Text;

namespace R2S.Training
{
    internal class Order
    {
        private int orderId;
        private DateTime orderDate;
        private int customerId;
        private int employeeId;
        private double total;

        public Order() { }

        public Order(int orderId,DateTime orderDate,int customerId,int employeeId,double total)
        {
            this.orderId = orderId;
            this.orderDate = orderDate;
            this.customerId = customerId;
            this.employeeId = employeeId;
            this.total = total;
        }
        
        public int OrderId
        {
            set => orderId = value;
            get => orderId;
        }
        public DateTime OrderDate
        {
            set => orderDate = value;
            get => orderDate;
        }
        public int CustomerId
        {
            set => customerId = value;
            get => customerId;
        }
        public int EmployeeId
        {
            set => employeeId = value;
            get => employeeId;
        }
        public double Total
        {
            set => total = value;
            get => total;
        }
    }
}
