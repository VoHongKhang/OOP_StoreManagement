using System;
using System.Collections.Generic;
using System.Text;

namespace R2S.Training
{
    internal class Customer
    {
        private int customerId;
        private string customerName;

        public Customer() { }

        public Customer(int customerId, string customerName)
        {
            this.customerId = customerId;
            this.customerName = customerName;
        }

        public int CustomerId
        {
            set => customerId = value;
            get => customerId;
        }

        public string CustomerName
        {
            set => customerName = value;
            get => customerName;
        }
    }
}
