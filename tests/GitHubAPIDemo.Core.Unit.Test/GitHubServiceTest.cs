using GitHubAPIDemo.Core.Contracts;
using GitHubAPIDemo.Core.Models;
using GitHubAPIDemo.Core.Services;
using Moq;

namespace GitHubAPIDemo.Core.Unit.Test
{
    public class GitHubServiceTest
    {
        public Mock<IGitHubRepository> mockRepository = new Mock<IGitHubRepository>();

        [Fact]
        public async Task Should_Return_UserData_When_Present_in_Github()
        {
            //Arrange
            mockRepository.Setup(p => p.GetUserInfo(It.IsAny<string>())).Returns( Task.FromResult( new GitHubUserInfo() ));
            var service = new GitHubService(mockRepository.Object);


            //Act
            var result = await service.GetUsersInfo(new List<string> { "sindresorhus" });
            //karpathy

            //Assert
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task Should_Not_Return_UserData_When_Not_Present_in_Github()
        {
            //Arrange
            mockRepository.Setup(p => p.GetUserInfo(It.IsAny<string>())).Returns(Task.FromResult<GitHubUserInfo>(null));
            var service = new GitHubService(mockRepository.Object);


            //Act
            var result = await service.GetUsersInfo(new List<string> { "xyz" });

            //Assert
            Assert.Empty(result);
        }
        [Theory]
        [InlineData(new string[]{ "sindresorhus", "karpathy" }, 2)]
        [InlineData(new string[] { "sindresorhus", "karpathy","dipali" }, 3)]
        [InlineData(new string[] { "sindresorhus", "karpathy", "xyz" }, 2)]
        public async Task Should_Return_UsersData_When_Present_in_Github(string[] userNames, int expectedCount)
        {
            //Arrange
            mockRepository.Setup(p => p.GetUserInfo(It.IsAny<string>())).Returns<string>( (userName) => { 
                if (string.Equals(userName, "xyz"))
                    return Task.FromResult<GitHubUserInfo>(null);

                    return Task.FromResult(new GitHubUserInfo());
                    
                    });
            var service = new GitHubService(mockRepository.Object);



            //Act
            var result = await service.GetUsersInfo(userNames.ToList());
            //karpathy

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedCount, result.Count());
        }

        [Theory]
        [InlineData(new string[] { "sindresorhus", "karpathy" }, 2, "karpathy")]
        [InlineData(new string[] { "sindresorhus", "karpathy", "dipali" }, 3, "dipali")]
        public async Task Should_Return_UsersData_When_Present_in_Github_SortedBy_Name(string[] userNames, int expectedCount, string firstUserName)
        {
            //Arrange
            mockRepository.Setup(p => p.GetUserInfo(It.IsAny<string>())).Returns<string>((userName) => {
          
                return Task.FromResult(new GitHubUserInfo() { 
                    Name= userName,
                });

            });
            var service = new GitHubService(mockRepository.Object);



            //Act
            var result = await service.GetUsersInfo(userNames.ToList());
            //karpathy

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedCount, result.Count());
            var firstUser = result.FirstOrDefault().Name;
            Assert.Equal(firstUserName, firstUser);

        }

        [Theory]
        [InlineData(new string[] { "karpathy", "karpathy" }, 1)]
        [InlineData(new string[] { "sindresorhus", "sindresorhus", "dipali" }, 2)]
        public async Task Should_Return_Matching_User_Once_When_Duplicate_UserName_Provided_And_Present_in_Github_(string[] userNames, int expectedCount)
        {
            //Arrange
            mockRepository.Setup(p => p.GetUserInfo(It.IsAny<string>())).Returns<string>((userName) => {

                return Task.FromResult(new GitHubUserInfo()
                {
                    Name = userName,
                });

            });
            var service = new GitHubService(mockRepository.Object);



            //Act
            var result = await service.GetUsersInfo(userNames.ToList());
            //karpathy

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expectedCount, result.Count());
           
        }
    }
}