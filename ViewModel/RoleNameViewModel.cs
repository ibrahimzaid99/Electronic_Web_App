using System.ComponentModel.DataAnnotations;

namespace Electronic_Web_App.ViewModel
{
    public class RoleNameViewModel
    {
        [Required]
        public string? RoleName { get; set; }
    }
}
