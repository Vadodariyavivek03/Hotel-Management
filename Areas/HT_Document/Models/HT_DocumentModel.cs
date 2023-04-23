namespace Hotel_Project.Areas.HT_Document.Models
{
    public class HT_DocumentModel
    {
        public int? DocumentID { get; set; }

        public string DocumentType { get; set; }

        //public IFormFile File { get; set; }

        //public string PhotoPath { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public int? UserID { get; set; }
    }

    public class HT_Document_DropDownModel
    {
        public int DocumentID { get; set; }

        public string DocumentType { get; set; }
    }

    public class HT_Document_SearchModel
    {
       public string? DocumentType { get; set; }
    }
}
