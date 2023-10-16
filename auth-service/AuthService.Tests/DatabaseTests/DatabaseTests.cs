using AuthService.Repositories.Codes;
using AuthService.Services.Codes;
using Moq;
using Xunit;

namespace AuthService.Tests.DatabaseTests;

public class DatabaseTests
{
    [Theory]
    [InlineData("+79282334657")]
    [InlineData("89212334157")]
    [InlineData("example@mail.ru")]
    [InlineData("example@bk.ru")]
    [InlineData("example@index.ru")]
    [InlineData("example@inbox.ru")]
    public async void CreateCodeTest(string credential)
    {
        var codeRepositoryMock = new Mock<ICodeRepository>();
        await AddCredentials(codeRepositoryMock, credential);
        codeRepositoryMock.Verify(repo => repo.CreateAsync(credential, CancellationToken.None), Times.Once);
    }

    [Theory]
    [InlineData("+79282334657")]
    [InlineData("89212334157")]
    [InlineData("example@mail.ru")]
    [InlineData("example@bk.ru")]
    [InlineData("example@index.ru")]
    [InlineData("example@inbox.ru")]
    public async Task VerifyExistingCredentialsTest(string credential)
    {
        var codeRepositoryMock = new Mock<ICodeRepository>();

        await AddCredentials(codeRepositoryMock, credential);
        await VerifyCredentials(codeRepositoryMock, credential);

        codeRepositoryMock.Verify(repo => repo.TryCodeAsync(credential, 1111, CancellationToken.None), Times.Once);
    }

    [Theory]
    [InlineData("+79282334657")]
    [InlineData("89212334157")]
    [InlineData("example@mail.ru")]
    [InlineData("example@bk.ru")]
    [InlineData("example@index.ru")]
    [InlineData("example@inbox.ru")]
    public async Task VerifyNotExistingCredentialsTest(string credential)
    {
        var codeRepositoryMock = new Mock<ICodeRepository>();

        await AddCredentials(codeRepositoryMock, credential);
        await VerifyCredentials(codeRepositoryMock, "credential not exists");

        codeRepositoryMock.Verify(repo => repo.TryCodeAsync(credential, 1111, CancellationToken.None), Times.Never);
    }

    private static async Task AddCredentials(Mock<ICodeRepository> mock, string credential)
    {
        var codeService = new CodeService(mock.Object);
        await codeService.CreateAsync(credential, CancellationToken.None);
    }

    private static async Task VerifyCredentials(Mock<ICodeRepository> mock, string credential)
    {
        var codeService = new CodeService(mock.Object);
        await codeService.TryCodeAsync(credential, 1111, CancellationToken.None);
    }
}