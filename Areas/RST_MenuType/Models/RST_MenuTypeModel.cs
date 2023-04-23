namespace Hotel_Project.Areas.RST_MenuType.Models
{
    public class RST_MenuTypeModel
    {
        public int? MenuTypeID { get; set; }

        public string MenuTypeName { get; set; }

        //public DateTime CreationDate { get; set; }

        //public DateTime ModificationDate { get; set; }

        //public IFormFile File { get; set; }

        //public string PhotoPath { get; set; }
        public int? UserID { get; set; }
    }

    public class RST_MenuType_DropDownModel
    {
        public int MenuTypeID { get; set; }

        public string MenuTypeName { get; set; }
    }

    public class RST_MenuType_SearchModel
    {
        public string? MenuTypeName { get; set; }

    }
}
