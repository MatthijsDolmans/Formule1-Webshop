using Logic;

namespace F1_Webshop.Models
{
    public class UserViewModel
    {
        public string? Name { get; set; }
        public string? Email { get;  set; }
        public string? password { get;  set; }
        public string ?ChosenEmail { get; set; }
        public List<User> ?Users { get; set; }
    }
}
