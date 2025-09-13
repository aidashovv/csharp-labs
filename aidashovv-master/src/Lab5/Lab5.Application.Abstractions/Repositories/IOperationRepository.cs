using Lab5.Application.Models.Entities;
using Lab5.Application.Models.ResultTypes;

namespace Lab5.Application.Abstractions.Repositories;

public interface IOperationRepository
{
    OperationResult<Operation> Create(Operation operation);

    OperationResult<IReadOnlyCollection<Operation>> GetOperationHistory(Guid ownerId);
}
