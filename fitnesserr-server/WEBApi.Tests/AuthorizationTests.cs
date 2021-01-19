using System;
using System.Collections.Generic;
using System.Text;

namespace WEBApi.Tests
{
    public class AuthorizationTests
    {
        private readonly RegistrationCommandValidator _systemUnderTesting;
        private readonly Mock<IUserReadRepo> _repoMock = new Mock<IUserReadRepo>();
        public RegistrationValidatorTests()
        {
            _systemUnderTesting = new(_repoMock.Object);
        }
        [Theory]
        [InlineData("Email", "username", "password123")]
        [InlineData("Email@gmail.com", "u", "password123")]
        [InlineData("Email@gmail.com", "username", "pass")]
        public async Task ValidateAsync_ShouldFail_BadInput(string email, string nickname, string password)
        {
            //arrange
            UserRegistrationModel model = new()
            {
                Email = email,
                Nickname = nickname,
                Password = password
            };
            //user is assumed not to present in the db
            _repoMock.Setup(x => x.CheckIsEmailPresent(email, CancellationToken.None)).ReturnsAsync(false);
            var command = new RegistrationCommand(model);
            //act
            ValidationResult result = await _systemUnderTesting.ValidateAsync(command, CancellationToken.None);

            //assert
            Assert.False(result.IsValid);
        }
        [Theory]
        [InlineData("Email@gmail.com", "username", "password123")]
        [InlineData("theruslan.prog@gmail.com", "RuslanPr0g", "Tasman2020")]
        public async Task ValidateAsync_ShouldFail_NotAvailableEmail(string email, string nickname, string password)
        {
            //arrange
            UserRegistrationModel model = new()
            {
                Email = email,
                Nickname = nickname,
                Password = password
            };
            var command = new RegistrationCommand(model);
            //user is assumed to be present in the db
            _repoMock.Setup(x => x.CheckIsEmailPresent(email, CancellationToken.None)).ReturnsAsync(true);

            //act
            ValidationResult result = await _systemUnderTesting.ValidateAsync(command, CancellationToken.None);

            //assert
            Assert.False(result.IsValid);
        }
        [Theory]
        [InlineData("Email@gmail.com", "username", "password123")]
        [InlineData("theruslan.prog@gmail.com", "RuslanPr0g", "Tasman2020")]
        public async Task ValidateAsync_ShouldWork_ValidData(string email, string nickname, string password)
        {
            //arrange
            UserRegistrationModel model = new()
            {
                Email = email,
                Nickname = nickname,
                Password = password
            };
            var command = new RegistrationCommand(model);
            //user is assumed not to present in the db
            _repoMock.Setup(x => x.CheckIsEmailPresent(email, CancellationToken.None)).ReturnsAsync(false);

            //act
            ValidationResult result = await _systemUnderTesting.ValidateAsync(command, CancellationToken.None);

            //assert
            Assert.True(result.IsValid);
        }
    }
}
