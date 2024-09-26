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
    public class SaveProfileTests
    {
        private readonly Mock<IRepository<Profile>> _profileRepository = new();
     
        private readonly Agdata.Api.Services.SaveProfile _sut;

        public SaveProfileTests()
        {
            _sut = new Api.Services.SaveProfile(_profileRepository.Object);
        }

        [Fact]
        public void Success()
        {
            //Arrange
            DTOs.ProfileDTO profileDTO = new DTOs.ProfileDTO { Name = "John Smith", Address = "1234 Main St" };
            _profileRepository.Setup(m => m.SaveAsync(It.IsAny<Agdata.Domain.Entities.Profile>()));

            //Act
            _sut.Execute(profileDTO);

            //Assert
            _profileRepository.Verify(m => m.SaveAsync(It.Is<Agdata.Domain.Entities.Profile>(i => i.Name.Equals(profileDTO.Name) && i.Address.Equals(profileDTO.Address))), Times.Once());
        }
    }
}
