using LGK.Library;

namespace LGK.Geckos.Models
{
    public class Gecko : EntityBase
    {
        public Guid? SireId { get; set; }
        public Guid? DamId { get; set; }
        public string? Name { get; set; }
        public string? Class { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfIncubation { get; set; }
        public List<Morph>? Morph { get; set; }

    }
}
