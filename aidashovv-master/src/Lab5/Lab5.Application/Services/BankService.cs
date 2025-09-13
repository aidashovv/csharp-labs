using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Services;
using Lab5.Application.Models.Entities;
using Lab5.Application.Models.ResultTypes;

namespace Lab5.Application.Services;

public class BankService : IBankService
{
    private readonly IBankRepository _bankRepository;
    private readonly IOperationRepository _operationRepository;

    public BankService(IBankRepository bankRepository, IOperationRepository operationRepository)
    {
        _bankRepository = bankRepository;
        _operationRepository = operationRepository;
    }

    public BankAccountResult<BankAccount> Create(BankAccount bankAccount)
    {
        return _bankRepository.Create(bankAccount);
    }

    public BankAccountResult<BankAccount> Withdraw(Guid id, int amount)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Неверный идентификатор счета.", nameof(id));

        if (amount <= 0)
            return new BankAccountResult<BankAccount>.FailureWithAmount("Сумма пополнения должна быть больше 0.");

        if (amount is < 100 and > 0)
            return new BankAccountResult<BankAccount>.FailureWithAmount("Сумма пополнения должна быть не менее 100.");

        BankAccountResult<BankAccount> result = _bankRepository.GetById(id);

        if (result is not BankAccountResult<BankAccount>.SuccessValue foundAccount)
            throw new InvalidOperationException("Счет не найден.");

        BankAccount account = foundAccount.Value;
        int updatedBalance = account.Balance - amount;

        if (updatedBalance < 0)
            throw new InvalidOperationException("Недостаточно средств на счете.");

        account.ChangeBalance(updatedBalance);

        var operation = new Operation(Guid.NewGuid(), id, "Снятие", amount);
        _operationRepository.Create(operation);

        return _bankRepository.Update(account);
    }

    public BankAccountResult<BankAccount> TopUp(Guid id, int amount)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Неверный идентификатор счета.", nameof(id));

        if (amount <= 0)
            return new BankAccountResult<BankAccount>.FailureWithAmount("Сумма пополнения должна быть больше 0.");

        if (amount is < 100 and > 0)
            return new BankAccountResult<BankAccount>.FailureWithAmount("Сумма пополнения должна быть не менее 100.");

        BankAccountResult<BankAccount> result = _bankRepository.GetById(id);

        if (result is not BankAccountResult<BankAccount>.SuccessValue foundAccount)
            throw new InvalidOperationException("Счет не найден.");

        BankAccount account = foundAccount.Value;
        int updatedBalance = account.Balance + amount;

        account.ChangeBalance(updatedBalance);

        var operation = new Operation(Guid.NewGuid(), id, "Пополнение", amount);
        _operationRepository.Create(operation);

        return _bankRepository.Update(account);
    }

    public BankAccountResult<BankAccount> ViewBalance(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Некорректный идентификатор счета.", nameof(id));

        return _bankRepository.GetById(id);
    }
}