using System.ComponentModel.DataAnnotations;

namespace TW.Models
{
    public class User
    {
        [Key]
        public long UserId { get; set; }  

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name required")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}
