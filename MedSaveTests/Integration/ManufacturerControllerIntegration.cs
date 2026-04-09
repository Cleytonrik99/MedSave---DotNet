using System.Net;
using System.Net.Http.Json;
using MedSave.DTOs;
using MedSave.DTOs.Manufacturer;
using MedSave.Repositories;
using MedSave.Services.Manufacturer;
using MedSaveTests.Fixtures;
using Moq;

namespace MedSaveTests.Integration;

[Collection("Api collection")]
public class ManufacturerControllerIntegrationTests
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory _factory;

    public ManufacturerControllerIntegrationTests(ApiFactoryFixture fixture)
    {
        _client = fixture.Client;
        _factory = fixture.Factory;
    }

    [Fact]
    public async Task GetAll_ShouldReturn200_WhenManufacturersExist()
    {
        // Arrange
        var manufacturers = new List<ManufacturerDTO>
        {
            new()
            {
                ManufacId = 1,
                NameManu = "Fornecedor 1",
                Cnpj = 123456789,
                ContactManuId = 10,
                AddressIdManufacturer = 20
            },
            new()
            {
                ManufacId = 2,
                NameManu = "Fornecedor 2",
                Cnpj = 987654321,
                ContactManuId = 11,
                AddressIdManufacturer = 21
            }
        };

        _factory.ManufacturerServiceMock.Reset();
        _factory.ManufacturerServiceMock
            .Setup(s => s.GetAllAsync())
            .ReturnsAsync(manufacturers);

        // Act
        var response = await _client.GetAsync("/api/Manufacturer");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains("Fornecedor 1", body);
        Assert.Contains("Fornecedor 2", body);
    }

    [Fact]
    public async Task GetAll_ShouldReturn404_WhenNoManufacturersExist()
    {
        // Arrange
        _factory.ManufacturerServiceMock.Reset();
        _factory.ManufacturerServiceMock
            .Setup(s => s.GetAllAsync())
            .ThrowsAsync(new ManufacturerRepository.NotFoundException("Not found"));

        // Act
        var response = await _client.GetAsync("/api/Manufacturer");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetById_ShouldReturn200_WhenManufacturerExists()
    {
        // Arrange
        var dto = new CreateManufacturerRequest
        {
            ManufacturerDto = new ManufacturerDTO
            {
                ManufacId = 1,
                NameManu = "Fornecedor",
                Cnpj = 123456789,
                ContactManuId = 10,
                AddressIdManufacturer = 20
            },
            ContactManufacturerDto = new ContactManufacturerDTO
            {
                ContactManuId = 10,
                EmailManu = "teste@email.com",
                PhoneNumberManu = 11999999999
            },
            AddressManufacturerDto = new AddressManufacturerDTO
            {
                AddressIdManufacturer = 20,
                Complement = "Sala 1",
                NumberManu = 100,
                AddressDescription = "Rua A",
                Cep = 12345678,
                NeighId = 1
            }
        };

        _factory.ManufacturerServiceMock.Reset();
        _factory.ManufacturerServiceMock
            .Setup(s => s.GetByIdAsync(1))
            .ReturnsAsync(dto);

        // Act
        var response = await _client.GetAsync("/api/Manufacturer/1");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains("Fornecedor", body);
        Assert.Contains("teste@email.com", body);
    }

    [Fact]
    public async Task GetById_ShouldReturn404_WhenManufacturerDoesNotExist()
    {
        // Arrange
        _factory.ManufacturerServiceMock.Reset();
        _factory.ManufacturerServiceMock
            .Setup(s => s.GetByIdAsync(1))
            .ThrowsAsync(new ManufacturerRepository.NotFoundException("Not found"));

        // Act
        var response = await _client.GetAsync("/api/Manufacturer/1");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task AddManufacturer_ShouldReturn201_WhenRequestIsValid()
    {
        // Arrange
        var request = new CreateManufacturerRequest
        {
            ManufacturerDto = new ManufacturerDTO
            {
                NameManu = "Novo Fornecedor",
                Cnpj = 123456789
            },
            ContactManufacturerDto = new ContactManufacturerDTO
            {
                EmailManu = "novo@email.com",
                PhoneNumberManu = 11999999999
            },
            AddressManufacturerDto = new AddressManufacturerDTO
            {
                Complement = "Sala 2",
                NumberManu = 100,
                AddressDescription = "Rua Nova",
                Cep = 12345678,
                NeighId = 1
            }
        };

        var created = new ManufacturerDTO
        {
            ManufacId = 1,
            NameManu = "Novo Fornecedor",
            Cnpj = 123456789,
            ContactManuId = 10,
            AddressIdManufacturer = 20
        };

        _factory.ManufacturerServiceMock.Reset();
        _factory.ManufacturerServiceMock
            .Setup(s => s.AddAsync(
                It.IsAny<ManufacturerDTO>(),
                It.IsAny<AddressManufacturerDTO>(),
                It.IsAny<ContactManufacturerDTO>()))
            .ReturnsAsync(created);

        // Act
        var response = await _client.PostAsJsonAsync("/api/Manufacturer", request);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains("Novo Fornecedor", body);
    }

    [Fact]
    public async Task UpdateManufacturer_ShouldReturn200_WhenUpdateSucceeds()
    {
        // Arrange
        var dto = new ManufacturerDTO
        {
            NameManu = "Atualizado",
            Cnpj = 123456789,
            ContactManuId = 10,
            AddressIdManufacturer = 20
        };

        _factory.ManufacturerServiceMock.Reset();
        _factory.ManufacturerServiceMock
            .Setup(s => s.UpdateAsync(1, It.IsAny<ManufacturerDTO>()))
            .Returns(Task.CompletedTask);

        // Act
        var response = await _client.PutAsJsonAsync("/api/Manufacturer/1", dto);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task UpdateManufacturer_ShouldReturn404_WhenManufacturerDoesNotExist()
    {
        // Arrange
        var dto = new ManufacturerDTO
        {
            NameManu = "Atualizado",
            Cnpj = 123456789,
            ContactManuId = 10,
            AddressIdManufacturer = 20
        };

        _factory.ManufacturerServiceMock.Reset();
        _factory.ManufacturerServiceMock
            .Setup(s => s.UpdateAsync(1, It.IsAny<ManufacturerDTO>()))
            .ThrowsAsync(new ManufacturerService.NotFoundException("Not found"));

        // Act
        var response = await _client.PutAsJsonAsync("/api/Manufacturer/1", dto);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task DeleteManufacturer_ShouldReturn200_WhenDeleteSucceeds()
    {
        // Arrange
        _factory.ManufacturerServiceMock.Reset();
        _factory.ManufacturerServiceMock
            .Setup(s => s.DeleteAsync(1))
            .Returns(Task.CompletedTask);

        // Act
        var response = await _client.DeleteAsync("/api/Manufacturer/1");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Search_ShouldReturn200_WhenSearchSucceeds()
    {
        // Arrange
        var result = new PagedResult<ManufacturerDTO>
        {
            Items = new List<ManufacturerDTO>
            {
                new()
                {
                    ManufacId = 1,
                    NameManu = "Fornecedor 1",
                    Cnpj = 123456789,
                    ContactManuId = 10,
                    AddressIdManufacturer = 20
                }
            },
            PageInfo = new PageInfo
            {
                Page = 1,
                PageSize = 10,
                TotalItems = 1,
                TotalPages = 1
            }
        };

        _factory.ManufacturerServiceMock.Reset();
        _factory.ManufacturerServiceMock
            .Setup(s => s.SearchAsync(null, null, null, 1, 10, "manufacId", "asc"))
            .ReturnsAsync(result);

        // Act
        var response = await _client.GetAsync("/api/Manufacturer/search?page=1&pageSize=10&sortBy=manufacId&sortDir=asc");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains("Fornecedor 1", body);
    }
}