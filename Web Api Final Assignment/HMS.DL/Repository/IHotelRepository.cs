using HMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DL.Repository
{
    public interface IHotelRepository
    {
        List<HotelModel> GetAllHotels();
        HotelModel GetHotel(int id);
        string CreateHotel(HotelModel model);
        string UpdateHotel(HotelModel model);
        RoomModel GetRoom(int Id);
        List<RoomModel> GetRooms();
        string CreateRoom(RoomModel model);
        string UpdateRoom(RoomModel model);

        BookingModel GetBookRoom(int Id);
        List<BookingModel> GetBookRooms();
        string BookRoom(BookingModel model);
        string UpdateBookRoom(BookingModel model);
        string DeleteBookRoom(int Id);
    }
}
