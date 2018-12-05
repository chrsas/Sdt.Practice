using System.ComponentModel.DataAnnotations;

namespace Sdt.Practice.Application.Dto
{
    public class InsertCountryInput
    {
        [Required]
        [MaxLength(100)]
        public string EnglishName { get; set; }

        [Required]
        [MaxLength(100)]
        public string ChineseName { get; set; }
    }
}