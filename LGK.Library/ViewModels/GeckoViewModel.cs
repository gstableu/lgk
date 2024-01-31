
namespace LGK.Library.ViewModels
{
    public class GeckoViewModel
    {
        public Guid? Id { get; set; }
        public Guid? SireId { get; set; }
        public string? SireName { get; set; }
        public Guid? DamId { get; set; }
        public string? DamName { get; set; }
        public string? Name { get; set; }
        public string? Class { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfIncubation { get; set; }
        public List<ViewModelMorph>? Morph { get; set; }
    }
}
