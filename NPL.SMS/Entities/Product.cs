using System;
using System.Collections.Generic;
using System.Text;

namespace R2S.Training
{
    internal class Product
    {
        private int productId;
        private string productName;
        private double productPrice;

        public Product() { }

        public Product(int productId,string productName,double productPrice)
        {
            this.productId = productId;
            this.productName = productName;
            this.productPrice = productPrice;
        }

        public int ProductId
        {
            set => productId = value;
            get => productId;
        }
        public string ProductName
        {
            set => productName = value;
            get => productName;
        }
        public double ProductPrice
        {
            set => productPrice = value;
            get => productPrice;
        }
    }
}
