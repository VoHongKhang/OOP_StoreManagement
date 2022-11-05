using System;
using System.Collections.Generic;
using System.Text;

namespace R2S.Training
{
    internal class LineItem
    {
        private int orderId;
        private int productId;
        private int quantity;
        private double price;

        public LineItem()
        {

        }

        public LineItem(int orderId,int productId,int quantity,double price)
        {
            this.orderId = orderId;
            this.productId = productId;
            this.quantity = quantity;
            this.price = price;
        }

        public int OrderId
        {
            set => orderId = value;
            get => orderId;
        }
        public int ProductId
        {
            set => productId = value;
            get => productId;
        }
        public int Quantity
        {
            set => quantity = value;
            get => quantity;
        }
        public double Price
        {
            set => price = value;
            get => price;
        }
    }
}
