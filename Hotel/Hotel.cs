using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Hotel
    {
        public string Name { get; set; }
        public string address { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public List<Room> roomList = new List<Room>();
        public Hotel()
        {

        }
        public void input()
        {
            Console.Write("Nhap ten khach san: ");
            Name = Console.ReadLine();
            Console.Write("Nhap ma khach san: ");
            id = Console.ReadLine();
            Console.Write("Nhap dia chi khach san: ");
            address = Console.ReadLine();
            Console.Write("Nhap loai khach san: ");
            while (true)
            {
                type = Console.ReadLine();
                if(type=="VIP"||type=="Binh Dan")
                {
                    break;
                }
                else Console.WriteLine("Khong ton tai loai phong nay >> Nhap lai");
            }
            Console.Write("Nhap so phong can them: ");
            int N = (int)System.Int64.Parse(Console.ReadLine());
            for(int i = 0; i < N; i++)
            {
                Room room = new Room();
                room.input();
                roomList.Add(room);
            }
        }
        public void display()
        {
            Console.WriteLine("Thong tin khach san (Ten: {0}, id: {1}, Dia chi: {2}, Loai phong: {3})",Name,id,address,type);
        }
    }
}
