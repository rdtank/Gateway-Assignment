using HMS.DL.Repository;
using HMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BL.Interface
{
    public class HotelManage : IHotelManage
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManage(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public string BookRoom(BookingModel model)
        {
            return _hotelRepository.BookRoom(model);
        }

        public string CreateHotel(HotelModel model)
        {
            return _hotelRepository.CreateHotel(model);
        }

        public string CreateRoom(RoomModel model)
        {
            return _hotelRepository.CreateRoom(model);
        }

        public string DeleteBookRoom(int Id)
        {
            return _hotelRepository.DeleteBookRoom(Id);
        }

        public List<HotelModel> GetAllHotels()
        {
            return _hotelRepository.GetAllHotels();
        }

        public BookingModel GetBookRoom(int Id)
        {
            return _hotelRepository.GetBookRoom(Id);
        }

        public List<BookingModel> GetBookRooms()
        {
            return _hotelRepository.GetBookRooms();
        }

        public HotelModel GetHotel(int id)
        {
            return _hotelRepository.GetHotel(id);
        }

        public RoomModel GetRoom(int Id)
        {
            return _hotelRepository.GetRoom(Id);
        }

        public List<RoomModel> GetRooms()
        {
            return _hotelRepository.GetRooms();
        }

        public string UpdateBookRoom(BookingModel model)
        {
            return _hotelRepository.UpdateBookRoom(model);
        }

        public string UpdateHotel(HotelModel model)
        {
            return _hotelRepository.UpdateHotel(model);
        }

        public string UpdateRoom(RoomModel model)
        {
            return _hotelRepository.UpdateRoom(model);
        }
    }
}
