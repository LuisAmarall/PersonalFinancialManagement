using System;
using System.Linq;
using System.Collections.Generic;

namespace PersonalFinancialManagement.Core.Models.Shared;

public abstract class ValueObject<Type> : IEquatable<Type> where Type : ValueObject<Type>
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object objects) => objects is Type other && Equals(other);

    public bool Equals(Type other)
    {
        if (other is null) return false;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var obj in GetEqualityComponents())
            hash.Add(obj);

        return hash.ToHashCode();
    }

    public static bool operator ==(ValueObject<Type> left, ValueObject<Type> right)
    => left?.Equals(right) ?? right is null;

    public static bool operator !=(ValueObject<Type> left, ValueObject<Type> right)
        => !(left == right);
}