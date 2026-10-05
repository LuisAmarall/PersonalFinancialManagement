namespace PersonalFinancialManagement.Application.Contracts.Requests.Category;

public sealed record CreateCategoryRequest(string Description, string Observation);