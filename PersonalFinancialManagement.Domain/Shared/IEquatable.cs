using DomainDesign.Shared;

namespace PersonalFinancialManagement.Core.Shared;

public interface IEquatable<T> where T : ValueObject<T> { }