using HMS.DL.DB;
using HMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DL.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelManagementDBEntities dbContext;

        public HotelRepository()
        {
            dbContext = new HotelManagementDBEntities();
        }

        public string BookRoom(BookingModel model)
        {
            try
            {
                if (model != null)
                {
                    Booking dealer = new Booking
                    {
                        Booking_Id = model.Booking_Id,
                        Room_Id = model.Room_Id,
                        Hotel_Id = model.Hotel_Id,
                        StatusOfBooking = model.StatusOfBooking,
                        IsActive = model.IsActive
                    };

                    dbContext.Booking.Add(dealer);
                    dbContext.SaveChanges();

                    return "Room Booked!";
                }
                return "No Data Found!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string CreateHotel(HotelModel model)
        {
            try
            {
                if (model != null)
                {
                    Hotels hotel = new Hotels
                    {
                        Hotel_Id = model.Hotel_Id,
                        HotelName = model.HotelName,
                        Address = model.Address,
                        City = model.City,
                        Pincode = model.Pincode,
                        ContactNumer = model.ContactNumer,
                        ContactPerson = model.ContactPerson,
                        CreatedBy = model.CreatedBy,
                        CreateDate = DateTime.Now,
                        Website = model.Website,
                        Facebook = model.Facebook,
                        Twitter = model.Twitter,
                        IsActive = model.IsActive
                    };

                    dbContext.Hotels.Add(hotel);
                    dbContext.SaveChanges();

                    return "Hotel Added.";
                }
                return "No Data Found!";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string CreateRoom(RoomModel model)
        {
            try
            {
                if (model != null)
                {
                    Rooms dealer = new Rooms
                    {
                        Hotel_Id = model.Hotel_Id,
                        Room_Id = model.Room_Id,
                        RoomName = model.RoomName,
                        Category = model.Category,
                        Price = model.Price,
                        IsActive = model.IsActive,
                        CreateDate = DateTime.Now,
                        CreatedBy = model.CreatedBy
                    };

                    dbContext.Rooms.Add(dealer);
                    dbContext.SaveChanges();

                    return "Room Added!";
                }

                return "No Data Found!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteBookRoom(int Id)
        {
            try
            {
                var entity = dbContext.Booking.Find(Id);

                if (entity != null)
                {
                    dbContext.Booking.Remove(entity);
                    dbContext.SaveChanges();

                    return "Remove Booked Room!";
                }

                return "No data found";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public List<HotelModel> GetAllHotels()
        {
            List<HotelModel> list = new List<HotelModel>();

            var data = dbContext.Hotels.OrderBy(x => x.HotelName).ToList();

            if (data != null)
            {
                foreach (var item in data)
                {
                    HotelModel hotel = new HotelModel
                    {
                        Hotel_Id = item.Hotel_Id,
                        HotelName = item.HotelName,
                        Address = item.Address,
                        City = item.City,
                        Pincode = item.Pincode,
                        ContactNumer = item.ContactNumer,
                        ContactPerson = item.ContactPerson,
                        CreatedBy = item.CreatedBy,
                        CreateDate = item.CreateDate,
                        UpdateDate = item.UpdateDate,
                        UpdatedBy = item.UpdatedBy,
                        Website = item.Website,
                        Facebook = item.Facebook,
                        Twitter = item.Twitter,
                        IsActive = item.IsActive
                    };

                    list.Add(hotel);
                }

            }
            return list;
        }

        public BookingModel GetBookRoom(int Id)
        {
            var entity = dbContext.Booking.Find(Id);


            BookingModel dealer = new BookingModel();

            if (entity != null)
            {
                dealer.Booking_Id = entity.Booking_Id;
                dealer.Room_Id = entity.Room_Id;
                dealer.Hotel_Id = entity.Hotel_Id;
                dealer.StatusOfBooking = entity.StatusOfBooking;
                dealer.IsActive = entity.IsActive;
            }
            return dealer;
        }

        public List<BookingModel> GetBookRooms()
        {
            var entities = dbContext.Booking.ToList();

            List<BookingModel> list = new List<BookingModel>();

            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    BookingModel dealer = new BookingModel
                    {
                        Booking_Id = entity.Booking_Id,
                        Room_Id = entity.Room_Id,
                        Hotel_Id = entity.Hotel_Id,
                        StatusOfBooking = entity.StatusOfBooking,
                        IsActive = entity.IsActive
                    };
                    list.Add(dealer);
                }
            }
            return list;
        }

        public HotelModel GetHotel(int id)
        {
            try
            {
                var item = dbContext.Hotels.Find(id);
                if (item != null)
                {
                    HotelModel hotel = new HotelModel
                    {
                        Hotel_Id = item.Hotel_Id,
                        HotelName = item.HotelName,
                        Address = item.Address,
                        City = item.City,
                        Pincode = item.Pincode,
                        ContactNumer = item.ContactNumer,
                        ContactPerson = item.ContactPerson,
                        CreatedBy = item.CreatedBy,
                        CreateDate = item.CreateDate,
                        UpdatedBy = item.UpdatedBy,
                        Website = item.Website,
                        Facebook = item.Facebook,
                        Twitter = item.Twitter,
                        IsActive = item.IsActive
                    };

                    return hotel;
                }

                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public RoomModel GetRoom(int Id)
        {
            var item = dbContext.Rooms.Find(Id);


            RoomModel dealer = new RoomModel();

            if (item != null)
            {
                dealer.Hotel_Id = item.Hotel_Id;
                dealer.RoomName = item.RoomName;
                dealer.Category = item.Category;
                dealer.IsActive = item.IsActive;
                dealer.Price = item.Price;
                dealer.CreateDate = item.CreateDate;
                dealer.UpdateDate = item.UpdateDate;
                dealer.IsActive = item.IsActive;
                dealer.CreatedBy = item.CreatedBy;
                dealer.UpdatedBy = item.UpdatedBy;
            }
            return dealer;
        }

        public List<RoomModel> GetRooms()
        {
            var entities = dbContext.Rooms.ToList();

            List<RoomModel> list = new List<RoomModel>();

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    RoomModel dealer = new RoomModel();
                    {
                        dealer.Hotel_Id = item.Hotel_Id;
                        dealer.RoomName = item.RoomName;
                        dealer.Category = item.Category;
                        dealer.IsActive = item.IsActive;
                        dealer.Price = item.Price;
                        dealer.CreateDate = item.CreateDate;
                        dealer.UpdateDate = item.UpdateDate;
                        dealer.IsActive = item.IsActive;
                        dealer.CreatedBy = item.CreatedBy;
                        dealer.UpdatedBy = item.UpdatedBy;
                    }
                    list.Add(dealer);
                }
            }
            return list;
        }

        public string UpdateBookRoom(BookingModel model)
        {
            try
            {
                var dealer = dbContext.Booking.Find(model.Booking_Id);

                if (model != null)
                {
                    dealer.Booking_Id = model.Booking_Id;
                    dealer.Room_Id = model.Room_Id;
                    dealer.Hotel_Id = model.Hotel_Id;
                    dealer.StatusOfBooking = model.StatusOfBooking;
                    dealer.IsActive = model.IsActive;

                    dbContext.SaveChanges();
                    return "Booked Room Updated!";
                }
                return "No data found";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string UpdateHotel(HotelModel model)
        {
            try
            {
                var item = dbContext.Hotels.Find(model.Hotel_Id);
                if (item != null)
                {
                    DB.Hotels hotel = new DB.Hotels
                    {
                        Hotel_Id = item.Hotel_Id,
                        HotelName = item.HotelName,
                        Address = item.Address,
                        City = item.City,
                        Pincode = item.Pincode,
                        ContactNumer = item.ContactNumer,
                        ContactPerson = item.ContactPerson,
                        Website = item.Website,
                        Facebook = item.Facebook,
                        Twitter = item.Twitter,
                        IsActive = item.IsActive,
                        UpdateDate = item.UpdateDate,
                        UpdatedBy = item.UpdatedBy
                    };

                    dbContext.SaveChanges();

                    return "Hotel Updated.";
                }
                return "No Data Found!";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string UpdateRoom(RoomModel model)
        {
            try
            {
                var dealer = dbContext.Rooms.Find(model.Hotel_Id);

                if (model != null)
                {
                    dealer.Hotel_Id = model.Hotel_Id;
                    dealer.RoomName = model.RoomName;
                    dealer.Category = model.Category;
                    dealer.IsActive = model.IsActive;
                    dealer.Price = model.Price;
                    dealer.UpdateDate = DateTime.Now;
                    dealer.IsActive = model.IsActive;
                    dealer.UpdatedBy = model.UpdatedBy;

                    dbContext.SaveChanges();
                    return "Room Updated!";
                }
                return "No data found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
