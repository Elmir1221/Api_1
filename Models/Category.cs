using System.ComponentModel.DataAnnotations;

namespace ApiPB101.Models
{
    public class Category : BaseEntity

    {
        [StringLength(10)]
        public string Name { get; set; }
    }
}
