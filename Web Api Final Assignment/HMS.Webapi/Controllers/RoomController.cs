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
    public class RoomController : ApiController
    {
        private readonly IHotelManage _hotelManage;

        public RoomController(IHotelManage hotelManage)
        {
            _hotelManage = hotelManage;
        }

        public List<RoomModel> Get()
        {
            return _hotelManage.GetRooms();
        }

        public RoomModel Get(int id)
        {
            return _hotelManage.GetRoom(id);
        }

        public string Post([FromBody] RoomModel value)
        {
            return _hotelManage.CreateRoom(value);
        }

        public string Put([FromBody] RoomModel value)
        {
            return _hotelManage.UpdateRoom(value);
        }

    }
}
