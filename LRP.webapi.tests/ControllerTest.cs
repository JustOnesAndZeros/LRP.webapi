using LRP.webapi.Domain.Entities;
using LRP.webapi.Domain.Interfaces;
using LRP.webapi.Services;
using LRP.webapi.UI.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;

namespace LRP.webapi.tests;

public class ControllerTest
{
    [Fact]
    public async Task WhenGetById1FirstNameIsBen()
    {
        //arrange
        var mockRepository = new Mock<IRepository<User>>();
        mockRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(new User
        {
            FirstName = "First",
            LastName = "Last",
            Id = 1,
            Active = true
        }));
        var sut = new UserController(mockRepository.Object);

        //act
        User user = await sut.GetById(1);

        //assert
        //Assert.Equal("First", user.FirstName);
    }

}