using Infrastructure.Database.Entities;
using Infrastructure.Database.Migrations;
using Infrastructure.Database.Repositories;
using Lab5.Application.Models.Entities;
using Lab5.Application.Models.ResultTypes;
using Lab5.Application.Services;
using Presentation.Console.Extensions;
using Spectre.Console;

namespace Presentation.Console.Consoles;

public class Program
{
    public static void Main(string[] args)
    {
        var databaseConnection = new DatabaseConnection($"Host=localhost;" +
                                                        $"Port=5432;" +
                                                        $"Database=postgres;" +
                                                        $"Username=postgres;" +
                                                        $"Password=3003");
        Initial.Initialize(databaseConnection);

        var bankRepository = new BankRepository(databaseConnection);
        var operationRepository = new OperationRepository(databaseConnection);
        var userRepository = new UserRepository(databaseConnection);

        var bankService = new BankService(bankRepository, operationRepository);
        var operationService = new OperationService(operationRepository);
        var userService = new UserService(userRepository);

        while (true)
        {
            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[blue]Выберите роль пользователя:[/]")
                    .AddChoices(["User", "Admin", "Выход"]));

            switch (choice)
            {
                case "User":
                    UserMenu(userService, bankService, operationService);
                    break;

                case "Admin":
                    AdminMenu(userService);
                    break;

                case "Выход":
                    return;
            }
        }
    }

    private static void UserMenu(UserService userService, BankService bankService, OperationService operationService)
    {
        AnsiConsole.MarkupLine("[green]--- Вход в систему пользователя ---[/]");

        string choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[blue]Выберите действие:[/]")
                .AddChoices(["Создать аккаунт", "Войти в существующий", "Выход"]));

        switch (choice)
        {
            case "Создать аккаунт":
                User? newUser = RegisterUser(userService);
                if (newUser != null)
                {
                    LoginUser(userService, bankService, operationService);
                }

                break;

            case "Войти в существующий":
                LoginUser(userService, bankService, operationService);
                break;

            case "Выход":
                return;
        }
    }

    private static void AdminMenu(UserService userService)
    {
        string password = AnsiConsole.Prompt(
            new TextPrompt<string>("Введите [green]администраторский пароль[/]:")
                .Secret());

        if (password != AdminInfo.SystemPassword)
        {
            AnsiConsole.MarkupLine("[red]Неверный пароль! Программа завершает работу.[/]");
            Environment.Exit(0);
        }

        while (true)
        {
            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Админ меню. Выберите действие:[/]")
                    .AddChoices(["Просмотр пользователей", "Выход"]));

            switch (choice)
            {
                case "Просмотр пользователей":
                    ViewAllUsers(userService);
                    break;

                case "Выход":
                    return;
            }
        }
    }

    private static User? RegisterUser(UserService userService)
    {
        AnsiConsole.MarkupLine("[green]--- Регистрация нового пользователя ---[/]");

        string userName = AnsiConsole.Prompt(
            new TextPrompt<string>("Введите [blue]Имя пользователя[/]:")
                .Validate(name => !string.IsNullOrWhiteSpace(name)
                    ? ValidationResult.Success()
                    : ValidationResult.Error("[red]Имя не может быть пустым![/]")));

        var newUser = new User(Guid.NewGuid(), userName);
        UserResult<User> result = userService.Create(newUser);

        if (result is UserResult<User>.SuccessValue success)
        {
            AnsiConsole.MarkupLine($"[green]Пользователь успешно создан! Ваш ID: {success.Value.Id}[/]");
            return success.Value;
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Ошибка при создании пользователя.[/]");
            return null;
        }
    }

    private static void LoginUser(UserService userService, BankService bankService, OperationService operationService)
    {
        AnsiConsole.MarkupLine("[green]--- Вход в систему пользователя ---[/]");

        string userId = AnsiConsole.Prompt(
            new TextPrompt<string>("Введите [blue]User ID[/]:")
                .Validate(id => Guid.TryParse(id, out _)
                    ? ValidationResult.Success()
                    : ValidationResult.Error("[red]Некорректный ID![/]")));

        UserResult<User> userResult = userService.GetById(Guid.Parse(userId));

        if (userResult is not UserResult<User>.SuccessValue userSuccess)
        {
            AnsiConsole.MarkupLine("[red]Ошибка аутентификации! Пользователь не найден.[/]");
            return;
        }

        User user = userSuccess.Value;

        AnsiConsole.MarkupLine($"[green]Добро пожаловать, {user.Name}![/]");

        // Переходим к операциям пользователя
        RunUserOperations(user, bankService, operationService);
    }

    private static void RunUserOperations(User user, BankService bankService, OperationService operationService)
    {
        while (true)
        {
            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[green]Выберите действие:[/]")
                    .AddChoices(["Создать счет", "Просмотр баланса", "Пополнить счет", "Снять деньги", "История операций", "Выход"]));

            switch (choice)
            {
                case "Создать счет":
                    CreateBankAccount(bankService, user.Id);
                    break;

                case "Просмотр баланса":
                    ViewBalance(bankService);
                    break;

                case "Пополнить счет":
                    TopUp(bankService);
                    break;

                case "Снять деньги":
                    Withdraw(bankService);
                    break;

                case "История операций":
                    ViewOperations(operationService);
                    break;

                case "Выход":
                    return;
            }
        }
    }

    private static void CreateBankAccount(BankService bankService, Guid ownerId)
    {
        string pin = AnsiConsole.Prompt(
            new TextPrompt<string>("Введите [green]PIN-код[/] для нового счета:"));

        var newAccount = new BankAccount(Guid.NewGuid(), ownerId, pin, 0);
        BankAccountResult<BankAccount> result = bankService.Create(newAccount);

        if (result is BankAccountResult<BankAccount>.SuccessValue success)
        {
            AnsiConsole.MarkupLine($"[green]Счет успешно создан! ID: {success.Value.Id}[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Ошибка создания счета.[/]");
        }
    }

    private static void ViewBalance(BankService bankService)
    {
        Guid accountId = GetValidAccountId();

        if (accountId == Guid.Empty)
        {
            return;
        }

        BankAccountResult<BankAccount> result = bankService.ViewBalance(accountId);

        if (result is BankAccountResult<BankAccount>.SuccessValue success)
        {
            AnsiConsole.MarkupLine($"[green]Текущий баланс: {success.Value.Balance}[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Ошибка! Счет не найден.[/]");
        }
    }

    private static void TopUp(BankService bankService)
    {
        Guid accountId = GetValidAccountId();

        if (accountId == Guid.Empty)
        {
            return;
        }

        double amount = AnsiConsole.Prompt(
            new TextPrompt<double>("Введите сумму пополнения:"));

        BankAccountResult<BankAccount> result = bankService.TopUp(accountId, (int)amount);

        if (result is BankAccountResult<BankAccount>.SuccessValue success)
        {
            AnsiConsole.MarkupLine($"[green]Баланс пополнен! Новый баланс: {success.Value.Balance}[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Ошибка пополнения.[/]");
        }
    }

    private static void Withdraw(BankService bankService)
    {
        Guid accountId = GetValidAccountId();

        if (accountId == Guid.Empty)
        {
            return;
        }

        double amount = AnsiConsole.Prompt(
            new TextPrompt<double>("Введите сумму снятия:"));

        BankAccountResult<BankAccount> result = bankService.Withdraw(accountId, (int)amount);

        if (result is BankAccountResult<BankAccount>.SuccessValue success)
        {
            AnsiConsole.MarkupLine($"[green]Снятие успешно! Новый баланс: {success.Value.Balance}[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Ошибка снятия средств.[/]");
        }
    }

    private static void ViewOperations(OperationService operationService)
    {
        string accountId = AnsiConsole.Prompt(
            new TextPrompt<string>("Введите [blue]ID счета[/]:")
                .Validate(id => Guid.TryParse(id, out _)
                    ? ValidationResult.Success()
                    : ValidationResult.Error("[red]Некорректный ID счета![/]")));

        OperationResult<IReadOnlyCollection<Operation>> result = operationService.GetOperationHistory(Guid.Parse(accountId));

        if (result is OperationResult<IReadOnlyCollection<Operation>>.SuccessValue success)
        {
            AnsiConsole.MarkupLine("[green]История операций:[/]");
            foreach (Operation operation in success.Value)
            {
                AnsiConsole.MarkupLine($"ID операции: {operation.Id} | Тип операции: {operation.Name} | Сумма: {operation.Amount}");
            }
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Ошибка получения истории операций.[/]");
        }
    }

    private static void ViewAllUsers(UserService userService)
    {
        UserResult<IReadOnlyList<User>> result = userService.GetAllUsers();

        if (result is UserResult<IReadOnlyList<User>>.SuccessValue success)
        {
            AnsiConsole.MarkupLine("[green]Список пользователей:[/]");
            foreach (User user in success.Value)
            {
                AnsiConsole.MarkupLine($"ID: {user.Id} | Имя: {user.Name}");
            }
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Ошибка получения пользователей.[/]");
        }
    }

    private static Guid GetValidAccountId()
    {
        while (true)
        {
            string accountIdInput = AnsiConsole.Prompt(
                new TextPrompt<string>("Введите [blue]ID счета[/]:")
                    .Validate(id => Guid.TryParse(id, out _)
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[red]Некорректный формат ID! Пожалуйста, введите правильный ID.[/]")));

            if (Guid.TryParse(accountIdInput, out Guid accountId))
            {
                return accountId;
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Ошибка! Введен некорректный ID. Хотите вернуться в главное меню?[/]");

                string choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]Выберите действие:[/]")
                        .AddChoices("Да", "Нет"));

                if (choice == "Да")
                {
                    return Guid.Empty;
                }
                else
                {
                    AnsiConsole.MarkupLine("[yellow]Попробуйте снова.[/]");
                }
            }
        }
    }
}