using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using DTOs = Agdata.Api.DTOs;
using Agdata.Infrastructure.Repositories;
using Agdata.Domain.Entities;

namespace Agdata.Api.Tests.Services
{
    public class GetProfileTests
    {
        private readonly Mock<IRepository<Profile>> _profileRepository = new();
     
        private readonly Agdata.Api.Services.GetProfile _sut;

        public GetProfileTests()
        {
            _sut = new Api.Services.GetProfile(_profileRepository.Object);
        }

        [Fact]
        public void Success()
        {
            //Arrange
            Agdata.Domain.Entities.Profile profile = new Agdata.Domain.Entities.Profile { Name = "John Smith", Address = "1234 Main St" };
            _profileRepository.Setup(m => m.GetAsync())
                .ReturnsAsync(profile);

            //Act
            DTOs.ProfileDTO result = _sut.Execute().Result;

            //Assert
            _profileRepository.Verify();
            Assert.Equal(profile.Name, result.Name);
            Assert.Equal(profile.Address, result.Address);
        }
    }
}
