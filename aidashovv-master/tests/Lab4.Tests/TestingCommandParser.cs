using Itmo.ObjectOrientedProgramming.Lab4.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Xunit;

namespace Lab4.Tests;

public class TestingCommandParser
{
        [Fact]
        public void Test1()
        {
            // Arrange
            var fileSystem = new FileSystem();
            var context = new FileSystemContext(fileSystem, "/Users");
            var parser = new ProgramFile(context);
            const string input = "connect /Users/amirka -m local";

            // Act
            ICommand? command = parser.ParseCommand(input);

            // Assert
            Assert.NotNull(command);
            Assert.IsType<ConnectionCommand>(command);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var fileSystem = new FileSystem();
            var context = new FileSystemContext(fileSystem, "/Users");
            var parser = new ProgramFile(context);
            const string input = "disconnect";

            // Act
            ICommand? command = parser.ParseCommand(input);

            // Assert
            Assert.NotNull(command);
            Assert.IsType<DisconnectionCommand>(command);
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            var fileSystem = new FileSystem();
            var context = new FileSystemContext(fileSystem, "/Users");
            var parser = new ProgramFile(context);
            const string input = "tree goto /Users/amirka/Desktop";

            // Act
            ICommand? command = parser.ParseCommand(input);

            // Assert
            Assert.NotNull(command);
            Assert.IsType<TreeGotoCommand>(command);
        }

        [Fact]
        public void Test4()
        {
            // Arrange
            var fileSystem = new FileSystem();
            var context = new FileSystemContext(fileSystem, "/Users/amirka");
            var parser = new ProgramFile(context);
            const string input = "tree list -d 3";

            // Act
            ICommand? command = parser.ParseCommand(input);

            // Assert
            Assert.NotNull(command);
            Assert.IsType<TreeListCommand>(command);
        }

        [Fact]
        public void Test5()
        {
            // Arrange
            var fileSystem = new FileSystem();
            var context = new FileSystemContext(fileSystem, "/Users");
            var parser = new ProgramFile(context);
            const string input = "file show /Users/amirka/file.txt -m console";

            // Act
            ICommand? command = parser.ParseCommand(input);

            // Assert
            Assert.NotNull(command);
            Assert.IsType<FileShowCommand>(command);
        }

        [Fact]
        public void Test6()
        {
            // Arrange
            var fileSystem = new FileSystem();
            var context = new FileSystemContext(fileSystem, "/Users");
            var parser = new ProgramFile(context);
            const string input = "file move /Users/amirka/file.txt /Users/amirka/Desktop/";

            // Act
            ICommand? command = parser.ParseCommand(input);

            // Assert
            Assert.NotNull(command);
            Assert.IsType<FileMoveCommand>(command);
        }

        [Fact]
        public void Test7()
        {
            // Arrange
            var fileSystem = new FileSystem();
            var context = new FileSystemContext(fileSystem, "/Users");
            var parser = new ProgramFile(context);
            const string input = "file copy /Users/amirka/file.txt /Users/amirka/Desktop/";

            // Act
            ICommand? command = parser.ParseCommand(input);

            // Assert
            Assert.NotNull(command);
            Assert.IsType<FileCopyCommand>(command);
        }

        [Fact]
        public void Test8()
        {
            // Arrange
            var fileSystem = new FileSystem();
            var context = new FileSystemContext(fileSystem, "/Users");
            var parser = new ProgramFile(context);
            const string input = "file delete /Users/amirka/file.txt";

            // Act
            ICommand? command = parser.ParseCommand(input);

            // Assert
            Assert.NotNull(command);
            Assert.IsType<FileDeleteCommand>(command);
        }

        [Fact]
        public void Test9()
        {
            // Arrange
            var fileSystem = new FileSystem();
            var context = new FileSystemContext(fileSystem, "/Users");
            var parser = new ProgramFile(context);
            const string input = "file rename /Users/amirka/file.txt new-file.txt";

            // Act
            ICommand? command = parser.ParseCommand(input);

            // Assert
            Assert.NotNull(command);
            Assert.IsType<FileRenameCommand>(command);
        }

        [Fact]
        public void Test10()
        {
            // Arrange
            var fileSystem = new FileSystem();
            var context = new FileSystemContext(fileSystem, "/Users");
            var parser = new ProgramFile(context);
            const string input = "invalid-command";

            // Act
            ICommand? command = parser.ParseCommand(input);

            // Assert
            Assert.Null(command);
        }

        [Fact]
        public void Test11()
        {
            // Arrange
            var fileSystem = new FileSystem();
            var context = new FileSystemContext(fileSystem, "/Users");
            var parser = new ProgramFile(context);
            const string input = "";

            // Act
            ICommand? command = parser.ParseCommand(input);

            // Assert
            Assert.Null(command);
        }
}