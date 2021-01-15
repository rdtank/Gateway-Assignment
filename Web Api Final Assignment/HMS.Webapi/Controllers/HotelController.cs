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
    public class HotelController : ApiController
    {
        private readonly IHotelManage _hotelManage;

        public HotelController(IHotelManage hotelManage)
        {
            _hotelManage = hotelManage;
        }

        // GET: api/Hotel

        public List<HotelModel> GetHotels()
        {
            return _hotelManage.GetAllHotels();
        }

        public HotelModel Get(int id)
        {
            return _hotelManage.GetHotel(id);
        }

        public string Post([FromBody] HotelModel value)
        {
            return _hotelManage.CreateHotel(value);
        }

        public string Put([FromBody] HotelModel value)
        {
            return _hotelManage.UpdateHotel(value);
        }

        public void Delete(int id)
        {
        }
    }
}
