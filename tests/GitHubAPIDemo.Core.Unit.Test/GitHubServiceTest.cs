namespace GitHubAPIDemo.Core.Unit.Test
{
    public class GitHubServiceTest
    {
        [Fact]
        public void Should_Return_UserData_When_Present_in_Github()
        {
            //Arrange
            var service = new GitHubService();


            //Act
            var result = service.GetUserData("sindresorhus");

            //Assert
            Assert.NotNull(result);
        }
    }
}