using System.Net;
using System.Net.Http.Json;
using MedSaveTests.Fixtures;
using Moq;

namespace MedSaveTests.Integration;

[Collection("Api collection")]
public class ManufacturerControllerErrorIntegrationTests
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory _factory;

    public ManufacturerControllerErrorIntegrationTests(ApiFactoryFixture fixture)
    {
        _client = fixture.Client;
        _factory = fixture.Factory;
    }

    [Fact]
    public async Task AddManufacturer_ShouldReturn500_WhenUnexpectedExceptionOccurs()
    {
        var request = new
        {
            manufacturerDto = new { nameManu = "Teste", cnpj = 123456789 },
            contactManufacturerDto = new { emailManu = "teste@email.com", phoneNumberManu = 11999999999 },
            addressManufacturerDto = new { complement = "A", numberManu = 10, addressDescription = "Rua X", cep = 12345678, neighId = 1 }
        };

        _factory.ManufacturerServiceMock.Reset();
        _factory.ManufacturerServiceMock
            .Setup(s => s.AddAsync(
                It.IsAny<MedSave.DTOs.Manufacturer.ManufacturerDTO>(),
                It.IsAny<MedSave.DTOs.Manufacturer.AddressManufacturerDTO>(),
                It.IsAny<MedSave.DTOs.Manufacturer.ContactManufacturerDTO>()))
            .ThrowsAsync(new Exception("Unexpected error"));

        var response = await _client.PostAsJsonAsync("/api/Manufacturer", request);

        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async Task DeleteManufacturer_ShouldReturn500_WhenUnexpectedExceptionOccurs()
    {
        _factory.ManufacturerServiceMock.Reset();
        _factory.ManufacturerServiceMock
            .Setup(s => s.DeleteAsync(1))
            .ThrowsAsync(new Exception("Unexpected error"));

        var response = await _client.DeleteAsync("/api/Manufacturer/1");

        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }
}