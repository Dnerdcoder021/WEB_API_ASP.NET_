using System.ComponentModel.DataAnnotations;

namespace WEB_API_PORTAL.models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string? Name  { get; set; }
        public string? Email  { get; set; }
        public string? Password  { get; set; }
        //public string? Mobile  { get; set; }
  
    }
}
