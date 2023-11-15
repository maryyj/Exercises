using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Moq;
using ToDoList.Interfaces;

namespace ToDoList.Tests
{
    public class ToDoListTests
    {
        [Fact]
        public void CanAddTask()
        {
            //Arrange
            var title = "Title";
            var description = "Description";


            var mockTodoListStorage = new Mock<ITodoListStorage>();

            var sut = new TodoList(mockTodoListStorage.Object);

            //Act
            var actual = sut.Add(title, description);

            //Assert
            Assert.NotEqual(Guid.Empty, actual.Id);
            Assert.Equal(title, actual.Title);
            Assert.Equal(description, actual.Description);
            Assert.False(actual.IsCompleted);
        }

        [Fact]
        public void AddedTaskSaveInStorage()
        {
            //Arrange
            var title = "Title";
            var description = "Description";

            var mockTodoListStorage = new Mock<ITodoListStorage>();

            var sut = new TodoList(mockTodoListStorage.Object);

            //Act
            var actual = sut.Add(title, description);

            //Assert
            mockTodoListStorage.Verify(x => x.Save(actual), Times.Once());
        }

        //[Fact]
        //public void CanViewAllTodos()
        //{
        //    //Arrange
        //    var mockTodoListStorage = new Mock<ITodoListStorage>();
        //    ;

        //    mockTodoListStorage.Setup(x => x.Load())
        //        .Returns(new List<TodoItem>()
        //    {
        //        new TodoItem()
        //        {
        //            Title = "Title1",
        //            Description = "Description1",
        //        },
        //        new TodoItem()
        //        {
        //            Title= "Title2",
        //            Description= "Description2",
        //        }
        //    });

        //    var sut = new TodoList(mockTodoListStorage.Object);

        //    //act
        //    var actual = sut.View();

        //    //Assert
        //    mockTodoListStorage.Verify(x => x.Load(), Times.Once);
        //    Assert.True(actual);
        //}

        [Fact]
        public void CanMarkTaskAsCompleted()
        {
            //Arrange
            var mockTodoListStorage = new Mock<ITodoListStorage>();
            var sut = new TodoList(mockTodoListStorage.Object);
            var task = new TodoItem()
            {   
                Id = Guid.NewGuid(),           
                Title = "Title1",
                Description = "Description1",
                IsCompleted = false
            };
            sut.TodoItems.Add(task);

            //Act
            var actual = sut.MarkAsComplete(task.Id);

            //Assert
            Assert.True(actual.IsCompleted);
        }
        [Fact]
        public void CanMarkTaskAsNotCompleted() 
        {
            //Arrange
            var mockTodoListStorage = new Mock<ITodoListStorage>();
            var sut = new TodoList(mockTodoListStorage.Object);

            var task = new TodoItem()
            {
                Id = Guid.NewGuid(),
                Title = "Title1",
                Description = "Description1",
                IsCompleted = true
            };
            sut.TodoItems.Add(task);

            //Act
            var actual = sut.MarkAsNotComplete(task.Id);

            //Assert
            Assert.False(actual.IsCompleted);
        }

        [Fact]
        public void CanDeleteTask()
        {
            //Arrange
            var mockTodoListStorage = new Mock<ITodoListStorage>();

            var sut = new TodoList(mockTodoListStorage.Object);
            var task = new TodoItem()
            {
                Id = Guid.NewGuid(),
                Title = "Title1",
                Description = "Description1",
                IsCompleted = true
            };

            sut.TodoItems.Add(task);
            //Act
            var actual = sut.Delete(task.Id);

            //Assert

            Assert.True(actual);
        }
    }
}