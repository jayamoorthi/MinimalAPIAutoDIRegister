using Domain.BaseDomain.DomainModels;
using Domain.Interfaces;
using Domain.Services;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MinimalAPI.UnitTest.Domain
{
    //public class UserServiceTest
    //{
    //    private readonly IUserRepository _userRepositoryFake;

    //    private readonly UserService _userService;
    //    public UserServiceTest()
    //    {
    //        _userRepositoryFake = A.Fake<IUserRepository>();
    //        _userService = new UserService(_userRepositoryFake);
    //    }

    //    [Fact]
    //    public async Task GetAllAsync_Positive_WhenUserRecordHasExists_ShouldReturnAllUsersList()
    //    {
    //        //Arranage

    //        var users = new List<LoginUser>
    //         {
    //             new LoginUser {  Email = "moorthi@gmail.com", FirstName ="Jayam", LastName = "Moorthi", Id = new Guid(), IsSoftDeleted = false },
    //             new LoginUser {  Email = "moorthi1@gmail.com", FirstName ="Jayam", LastName = "Moorthi", Id = new Guid(), IsSoftDeleted = false }
    //         };

    //        A.CallTo(() => _userRepositoryFake.GetAllAsync()).Returns(users);

    //        // Act

    //        var res = await _userService.GetAllAsync();

    //        // Assert 

    //        Assert.IsType<List<LoginUser>>(res);
    //        Assert.Equal(2, users.Count);

    //    }
    //}
}
