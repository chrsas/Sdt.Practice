using System.ComponentModel.DataAnnotations;

namespace Sdt.Practice.Domain.Models
{
    public class Country
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string EnglishName { get; set; }

        [MaxLength(100)]
        public string ChineseName { get; set; }
    }
}