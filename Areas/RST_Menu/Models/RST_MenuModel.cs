namespace Hotel_Project.Areas.RST_Menu.Models
{
    public class RST_MenuModel
    {
        public int? MenuItemID { get; set; }

        public int MenuTypeID { get; set; }

        public string MenuName { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        //public DateTime CreationDate { get; set; }

        //public DateTime ModificationDate { get; set; }

        public IFormFile File { get; set; }

        public string PhotoPath { get; set; }

        public int? UserID { get; set;}
    }
    
    public class RST_Menu_SearchModel
    {
        public string? MenuName { get; set; }

        public string? Price { get; set; }
    }
}
