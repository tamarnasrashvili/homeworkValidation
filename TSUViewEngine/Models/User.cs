using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TSUViewEngine.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "ველი სავალდებულოა")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "ელ. ფოსტის მისამართი არ არის ვალიდური")]
        public string Email { get; set; }

        [Required(ErrorMessage = "პაროლი სავალდებულოა")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "პაროლის დადასტურება სავალდებულოა")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="პაროლი და პაროლის დადასტურება ერთმანეთს არ ემთხვევა")]
        public string PasswordConfirmation { get; set; }
    }
}
