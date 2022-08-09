using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace payment_test
{
    public class info
    {
        
        public int Id { get; set; }

        [Required]
        public string? Name {get; set; }

        public int Phone { get; set; }


        public int Age {get;set;}


        public bool Gender { get; set; }

        [StringLength(20,MinimumLength = 3,ErrorMessage ="Invalid Name" )]
        public string? Comment { get; set; }
    }
}
