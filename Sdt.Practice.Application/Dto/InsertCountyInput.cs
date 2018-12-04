using System.ComponentModel.DataAnnotations;

namespace Sdt.Practice.Application.Dto
{
    public class InsertCountyInput
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string EnglishName { get; set; }

        [Required]
        [MaxLength(100)]
        public string ChineseName { get; set; }
    }
}