using HMS.BL.Interface;
using HMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HMS.Webapi.Controllers
{
    public class BookingController : ApiController
    {
        private readonly IHotelManage _hotelManage;

        public BookingController(IHotelManage hotelManage)
        {
            _hotelManage = hotelManage;
        }

        public List<BookingModel> Get()
        {
            return _hotelManage.GetBookRooms(); ;
        }

        public BookingModel Get(int id)
        {
            return _hotelManage.GetBookRoom(id);
        }

        public string Post([FromBody] BookingModel value)
        {
            return _hotelManage.BookRoom(value);
        }

        public string Put([FromBody] BookingModel value)
        {
            return _hotelManage.UpdateBookRoom(value);
        }

        public string Delete(int id)
        {
            return _hotelManage.DeleteBookRoom(id);
        }
    }
}
