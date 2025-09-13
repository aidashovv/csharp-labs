using Lab5.Application.Models.Entities;
using Lab5.Application.Models.ResultTypes;

namespace Lab5.Application.Abstractions.Repositories;

public interface IBankRepository
{
    BankAccountResult<BankAccount> Create(BankAccount bankAccount);

    BankAccountResult<BankAccount> GetById(Guid id);

    BankAccountResult<BankAccount> Update(BankAccount bankAccount);
}