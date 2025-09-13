using Lab5.Application.Models.Entities;
using Lab5.Application.Models.ResultTypes;

namespace Lab5.Application.Contracts.Services;

public interface IOperationService
{
    OperationResult<Operation> Create(Operation operation);

    OperationResult<IReadOnlyCollection<Operation>> GetOperationHistory(Guid ownerId);
}