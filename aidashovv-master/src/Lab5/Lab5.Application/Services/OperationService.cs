using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Services;
using Lab5.Application.Models.Entities;
using Lab5.Application.Models.ResultTypes;

namespace Lab5.Application.Services;

public class OperationService : IOperationService
{
    private readonly IOperationRepository _operationRepository;

    public OperationService(IOperationRepository operationRepository)
    {
        _operationRepository = operationRepository;
    }

    public OperationResult<Operation> Create(Operation operation)
    {
        return _operationRepository.Create(operation);
    }

    public OperationResult<IReadOnlyCollection<Operation>> GetOperationHistory(Guid ownerId)
    {
        return _operationRepository.GetOperationHistory(ownerId);
    }
}