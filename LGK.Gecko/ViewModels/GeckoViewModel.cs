using LGK.Geckos.Models;

namespace LGK.Geckos.ViewModels
{
    public class GeckoViewModel
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
