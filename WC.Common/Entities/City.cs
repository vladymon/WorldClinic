using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Common.Entities
{
    public class City
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} debe contener menos de {1} carateres ")]
        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int IdDepartment { get; set; }
    }
}
