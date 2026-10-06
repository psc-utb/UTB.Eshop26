namespace UTB.Eshop.Domain.Entities.Interfaces
{
    public interface IUser<TKey> : IEntity<TKey> where TKey : notnull
    {
        string? UserName { get; set; }
        string? Email { get; set; }
        string? PhoneNumber { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
    }
}
