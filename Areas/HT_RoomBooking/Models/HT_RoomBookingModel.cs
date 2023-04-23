namespace Hotel_Project.Areas.HT_RoomBooking.Models
{
    public class HT_RoomBookingModel
    {
        public int? RoomBookingID { get; set; }

        public int DocumentID { get; set; }

        public int RoomTypeID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int MobileNo { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int DocumentNumber { get; set; }

        //public DateTime CreationDate { get; set; }

        //public DateTime ModificationDate { get; set; }

        public IFormFile File { get; set; }

        public string PhotoPath { get; set; }

        public int? UserID { get; set; }
    }

    public class HT_RoomBooking_SearchModel
    {
        public string? DocumentType { get; set; }

        public string? RoomTypeName { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? MobileNo { get; set; }

        public string? Email { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public string? DocumentNumber { get; set; }
    }
}
