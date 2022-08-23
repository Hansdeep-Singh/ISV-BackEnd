using System.ComponentModel.DataAnnotations.Schema;

namespace isv.Models
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City City { get; set; }

    }
}
