using Datalagring_1stTry.Models.Entities;
using System;
namespace Datalagring_1stTry.Models
{
    internal class CustomerModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string StreetName { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string City { get; set; } = null!;
    }
}
