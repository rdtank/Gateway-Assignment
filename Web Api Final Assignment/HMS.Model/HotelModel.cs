using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class HotelModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelModel()
        {
            this.Booking = new HashSet<BookingModel>();
            this.Rooms = new HashSet<RoomModel>();
        }
        public int Hotel_Id { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public Nullable<long> ContactNumer { get; set; }
        public string ContactPerson { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string IsActive { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingModel> Booking { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoomModel> Rooms { get; set; }
    }
}
