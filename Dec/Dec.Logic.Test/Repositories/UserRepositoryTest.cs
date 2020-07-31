using Moq;
using Dec.Logic.Interfaces.Repositories;
using Dec.Shared.DTOs;
using Xunit;

namespace Dec.Logic.Test.Repositories
{
    public class UserRepositoryTest
    {
        [Fact]
        public void UserRepository_GetsUserWithExistingId_GetsAnExistingUser()
        {
            var userRepository = new Mock<IPersonRepository>();

            // Arrange
            var userDto = new PersonDTO
            {
                Email = "test@email.com",
                PasswordHash = "",
                Name = "Test User",
                UserName = "Test User",
                NormalizedUserName = "TEST USER",
                Id = 1
            };

            userRepository
                .Setup(x => x.Get(It.Is<int>(i => i == 1)))
                .Returns(userDto);

            userRepository
                .Setup(x => x.Get(It.Is<int>(i => i != 1)))
                .Returns((PersonDTO)null);

            // Act
            var actualUser = userRepository.Object.Get(1);


            // Assert
            Assert.NotNull(actualUser);
            Assert.Equal(actualUser.Id, userDto.Id);
        }
        [Fact]
        public void UserRepository_GetsUserWithExistingId_GetsAnNotExistingUser()
        {
            var userRepository = new Mock<IPersonRepository>();

            // Arrange
            var userDto = new PersonDTO
            {
                Email = "test@email.com",
                PasswordHash = "",
                Name = "Test User",
                UserName = "Test User",
                NormalizedUserName = "TEST USER",
                Id = 1
            };

            userRepository
                .Setup(x => x.Get(It.Is<int>(i => i == 1)))
                .Returns(userDto);

            userRepository
                .Setup(x => x.Get(It.Is<int>(i => i != 1)))
                .Returns((PersonDTO)null);

            // Act

            var nullUser = userRepository.Object.Get(2);

            // Assert
            Assert.Null(nullUser);
        }
    }
}
