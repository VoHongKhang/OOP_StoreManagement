using System;
using System.Collections.Generic;
using System.Text;

namespace R2S.Training.Main
{
    class FunctionManagement
    {
        public void Thanksforuser()
        {
            Console.WriteLine("\nCảm ơn bạn đã sử dụng chương trình của chúng tôi. Hẹn gặp lại...");
            Console.ReadKey();
        }
        public void ShowError()
        {
            Console.WriteLine("\nLựa chọn của bạn không hợp lệ. Vui lòng nhập lại. Xin cảm ơn");
            Console.ReadKey();
            Console.Clear();
        }
        public void Delay()
        {
            Console.WriteLine("\nNhấn Enter để tiếp tục");
            Console.ReadKey();
            Console.Clear();
        }

        // CHỨC NĂNG 1
        public void Function1()
        {
            DAO.CustomerManagement.CustomerDAO customerDAO = new DAO.CustomerManagement.CustomerDAO();

            Console.WriteLine("\n=================================CHỨC NĂNG 1=========================================");
            try
            {
                if (customerDAO.GetAllCustomer().Count > 0)
                {
                    foreach (Customer t in customerDAO.GetAllCustomer())
                    { 
                        Console.WriteLine("\nCustomer Id : {0},   Customer Name : {1}", t.CustomerId, t.CustomerName);
                    }
                }
                else
                    Console.WriteLine("\nRỗng");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Function2()
        {
            // CHỨC NĂNG 2
            DAO.OrdersManagement.OrdersDAO ordersDAO = new DAO.OrdersManagement.OrdersDAO();

            Console.WriteLine("\n=================================CHỨC NĂNG 2=========================================\n");
            try
            {
                int customerId;
                Console.Write("Nhập mã khách hàng : ");
                customerId = int.Parse(Console.ReadLine());
                if (ordersDAO.GetAllOrdersByCustomerId(customerId).Count > 0)
                {
                    foreach (Order m in ordersDAO.GetAllOrdersByCustomerId(customerId))
                    {
                        Console.WriteLine("\nCustomer Id : {0},  Order Time : {1},  Order Id : {2},  Employee Id : {3},  Total : {4}", m.CustomerId, m.OrderDate, m.OrderId, m.EmployeeId, m.Total);
                    }
                }
                else
                    Console.WriteLine("\nKhông tìm thấy");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Function3()
        {
            // CHỨC NĂNG 3
            DAO.LineItemManagement.LineItemDAO lineItemDAO = new DAO.LineItemManagement.LineItemDAO();
            Console.WriteLine("\n=================================CHỨC NĂNG 3=========================================\n");
            try
            {
                int orderId;
                Console.Write("Nhập mã đơn hàng : ");
                orderId = int.Parse(Console.ReadLine());
                if (lineItemDAO.GetAllItemsByCustomerId(orderId).Count > 0)
                {
                    foreach (LineItem n in lineItemDAO.GetAllItemsByCustomerId(orderId))
                    {
                        Console.WriteLine("\nOrder Id : {0},  Product Id : {1},  Quantity Id : {2},  Price Id : {3}", n.OrderId, n.ProductId, n.Quantity, n.Price);
                    }
                }
                else
                    Console.WriteLine("\nKhông tìm thấy");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Function4()
        {
            // CHỨC NĂNG 4
            DAO.OrdersManagement.OrdersDAO ordersDAO = new DAO.OrdersManagement.OrdersDAO();
            DAO.LineItemManagement.LineItemDAO lineItemDAO = new DAO.LineItemManagement.LineItemDAO();
            Console.WriteLine("\n=================================CHỨC NĂNG 4=========================================\n");
            try
            {
                int order_id;

                do
                {
                    Console.Write("\nNhập mã đơn hàng bạn muốn tính tổng : ");
                    order_id = int.Parse(Console.ReadLine());

                    if (order_id == -1)
                        return;

                    if (!ordersDAO.SearchOrderId(order_id))
                        Console.WriteLine("\nMã đơn hàng chưa có trong bảng. Vui lòng nhập lại hoặc nhấn -1 để thoát !");
                }
                while (!ordersDAO.SearchOrderId(order_id));

              
                if (lineItemDAO.SearchOrderId(order_id))
                {
                    Console.WriteLine("\nTổng : {0}", lineItemDAO.ComputeOrderTotal(order_id));
                }
                else
                {
                    Console.WriteLine("\nMã đơn hàng : {0} không tồn tại danh sách mua hàng. Vui lòng kiểm tra lại!", order_id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Function5()
        {
            // CHỨC NĂNG 5
            DAO.CustomerManagement.CustomerDAO customerDAO = new DAO.CustomerManagement.CustomerDAO();
            Console.WriteLine("\n=================================CHỨC NĂNG 5=========================================\n");
            try
            {
                Customer customer = new Customer();

                Console.Write("Nhập tên khách hàng: ");
                customer.CustomerName = Console.ReadLine();

                if (customerDAO.AddCustomer(customer))
                    Console.WriteLine("\nThành Công!!!");
                else
                    Console.WriteLine("\nKhông thành công");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Function6()
        {
            //CHỨC NĂNG 6
            DAO.CustomerManagement.CustomerDAO customerDAO = new DAO.CustomerManagement.CustomerDAO();
            Console.WriteLine("\n=================================CHỨC NĂNG 6=========================================\n");
            try
            {
                int customerId;
                do
                {
                    Console.Write("\nNhập mã của khách hàng cần xóa : ");
                    customerId = int.Parse(Console.ReadLine());

                    if (customerId == -1)
                        return;

                    if (!customerDAO.SearchCustomerId(customerId))
                        Console.WriteLine("\nMã khách hàng không có trong bảng. Vui lòng nhập lại hoặc nhấn -1 để thoát!");
                }
                while (customerId != -1 && !customerDAO.SearchCustomerId(customerId));

          
                if (customerDAO.DeleteCustomer(customerId))
                    Console.WriteLine("\nXóa Thành Công!!!");
                else
                    Console.WriteLine("\nXóa thất bại");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Function7()
        {
            // CHỨC NĂNG 7
            DAO.CustomerManagement.CustomerDAO customerDAO = new DAO.CustomerManagement.CustomerDAO();
            Console.WriteLine("\n=================================CHỨC NĂNG 7=========================================\n");
            try
            {
                Customer customer = new Customer();

                do
                {
                    Console.Write("\nNhập mã khách hàng cần cập nhật: ");
                    customer.CustomerId = int.Parse(Console.ReadLine());

                    if (customer.CustomerId == -1)
                        return;

                    if (!customerDAO.SearchCustomerId(customer.CustomerId))
                        Console.WriteLine("\nMã khách hàng chưa có trong bảng. Vui lòng nhập lại hoặc nhấn -1 để thoát !");
                }
                while (customer.CustomerId != -1 && !customerDAO.SearchCustomerId(customer.CustomerId));

                
                Console.Write("\nNhập tên khách hàng mới: ");
                customer.CustomerName = Console.ReadLine();

                if (customerDAO.UpdateCustomer(customer))
                    Console.WriteLine("\nCập nhật thành công");
                else
                    Console.WriteLine("\nCập nhật thất bại");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Function8()
        {
            // CHỨC NĂNG 8
            DAO.OrdersManagement.OrdersDAO ordersDAO = new DAO.OrdersManagement.OrdersDAO();
            DAO.EmployeeManagement.EmployeeDAO employeeDAO = new DAO.EmployeeManagement.EmployeeDAO();
            DAO.CustomerManagement.CustomerDAO customerDAO = new DAO.CustomerManagement.CustomerDAO();

            Console.WriteLine("\n=================================CHỨC NĂNG 8=========================================");
            try
            {
                Order order = new Order();

                order.OrderDate = DateTime.Now;
                do
                {
                    Console.Write("\nNhập mã khách hàng có trong bảng khách hàng : ");
                    order.CustomerId =int.Parse(Console.ReadLine());

                    if (order.CustomerId == -1)
                        return;

                    if (!customerDAO.SearchCustomerId(order.CustomerId))
                        Console.WriteLine("\nMã khách hàng chưa có trong bảng. Vui lòng nhập lại hoặc nhấn -1 để thoát !");
                }
                while (order.CustomerId != -1 && !customerDAO.SearchCustomerId(order.CustomerId));

                do
                {
                    Console.Write("\nNhập mã nhân viên có trong bảng nhân viên: ");
                    order.EmployeeId = int.Parse(Console.ReadLine());

                    if (order.EmployeeId == -1)
                        return;

                    if (!employeeDAO.SearchEmployeeId(order.EmployeeId))
                        Console.WriteLine("\nMã nhân viên chưa có trong bảng. Vui lòng nhập lại hoặc nhấn -1 để thoát !");
                }
                while (order.EmployeeId != -1 && !employeeDAO.SearchEmployeeId(order.EmployeeId));

                order.Total = 0;

                if (ordersDAO.AddOrder(order))
                    Console.WriteLine("\nThêm đơn hàng mới thành công!!!");
                else
                    Console.WriteLine("\nThêm đơn hơn hàng mới thất bại !");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Function9()
        {
            // CHỨC NĂNG 9
            DAO.LineItemManagement.LineItemDAO lineItemDAO = new DAO.LineItemManagement.LineItemDAO();
            DAO.ProductManagement.ProductDAO productDAO = new DAO.ProductManagement.ProductDAO();
            DAO.OrdersManagement.OrdersDAO ordersDAO = new DAO.OrdersManagement.OrdersDAO();

            Console.WriteLine("\n=================================CHỨC NĂNG 9=========================================");
            try
            {
                LineItem lineItem = new LineItem();

                do
                {
                    Console.Write("\nNhập mã đơn hàng có trong bảng đơn hàng: ");

                    lineItem.OrderId = int.Parse(Console.ReadLine());

                    if (lineItem.OrderId == -1)
                        return;

                    if (!ordersDAO.SearchOrderId(lineItem.OrderId))
                        Console.WriteLine("\nMã đơn hàng chưa có trong bảng. Vui lòng nhập lại hoặc nhấn -1 để thoát !");
                }
                while (lineItem.OrderId != -1 && !ordersDAO.SearchOrderId(lineItem.OrderId));

                do
                {
                    Console.Write("\nNhập mã sản phẩm có trong bảng sản phẩm :  ");

                    lineItem.ProductId = int.Parse(Console.ReadLine());

                    if (lineItem.ProductId == -1)
                        return;

                    if (!productDAO.SearchProductId(lineItem.ProductId))
                        Console.WriteLine("\nMã sản phẩm chưa có trong bảng. Vui lòng nhập lại hoặc nhẫn -1 để thoát !");
                }
                while (lineItem.ProductId != -1 && !productDAO.SearchProductId(lineItem.ProductId));
                
                Console.Write("\nNhập số lượng sản phẩm: ");
                lineItem.Quantity = int.Parse(Console.ReadLine());

                Console.Write("\nNhập giá thành sản phẩm: ");
                lineItem.Price = double.Parse(Console.ReadLine());

                if (lineItemDAO.AddLineItem(lineItem))
                    Console.WriteLine("\nThành công!!!");
                else
                    Console.WriteLine("\nThất bại!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Function10()
        {
            // CHỨC NĂNG 10
            DAO.LineItemManagement.LineItemDAO lineItemDAO = new DAO.LineItemManagement.LineItemDAO();

            Console.WriteLine("=================================CHỨC NĂNG 10=========================================");

            try
            {
                int orderId;

                Console.Write("\nNhập mã đơn hàng để cập nhập tổng tiền: ");

                orderId = int.Parse(Console.ReadLine());

                if (lineItemDAO.SearchOrderId(orderId))
                {
                    if (lineItemDAO.UpdateOrderTotal(orderId))
                    {
                        Console.WriteLine("\nTổng giá tiền sau khi cập nhật là: {0}", lineItemDAO.ComputeOrderTotal(orderId));

                        Console.WriteLine("\nCập nhật thành công!!!");
                    }
                }
                else
                {
                    Console.WriteLine("\nMã đơn hàng : {0} không tồn tại danh sách mua hàng. Vui lòng kiểm tra lại!", orderId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
