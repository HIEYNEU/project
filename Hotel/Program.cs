using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            List<customer> customerList = new List<customer>();
            List<Hotel> hotelList = new List<Hotel>();
            List<book> bookList = new List<book>();
            int choose;
            do
            {
                showMenu();
                choose = (int)System.Int64.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        input(hotelList);
                        break;
                    case 2:
                        Display(hotelList);
                        break;
                    case 3:
                        InputBook(bookList, customerList, hotelList);
                        break;
                    case 4:
                        searchAvailableBook(bookList,hotelList);
                        break;
                    case 5:
                        statistic(bookList, hotelList);
                        break;
                    case 6:
                        Search(bookList, hotelList);
                        break;
                    case 7:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Nhap sai");
                        break;
                }
            } while (choose != 7);
            Console.ReadKey();
        }
        static void Search(List<book> bookList, List<Hotel> hotelList)
        {
            Console.Write("Nhap CMND can tim: ");
            string cmnd = Console.ReadLine();
            for(int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].id_cus.Equals(cmnd))
                {
                    Hotel hotel = getHotel(hotelList, bookList[i].id_hol);
                    if (hotel != null)
                    {
                        hotel.display();
                    }
                }
            }
        }
        static Hotel getHotel(List<Hotel> hotelList,string hotelNo)
        {
            for(int i = 0; i < hotelList.Count; i++)
            {
                if (hotelList[i].id.Equals(hotelNo))
                {
                    return hotelList[i];
                }
            }
            return null;
        }
        static void searchAvailableBook(List<book> bookList, List<Hotel> hotelList)
        {
            int checkin;
            int checkout;
            int monthcheckin;
            int monthcheckout;
            Console.Write("Nhap thang dat phong: ");
            monthcheckin = (int)System.Int64.Parse(Console.ReadLine());
            Console.Write("Nhap ngay dat phong: ");
            checkin = (int)System.Int64.Parse(Console.ReadLine());
            Console.Write("Nhap thang tra phong: ");
            monthcheckout = (int)System.Int64.Parse(Console.ReadLine());
            Console.Write("Nhap ngay tra phong: ");
            checkout = (int)System.Int64.Parse(Console.ReadLine());
            for(int i = 0; i < hotelList.Count; i++)
            {
                for(int j = 0; j < hotelList[i].roomList.Count; j++)
                {
                    if (checkAvailable(bookList,hotelList[i].id,hotelList[i].roomList[j].id,checkin,checkout,monthcheckin,monthcheckout))
                    {
                        hotelList[i].display();
                        Console.WriteLine("-------Danh sach phong trong-------");
                        hotelList[i].roomList[j].display();
                    }
                }
            }
        }
        static bool checkAvailable(List<book>bookList,string hotelNo,string roomNo,int checkin,int checkout,int monthcheckin,int monthcheckout)
        {
            for(int i = 0; i < bookList.Count; i++)
            {
                book Book = bookList[i];
                if (Book.id_hol.Equals(hotelNo) && Book.id_room.Equals(roomNo)&&(Book.checkin>=checkin&&Book.checkin<=checkout||Book.checkout
                    <=checkout&&Book.checkout>=checkin))
                {
                    return false;
                }
                else if (Book.id_hol.Equals(hotelNo) && Book.id_room.Equals(roomNo) && (monthcheckin!=monthcheckout&&(Book.MonthCheckin > monthcheckin && Book.MonthCheckout < monthcheckout||Book.MonthCheckout>monthcheckout&&Book.MonthCheckin<monthcheckin)))
                {
                    return false;
                }
                else if(Book.id_hol.Equals(hotelNo) && Book.id_room.Equals(roomNo) && (monthcheckout!=monthcheckin&&(Book.MonthCheckout < monthcheckout && Book.MonthCheckout > monthcheckin || Book.MonthCheckin > monthcheckin && Book.MonthCheckin < monthcheckout || Book.MonthCheckin < monthcheckin && Book.MonthCheckout > monthcheckin || Book.MonthCheckout > monthcheckout && Book.MonthCheckin < monthcheckout)))
                {
                    return false;
                }
                else if(Book.id_hol.Equals(hotelNo) && Book.id_room.Equals(roomNo) &&(monthcheckin!=monthcheckout&& (Book.MonthCheckin==monthcheckout&&Book.checkin<=checkout||Book.MonthCheckout==monthcheckin&&Book.checkout>=checkin)))
                {
                    return false;
                }
                else if(Book.id_hol.Equals(hotelNo) && Book.id_room.Equals(roomNo) && (Book.MonthCheckin == monthcheckin && Book.MonthCheckout == monthcheckout && monthcheckout != monthcheckin && (Book.checkout <= checkout || Book.checkin >= checkin || Book.checkin < checkin && Book.checkout > checkout)))
                {
                    return false;
                }
                else if(Book.id_hol.Equals(hotelNo) && Book.id_room.Equals(roomNo) && (Book.MonthCheckout == monthcheckout && Book.MonthCheckin == monthcheckin && monthcheckin == monthcheckout && (Book.checkin >= checkin && Book.checkout <= checkout || Book.checkin < checkin && Book.checkout > checkout || Book.checkin >= checkin && Book.checkin <= checkout || Book.checkout >= checkin && Book.checkout <= checkout || checkin >= Book.checkin && checkin <= Book.checkout || checkout <= Book.checkout && checkout >= Book.checkin)))
                {
                    return false;
                }
            }
            return true;
        }
        static void input(List<Hotel> hotelList)
        {
            Console.Write("Nhap so khach san can them: ");
            int N = (int)System.Int64.Parse(Console.ReadLine());
            for(int i = 0; i < N; i++)
            {
                Hotel hotel = new Hotel();
                while (true)
                {
                    bool was = false;
                    hotel.input();
                    for (int j = 0; j < hotelList.Count; j++)
                    {
                        if (hotelList[j].id.Equals(hotel.id))
                        {
                            was = true;
                            break;
                        }
                    }
                    if (!was) break;
                    else Console.WriteLine("Nhap lai thong tin khach san");
                }
                hotelList.Add(hotel);
            }
        }
        static void statistic(List<book>bookList,List<Hotel>hotelList)
        {
            for(int i = 0; i < hotelList.Count; i++)
            {
                int total = calculate(bookList, hotelList[i]);
                Console.WriteLine("{0}.{1}-Doanh thu: {2}", i + 1, hotelList[i].Name, total);
            }
        }
        static int calculate(List<book>bookList,Hotel hotel)
        {
            int total = 0;
            for(int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].id_hol.Equals(hotel.id))
                {
                    int price = getMoney(hotel.roomList, bookList[i].id_room);
                    int totalTime=0;
                    if (bookList[i].MonthCheckin != bookList[i].MonthCheckout)
                    {
                        int[] dayNum = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                        totalTime += dayNum[bookList[i].MonthCheckin - 1] - bookList[i].checkin + 1;
                        for(int j = bookList[i].MonthCheckin + 1; j < bookList[i].MonthCheckout; j++)
                        {
                            totalTime += dayNum[j-1];
                        }
                        totalTime += bookList[i].checkout;
                    }
                    else totalTime = (bookList[i].checkout - bookList[i].checkin + 1);
                    total += price * totalTime;
                }
            }
            return total;
        }
        static int getMoney(List<Room> roomList,string roomNo)
        {
            for(int i = 0; i < roomList.Count; i++)
            {
                if (roomList[i].id.Equals(roomNo))
                {
                    return roomList[i].Price;
                }
            }
            return 0;
        }
        static void Display(List<Hotel> hotelList)
        {
            for(int i = 0; i < hotelList.Count; i++)
            {
                hotelList[i].display();
            }
        }
        static void InputBook(List<book> bookList, List<customer> customerList, List<Hotel> hotelList)
        {
            while (true)
            {
                book Book = new book();
                Book.input(customerList, hotelList);
                if (checkAvailable(bookList, Book.id_hol, Book.id_room, Book.checkin, Book.checkout, Book.MonthCheckin, Book.MonthCheckout))
                {
                    bookList.Add(Book);
                    break;
                }
                else Console.WriteLine("Phong da co nguoi khac dat hoac dang dat phong do vui long nhap lai");
            }
        }
        static void showMenu()
        {
            Console.WriteLine("1.Nhap thong tin khach san");
            Console.WriteLine("2.Hien thi thong tin khach san");
            Console.WriteLine("3.Dat phong");
            Console.WriteLine("4.Tim phong con trong");
            Console.WriteLine("5.Thong ke doanh thu khach san");
            Console.WriteLine("6.Tim kiem thong tin khach hang");
            Console.WriteLine("7.Thoat");
            Console.Write("Choose: ");
        }
    }
}
