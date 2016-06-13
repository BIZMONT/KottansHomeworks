using System;

namespace Citizens
{
    public interface ICitizen : ICloneable
    {
        string FirstName { get; }

        string LastName { get; }

        Gender Gender { get; }

        DateTime BirthDate { get; }

        string VatId { get; set; }
    }
}