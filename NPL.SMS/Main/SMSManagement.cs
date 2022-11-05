using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace R2S.Training.Main
{
    class SMSManagement
    {
        static void Menu()
        {
            Console.WriteLine("\n\t\t========================MENU===========================");
            Console.WriteLine("\t\t1. Liệt kê các khách hàng đã mua hàng.");
            Console.WriteLine("\t\t2. Liệt kê các đơn hàng bằng mã khách hàng.");
            Console.WriteLine("\t\t3. Liệt kê chi tiết đơn hàng bằng mã đơn hàng.");
            Console.WriteLine("\t\t4. Tính tổng tiền.");
            Console.WriteLine("\t\t5. Thêm khách hàng vào danh sách.");
            Console.WriteLine("\t\t6. Xóa khách hàng trong danh sách.");
            Console.WriteLine("\t\t7. Cập nhật lại danh sách khách hàng.");
            Console.WriteLine("\t\t8. Tạo đơn hàng mới.");
            Console.WriteLine("\t\t9. Tạo chi tiết đơn hàng mới.");
            Console.WriteLine("\t\t10. Cập nhật tổng giá tiền của một đơn hàng bất kỳ.");
            Console.WriteLine("\t\t0. Thoát chương trình.");
            Console.WriteLine("\t\t=======================================================");
            Console.Write("\nNhập lựa chọn của bạn:\t");
        }
        
        static void Main(string[] args)
        {
            FunctionManagement function = new FunctionManagement();
            // Nhập xuất dữ liệu tiếng việt
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            string check;
           while(true)
            {
                Menu();
                check = Console.ReadLine();
                switch(check)
                {
                    //chuc nang 1
                    case "1":
                        function.Function1();
                        function.Delay();
                        break;
                    // chuc nang 2
                    case "2":
                        function.Function2();
                        function.Delay();
                        break;
                    // chuc nang 3
                    case "3":
                        function.Function3();
                        function.Delay();
                        break;
                    // chuc nang 4
                    case "4":
                        function.Function4();
                        function.Delay();
                        break;
                    // chuc nang 5
                    case "5":
                        function.Function5();
                        function.Delay();
                        break;
                    // chuc nang 6
                    case "6":
                        function.Function6();
                        function.Delay();
                        break;
                    // chuc nang 7
                    case "7":
                        function.Function7();
                        function.Delay();
                        break;
                    // chuc nang 8
                    case "8":
                        function.Function8();
                        function.Delay();
                        break;
                    // chuc nang 9
                    case "9":
                        function.Function9();
                        function.Delay();
                        break;
                    // chuc nang 10
                    case "10":
                        function.Function10();
                        function.Delay();
                        break;
                    // thoat chuong trinh
                    case "0":
                        function.Thanksforuser();
                        return ;
                    // loi 
                    default:
                        function.ShowError();
                        break;
                }
           }
        }
    }
}