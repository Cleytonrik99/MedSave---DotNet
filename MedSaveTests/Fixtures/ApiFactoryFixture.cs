namespace MedSaveTests.Fixtures;

public class ApiFactoryFixture : IDisposable
{
    public CustomWebApplicationFactory Factory { get; }
    public HttpClient Client { get; }

    public ApiFactoryFixture()
    {
        Factory = new CustomWebApplicationFactory();
        Client = Factory.CreateClient();
    }

    public void Dispose()
    {
        Client.Dispose();
        Factory.Dispose();
    }
}