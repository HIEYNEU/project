using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class customer
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public int age { set; get; }
        public string address { set; get; }
        public string gender { set; get; }
        public customer()
        {

        }
        public void input()
        {
            Console.Write("Nhap CMND: ");
            while (true)
            {
                id = Console.ReadLine();
                if (id.Length == 9||id.Length == 12)
                {
                    break;
                }
                else Console.WriteLine("CMND khong hop le >> Nhap lai");
            }
            inputNew();
        }
        public void inputNew()
        {
            Console.Write("Nhap ten khach hang: ");
            fullName = Console.ReadLine();
            Console.Write("Nhap tuoi: ");
            age = (int)System.Int64.Parse(Console.ReadLine());
            Console.Write("Nhap dia chi: ");
            address = Console.ReadLine();
            Console.Write("Nhap gioi tinh: ");
            while (true)
            {
                gender = Console.ReadLine();
                if (gender == "NAM" || gender == "Nam" || gender == "Nu" || gender == "NU")
                {
                    break;
                }
                else Console.WriteLine("Gioi tinh khong xac dinh >> Nhap lai");
            }
        }
        public void display()
        {
            Console.WriteLine("Thong tin khach hang (Ho ten: {0}, Tuoi: {1}, CMND: {2}, Dia chi: {3}, Gioi tinh: {4})", fullName, age, id, address, gender);
        }
    }
}
