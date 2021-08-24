using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using todoEmilio.common.Models;
using todoEmilio.Functions.Functions;
using todoEmilio.Test.Helpers;
using Xunit;

namespace todoEmilio.Test.Test
{
    public class TodoApiTest
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async void CreateTodo_Should_Return_200()
        {
            // Arrenge
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            todo todoRequest = TestFactory.GetTodoRequest();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(todoRequest);

            // Act
            IActionResult response = await TodoApi.CreateTodo(request, mockTodos, logger);

            //Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public async void UpdateTodo_Should_Return_200()
        {
            // Arrenge
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            todo todoRequest = TestFactory.GetTodoRequest();
            Guid todoId = Guid.NewGuid();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(todoId, todoRequest);

            // Act
            IActionResult response = await TodoApi.UpdateTodo(request, mockTodos,todoId.ToString(), logger);

            //Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
    }
}
