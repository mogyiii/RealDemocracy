using AutoMapper;
using Moq;
using NHibernate;
using Dec.DataAccess.Entities;
using Dec.Logic.Managers;
using Dec.Shared.DTOs;
using Dec.Shared.Interfaces.UnitOfWork;
using Xunit;

namespace Dec.Logic.Test.Managers
{
    public class UserManagerTest
    {
        [Fact]
        public void UserManager_SavesAUserWithEmptyEmail_ThrowsValidationError()
        {
            // Arrange
            var sessionMock = new Mock<ISession>();
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var userManager = new PersonManager(sessionMock.Object, mapperMock.Object, unitOfWorkMock.Object);

            unitOfWorkMock
                .SetupGet(x => x.IsManagedTransaction)
                .Returns(true);

            var userDto = new PersonDTO
            {
                PasswordHash = "",
                Name = "Test User",
                UserName = "Test User",
                NormalizedUserName = "TEST USER"
            };
            var userEntity = new PersonEntity
            {
                PasswordHash = "",
                Name = "Test User",
                UserName = "Test User",
                NormalizedUserName = "TEST USER"
            };

            mapperMock
                .Setup(x => x.Map(It.IsAny<PersonDTO>(), It.IsAny<PersonEntity>()))
                .Returns(userEntity);

            // Act
            var saveResult = userManager.Save(userDto);

            // Assert
            Assert.False(saveResult.Succeeded);
            Assert.True(saveResult.ErrorMessages.Count > 0);
        }

        [Fact]
        public void UserManager_SavesAValidNewUser_UserGetsId()
        {
            // Arrange
            var sessionMock = new Mock<ISession>();
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var userManager = new PersonManager(sessionMock.Object, mapperMock.Object, unitOfWorkMock.Object);

            unitOfWorkMock
                .SetupGet(x => x.IsManagedTransaction)
                .Returns(true);

            var userDto = new PersonDTO
            {
                Email = "test@email.com",
                PasswordHash = "",
                Name = "Test User",
                UserName = "Test User",
                NormalizedUserName = "TEST USER"
            };
            var userEntity = new PersonEntity
            {
                Email = "test@email.com",
                PasswordHash = "",
                Name = "Test User",
                UserName = "Test User",
                NormalizedUserName = "TEST USER"
            };

            var expectedId = 1;

            mapperMock
                .Setup(x => x.Map(It.IsAny<PersonDTO>(), It.IsAny<PersonEntity>()))
                .Returns(userEntity);

            sessionMock
                .Setup(x => x.Save(It.IsAny<PersonEntity>()))
                .Callback((object user) =>
                {
                    ((PersonEntity)user).Id = expectedId;
                });

            // Act
            var saveResult = userManager.Save(userDto);

            // Assert
            Assert.True(saveResult.Succeeded);
            Assert.Equal(saveResult.Id, expectedId);
        }
    }
}
