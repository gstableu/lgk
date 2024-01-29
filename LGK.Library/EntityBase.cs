namespace LGK.Library;

public class EntityBase {
    public Guid Id { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Modified { get; set; } = DateTime.Now;
}
