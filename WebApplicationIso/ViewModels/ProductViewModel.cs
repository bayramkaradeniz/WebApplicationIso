using System.ComponentModel.DataAnnotations;

namespace WebApplicationIso.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        //[Remote(action: "HasProductName",controller:"Product")]
        [Required(ErrorMessage = "İsim Alanı Boş Olamaz !")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "İsim Alanına  2-50 Karakter Girilebilir.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Fiyat Alanı Boş Olamaz !")]
        //[RegularExpression(@"^[0-9]+(\,[0-9]{1,2}])", ErrorMessage = "Fiyat Alanında Noktadan Sonra iki basamak olmalıdır.")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Stok Adedi Boş Olamaz !")]
        [Range(0, 200, ErrorMessage = "Belirlenen Aralıkta Değer Giriniz. 1-200 ")]
        public int? Stock { get; set; }
        public bool IsPublished { get; set; }

        [Required(ErrorMessage = "Süre Boş Olamaz !")]
        public int? Expire { get; set; }

        [Required(ErrorMessage = "Açıklama Alanı Boş Olamaz !")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "İsim Alanına  10-100 Karakter Girilebilir.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Yayınlanma Tarihi Boş Olamaz !")]
        public DateTime? PublishDate { get; set; }

        //[EmailAddress(ErrorMessage ="Email Adresi Girin.")]
        //public string Email { get; set; }
    }
}
