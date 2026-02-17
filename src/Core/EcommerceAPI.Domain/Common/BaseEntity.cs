namespace EcommerceAPI.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; private set; }
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}

public abstract class AuditableEntity : BaseEntity
{
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public string? CreatedBy { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public string? UpdatedBy { get; private set; }
    public bool IsDeleted { get; private set; }

    public void SetCreated(string? userId = null)
    {
        CreatedAt = DateTime.UtcNow;
        CreatedBy = userId;
    }

    public void SetUpdated(string? userId = null)
    {
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = userId;
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void Restore()
    {
        IsDeleted = false;
    }
}
