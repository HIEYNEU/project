using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class book
    {
        public int MonthCheckin { get; set; }
        public int MonthCheckout { get; set; }
        public int checkin { get; set; }
        public int checkout { get; set; }
        public string id_cus { get; set; }
        public string id_hol { get; set; }
        public string id_room { get; set; }
        public book()
        {

        }
        public void input(List<customer>CustomerList,List<Hotel>hotelList)
        {
            Console.Write("Nhap CMND khach hang: ");
            while (true)
            {
                id_cus = Console.ReadLine();
                if (id_cus.Length == 9 || id_cus.Length == 12) break;
                else Console.WriteLine("CMND khong hop le >> Nhap lai");
            }
            bool isFind = false;
            for(int i = 0; i < CustomerList.Count; i++)
            {
                if (CustomerList[i].id.Equals(id_cus))
                {
                    isFind = true;
                    break;
                }
            }
            if (!isFind)
            {
                Console.WriteLine("Khach hang chua ton tai >> Nhap moi");
                customer Customer = new customer();
                Customer.id = id_cus;
                Customer.inputNew();
                CustomerList.Add(Customer);
            }
            showHotelMenu(hotelList);
            Hotel hotel = null;
            while (true)
            {
                id_hol = Console.ReadLine();
                isFind = false;
                for(int i = 0; i < hotelList.Count; i++)
                {
                    if (hotelList[i].id.Equals(id_hol))
                    {
                        isFind = true;
                        hotel = hotelList[i];
                        break;
                    }
                }
                if (isFind) break;
                else Console.WriteLine("Nhap lai ma khach san");
            }
            showRoomMenu(hotel);
            while (true)
            {
                id_room = Console.ReadLine();
                isFind = false;
                for(int i = 0; i < hotel.roomList.Count; i++)
                {
                    if (hotel.roomList[i].id.Equals(id_room))
                    {
                        isFind = true;
                        break;
                    }
                }
                if (isFind) break;
                else Console.WriteLine("Nhap lai ma phong");
            }
            Console.WriteLine("Nhap thoi gian check in");
            Console.Write("Nhap thang checkin: ");
            MonthCheckin = (int)System.Int64.Parse(Console.ReadLine());
            Console.Write("Nhap ngay checkin: ");
            checkin = (int)System.Int64.Parse(Console.ReadLine());
            Console.WriteLine("Nhap thoi gian checkout");
            Console.Write("Nhap thang checkout: ");
            MonthCheckout = (int)System.Int64.Parse(Console.ReadLine());
            Console.Write("Nhap ngay checkout: ");
            checkout = (int)System.Int64.Parse(Console.ReadLine());
        }
        public void showHotelMenu(List<Hotel> hotelList)
        {
            for(int i = 0; i < hotelList.Count; i++)
            {
                Console.WriteLine("{0}.{1}-{2}", i + 1, hotelList[i].Name, hotelList[i].id);
            }
            Console.Write("Nhap ma khach san muon chon: ");
        }
        public void showRoomMenu(Hotel hotel)
        {
            for(int i = 0; i < hotel.roomList.Count; i++)
            {
                Console.WriteLine("{0}.{1}-{2}", i + 1, hotel.roomList[i].Name, hotel.roomList[i].id);
            }
            Console.Write("Nhap ma phong ban muon chon: ");
        }
    }
}
