namespace MVC.Models
{
    public class tblstudent
    {
        public int id{get; set;}
        public string studentname { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string language { get; set; }
        public int course_id { get; set; }
        public double phonenumber { get; set; }
        public DateTime dbo { get; set; }
        public string image { get; set; }
        public string document { get; set; }
    }
}