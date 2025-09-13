using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Entities;
using Lab5.Application.Models.ResultTypes;
using Lab5.Application.Services;
using Moq;
using Xunit;

namespace Lab5.Tests;

public class TestingBbl
{
    [Fact]
    public void FailureWithdrawTest_WhenNotEnoughBalance()
    {
        // Создаём Moq-объект репозитория
        var bankRepositoryMock = new Mock<IBankRepository>();
        var operationRepositoryMock = new Mock<IOperationRepository>();

        var bankService = new BankService(bankRepositoryMock.Object, operationRepositoryMock.Object);

        var account = new BankAccount(Guid.NewGuid(), Guid.NewGuid(), "1234", 500);

        // Настраиваем метод GetById, чтобы он возвращал аккаунт
        bankRepositoryMock
            .Setup(repo => repo.GetById(account.Id))
            .Returns(new BankAccountResult<BankAccount>.SuccessValue(account));

        // Проверяем, что при недостатке средств выбрасывается исключение
        Assert.Throws<InvalidOperationException>(() => bankService.Withdraw(account.Id, 1000));
    }

    [Fact]
    public void SuccessfulWithdrawTest()
    {
        var bankRepositoryMock = new Mock<IBankRepository>();
        var operationRepositoryMock = new Mock<IOperationRepository>();

        var bankService = new BankService(bankRepositoryMock.Object, operationRepositoryMock.Object);

        var account = new BankAccount(Guid.NewGuid(), Guid.NewGuid(), "1234", 5000);

        bankRepositoryMock
            .Setup(repo => repo.GetById(account.Id))
            .Returns(new BankAccountResult<BankAccount>.SuccessValue(account));

        // Настроим Update() в Moq, чтобы он не возвращал null
        bankRepositoryMock
            .Setup(repo => repo.Update(It.IsAny<BankAccount>()))
            .Returns<BankAccount>(acc => new BankAccountResult<BankAccount>.SuccessValue(acc));

        // Выполняем снятие 1000
        BankAccountResult<BankAccount> result = bankService.Withdraw(account.Id, 1000);

        // Проверяем, что возвращённый результат — SuccessValue
        Assert.IsType<BankAccountResult<BankAccount>.SuccessValue>(result);

        // Достаём обновлённый счёт
        BankAccount updatedAccount = ((BankAccountResult<BankAccount>.SuccessValue)result).Value;

        // Проверяем, что баланс уменьшился на 1000
        Assert.Equal(4000, updatedAccount.Balance);
    }

    [Fact]
    public void SuccessfulTopUpTest()
    {
        var bankRepositoryMock = new Mock<IBankRepository>();
        var operationRepositoryMock = new Mock<IOperationRepository>();

        var bankService = new BankService(bankRepositoryMock.Object, operationRepositoryMock.Object);

        var account = new BankAccount(Guid.NewGuid(), Guid.NewGuid(), "1234", 3000);

        bankRepositoryMock
            .Setup(repo => repo.GetById(account.Id))
            .Returns(new BankAccountResult<BankAccount>.SuccessValue(account));

        bankRepositoryMock
            .Setup(repo => repo.Update(It.IsAny<BankAccount>()))
            .Returns<BankAccount>(acc => new BankAccountResult<BankAccount>.SuccessValue(acc));

        // Выполняем пополнение на 1500
        BankAccountResult<BankAccount> result = bankService.TopUp(account.Id, 1500);

        // Проверяем, что возвращённый результат — SuccessValue
        Assert.IsType<BankAccountResult<BankAccount>.SuccessValue>(result);

        // Достаём обновлённый счёт
        BankAccount updatedAccount = ((BankAccountResult<BankAccount>.SuccessValue)result).Value;

        // Проверяем, что баланс увеличился на 1500
        Assert.Equal(4500, updatedAccount.Balance);
    }
}