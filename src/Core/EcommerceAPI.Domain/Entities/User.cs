using EcommerceAPI.Domain.Common;

namespace EcommerceAPI.Domain.Entities;

public class User : AuditableEntity
{
    private readonly List<Order> _orders = new();

    private User() { }

    public User(string email, string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.");

        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Email { get; private set; } = default!;
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;

    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();
}
