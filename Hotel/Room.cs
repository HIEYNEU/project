using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Room
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Floor { get; set; }
        public int personalMax { get; set; }
        public string id { get; set; }
        public Room()
        {

        }
        public void input()
        {
            Console.Write("Nhap ten phong: ");
            Name = Console.ReadLine();
            Console.Write("Nhap ma phong: ");
            id = Console.ReadLine();
            Console.Write("Nhap gia phong: ");
            Price = (int)System.Int64.Parse(Console.ReadLine());
            Console.Write("Nhap tang: ");
            Floor = (int)System.Int64.Parse(Console.ReadLine());
            Console.Write("Nhap so nguoi toi da: ");
            personalMax = (int)System.Int64.Parse(Console.ReadLine());
        }
        public void display()
        {
            Console.WriteLine("Thong tin phong (Ten: {0}, id: {1}, Gia: {2}, Tang: {3}, So nguoi toi da: {4})",Name,id,Price,Floor,personalMax);
        }
    }
}
