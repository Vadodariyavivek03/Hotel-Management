namespace Hotel_Project.Areas.HT_RoomType.Models
{
    public class HT_RoomTypeModel
    {
        public int? RoomTypeID { get; set; }

        public string RoomTypeName { get; set; }

        public int Capacity { get; set; }

        public int RoomNumber { get; set; }

        public string Facilities { get; set; }

        public int Price { get; set; }

        //public DateTime CreationDate { get; set; }

        //public DateTime ModificationDate { get; set; }

        //public IFormFile File { get; set; }

        //public string PhotoPath { get; set; }

        public int? UserID { get; set; }
    }

    public class HT_RoomType_DropDownModel
    {
        public int RoomTypeID { get; set; }

        public string RoomTypeName { get; set; }
    }

    public class HT_RoomType_SearchModel
    {
        public string? RoomTypeName { get; set; }

        public string? Capacity { get; set; }

        public string? RoomNumber { get; set; }

        public string? Facilities { get; set; }

        public string? Price { get; set; }

    }
}
