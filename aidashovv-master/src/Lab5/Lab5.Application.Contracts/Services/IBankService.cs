using Lab5.Application.Models.Entities;
using Lab5.Application.Models.ResultTypes;

namespace Lab5.Application.Contracts.Services;

public interface IBankService
{
    BankAccountResult<BankAccount> Create(BankAccount bankAccount);

    BankAccountResult<BankAccount> Withdraw(Guid id, int amount);

    BankAccountResult<BankAccount> TopUp(Guid id, int amount);

    BankAccountResult<BankAccount> ViewBalance(Guid id);
}