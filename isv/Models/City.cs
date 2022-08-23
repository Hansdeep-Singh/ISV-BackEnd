using System.ComponentModel.DataAnnotations.Schema;

namespace isv.Models
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
