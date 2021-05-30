using System.ComponentModel.DataAnnotations;

namespace KPI.SportStuffInternetShop.Models.RequestModels {
    public class Register {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
            ErrorMessage = "Пароль повинен містити не меньш 1 великої літери, 1 малої літери, 1 число, 1 не число, на всього не меньше 6 знаків")]
        public string Password { get; set; }
    }
}
