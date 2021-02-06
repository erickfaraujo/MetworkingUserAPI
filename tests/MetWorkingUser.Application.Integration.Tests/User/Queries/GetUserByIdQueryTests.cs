using System;
using System.Threading.Tasks;
using FluentAssertions;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Queries;
using NUnit.Framework;

namespace MetWorkingUser.Application.Integration.Tests.User.Queries
{
    using static Testing;
    public class GetUserByIdQueryTests: TestBase
    {
        [Test]
        public async Task ShouldReturnUserById()
        {
            var guid = Guid.NewGuid();
            await AddAsync(new MetWorkingUserDomain.Entities.User
            {
                Email = "ca.ragazzi@gmail.com",
                Id = guid,
                Name = "Caio Eduardo Ragazzi",
                Password = "123456"
            });
            var query = new GetUserByIdQuery(guid);

            UserResponse result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Email.Should().BeOfType(typeof(string));
            result.Email.Should().Be("ca.ragazzi@gmail.com");
            result.Id.Should().Be(guid);
            result.Name.Should().BeOfType(typeof(string));
            result.Name.Should().Be("Caio Eduardo Ragazzi");
        } 
        
    }
}