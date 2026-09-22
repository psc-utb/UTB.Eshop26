using System;
using System.Collections.Generic;
using System.Text;
using UTB.Eshop.Domain.Entities.Interfaces;

namespace UTB.Eshop.Application.Records
{
    internal record UserRecord<TKey> : IUser<TKey> where TKey : notnull
    {
        public TKey Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
