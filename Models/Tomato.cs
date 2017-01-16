using System;
using System.ComponentModel.DataAnnotations;

namespace TomatoAPI
{
    public class Tomato
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [DataType(DataType.PostalCode)]
        public string OriginPostCode { get; set; }
        public TasteRating Tastes { get; set; }
    }
    public enum TasteRating
    {
        Terrible,
        Eh,
        Good,
        Great,
        Superb
    }
}