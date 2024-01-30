namespace TechAdvocacia.Core.Entities;

public abstract class BaseEntity{
    public DateTimeOffset reatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}