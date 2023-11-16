using System.ComponentModel.DataAnnotations;

namespace Electronic_Web_App.ViewModel
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }

        //--------------------------------------

        [DataType(DataType.Password)]
        public string Password { get; set; }

        //--------------------------------------
        [Compare("Password")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }

        //--------------------------------------


        public string Email { get; set; }

        //--------------------------------------


        public int PhoneNumber { get; set; }

        //--------------------------------------


        public string Address { get; set; }

        //--------------------------------------

    }
}
