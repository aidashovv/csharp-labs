using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.MessageModel;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class TestingMessageSystem
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var builder = new MessageBuilder();
        builder.WithHeader("Test Header")
            .WithBody("Test Body")
            .WithImportanceLevel(new ImportanceLevel(1));

        Message message = builder.Build();

        // Act
        var user1 = new User();
        var userRecipient1 = new UserRecipient(user1);
        userRecipient1.ReceiveMessage(message);

        // Assert
        Assert.False(message.ImportanceLevel?.IsRead); // Сообщение должно быть "не прочитано"
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var builder = new MessageBuilder();
        builder.WithHeader("Test Header")
            .WithBody("Test Body")
            .WithImportanceLevel(new ImportanceLevel(1));

        Message message = builder.Build();

        var user1 = new User();
        var userRecipient1 = new UserRecipient(user1);
        userRecipient1.ReceiveMessage(message);

        // Act
        bool result = user1.MarkMessageAsRead();

        // Assert
        Assert.True(result); // Статус изменился
        Assert.True(message.ImportanceLevel?.IsRead); // Теперь сообщение "прочитано"
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var builder = new MessageBuilder();
        builder.WithHeader("Test Header")
            .WithBody("Test Body")
            .WithImportanceLevel(new ImportanceLevel(1));

        Message message = builder.Build();
        var user1 = new User();
        var userRecipient1 = new UserRecipient(user1);
        userRecipient1.ReceiveMessage(message);
        user1.MarkMessageAsRead();

        // Act
        bool result = user1.MarkMessageAsRead();

        // Assert
        Assert.False(result); // Попытка повторного изменения должна быть неуспешной
    }

    [Fact]
    public void Test4()
    {
        // Arrange
        var mockRecipient = new Mock<IRecipient>();
        var proxy = new PriorityFilterProxy(mockRecipient.Object, 3);

        var builder = new MessageBuilder();
        builder.WithHeader("Low Priority")
            .WithBody("Message body")
            .WithImportanceLevel(new ImportanceLevel(2)); // Уровень важности ниже порога
        Message lowPriorityMessage = builder.Build();

        // Act
        proxy.ReceiveMessage(lowPriorityMessage);

        // Assert
        // Проверяем, что сообщение не дошло до реального адресата
        mockRecipient.Verify(r => r.ReceiveMessage(It.IsAny<Message>()), Times.Never);
    }

    [Fact]
    public void Test5()
    {
        // Arrange
        var mockLogger = new Mock<ILogger>();
        var mockRecipient = new Mock<IRecipient>();

        var decorator = new LoggingDecorator(mockRecipient.Object, mockLogger.Object);

        var builder = new MessageBuilder();
        builder.WithHeader("Log Test")
            .WithBody("Body")
            .WithImportanceLevel(new ImportanceLevel(1));

        Message message = builder.Build();

        // Act
        decorator.ReceiveMessage(message);

        // Assert
        // Проверяем, что logging произошло
        mockLogger.Verify(l => l.Log(It.Is<Message>(m => m == message)), Times.Once);

        // Проверяем, что сообщение было передано реципиенту
        mockRecipient.Verify(r => r.ReceiveMessage(It.Is<Message>(m => m == message)), Times.Once);
    }

    [Fact]
    public void Test6()
    {
        // Arrange
        var mockMessenger = new Mock<IRecipient>();
        var builder = new MessageBuilder();
        builder.WithHeader("Messenger Test")
            .WithBody("Body")
            .WithImportanceLevel(new ImportanceLevel(1));

        Message message = builder.Build();

        // Act
        mockMessenger.Object.ReceiveMessage(message);

        // Assert
        mockMessenger.Verify(m => m.ReceiveMessage(It.Is<Message>(message1 => message1 == message)), Times.Once);
    }

    [Fact]
    public void Test7()
    {
        // Arrange
        var mockLogger = new Mock<ILogger>();
        var messenger = new MessengerRecipient(mockLogger.Object);

        var builder = new MessageBuilder();
        builder.WithHeader("Test Header")
            .WithBody("Test Body")
            .WithImportanceLevel(new ImportanceLevel(1));
        Message message = builder.Build();

        // Act
        messenger.ReceiveMessage(message);

        // Assert
        mockLogger.Verify(l => l.Log(It.Is<Message>(m => m.Header == "Messenger" && m.Body == "Test Header\nTest Body" && m.ImportanceLevel != null && m.ImportanceLevel.Level == 1)), Times.Once);
    }
}
