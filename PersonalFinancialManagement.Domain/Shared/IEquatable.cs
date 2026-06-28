using DomainDesign.Shared;

namespace PersonalFinancialManagement.Core.Models.Shared;

public interface IEquatable<T> where T : ValueObject<T> { }