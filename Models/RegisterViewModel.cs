using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class RegisterViewModel
    {
        [Required] // zorunlu hale getirir
        [Display(Name="UserName")]
        public string? UserName { get; set; }

        [Required] // zorunlu hale getirir
        [Display(Name="Ad Soyad")]
        public string? Name { get; set; }

        [Required] // zorunlu hale getirir
        [EmailAddress]
        [Display(Name="Eposta")]
        public string? Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage ="{0} alanı en az {2}, en fazla {1} karakter uzunluğunda olmalıdır ", MinimumLength =6)]
        [DataType(DataType.Password)]
        [Display(Name ="Parola")]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage ="Parolanız Eşleşmiyor")]
        [Display(Name ="ParolaTekrar")]
        public string? ConfirmPassword { get; set; }
    }
}