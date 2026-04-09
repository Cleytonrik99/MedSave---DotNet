using MedSave.Controllers;
using MedSave.DTOs;
using MedSave.DTOs.Manufacturer;
using MedSave.Repositories;
using MedSave.Services.Manufacturer;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MedSaveTests
{
    public class ManufacturerControllerTests
    {
        private readonly Mock<IManufacturerService> _manufacturerServiceMock;
        private readonly ManufacturerController _controller;

        public ManufacturerControllerTests()
        {
            _manufacturerServiceMock = new Mock<IManufacturerService>();
            _controller = new ManufacturerController(_manufacturerServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOk_WhenManufacturersExist()
        {
            // Arrange
            var manufacturers = new List<ManufacturerDTO>
            {
                new ManufacturerDTO
                {
                    ManufacId = 1,
                    NameManu = "Fornecedor 1",
                    Cnpj = 123456789,
                    ContactManuId = 10,
                    AddressIdManufacturer = 20
                },
                new ManufacturerDTO
                {
                    ManufacId = 2,
                    NameManu = "Fornecedor 2",
                    Cnpj = 987654321,
                    ContactManuId = 11,
                    AddressIdManufacturer = 21
                }
            };

            _manufacturerServiceMock
                .Setup(s => s.GetAllAsync())
                .ReturnsAsync(manufacturers);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnNotFound_WhenRepositoryThrowsNotFoundException()
        {
            // Arrange
            _manufacturerServiceMock
                .Setup(s => s.GetAllAsync())
                .ThrowsAsync(new ManufacturerRepository.NotFoundException("Not found"));

            // Act
            var result = await _controller.GetAll();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnInternalServerError_WhenUnexpectedExceptionOccurs()
        {
            // Arrange
            _manufacturerServiceMock
                .Setup(s => s.GetAllAsync())
                .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _controller.GetAll();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetById_ShouldReturnOk_WhenManufacturerExists()
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

            _manufacturerServiceMock
                .Setup(s => s.GetByIdAsync(1))
                .ReturnsAsync(dto);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(dto, okResult.Value);
        }

        [Fact]
        public async Task GetById_ShouldReturn404_WhenRepositoryThrowsNotFoundException()
        {
            // Arrange
            _manufacturerServiceMock
                .Setup(s => s.GetByIdAsync(1))
                .ThrowsAsync(new ManufacturerRepository.NotFoundException("Not found"));

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(404, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetById_ShouldReturn500_WhenUnexpectedExceptionOccurs()
        {
            // Arrange
            _manufacturerServiceMock
                .Setup(s => s.GetByIdAsync(1))
                .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddManufacturer_ShouldReturnCreatedAtAction_WhenRequestIsValid()
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

            var createdDto = new ManufacturerDTO
            {
                ManufacId = 1,
                NameManu = "Novo Fornecedor",
                Cnpj = 123456789,
                ContactManuId = 10,
                AddressIdManufacturer = 20
            };

            _manufacturerServiceMock
                .Setup(s => s.AddAsync(
                    request.ManufacturerDto,
                    request.AddressManufacturerDto,
                    request.ContactManufacturerDto))
                .ReturnsAsync(createdDto);

            // Act
            var result = await _controller.AddManufacturer(request);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdAtActionResult.StatusCode);
            Assert.Equal(nameof(_controller.GetById), createdAtActionResult.ActionName);
            Assert.Equal(createdDto, createdAtActionResult.Value);
        }

        [Fact]
        public async Task AddManufacturer_ShouldReturnBadRequest_WhenArgumentNullExceptionOccurs()
        {
            // Arrange
            var request = new CreateManufacturerRequest();

            _manufacturerServiceMock
                .Setup(s => s.AddAsync(
                    It.IsAny<ManufacturerDTO>(),
                    It.IsAny<AddressManufacturerDTO>(),
                    It.IsAny<ContactManufacturerDTO>()))
                .ThrowsAsync(new ArgumentNullException());

            // Act
            var result = await _controller.AddManufacturer(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task AddManufacturer_ShouldReturnConflict_WhenConflictExceptionOccurs()
        {
            // Arrange
            var request = new CreateManufacturerRequest
            {
                ManufacturerDto = new ManufacturerDTO(),
                ContactManufacturerDto = new ContactManufacturerDTO(),
                AddressManufacturerDto = new AddressManufacturerDTO()
            };

            _manufacturerServiceMock
                .Setup(s => s.AddAsync(
                    request.ManufacturerDto,
                    request.AddressManufacturerDto,
                    request.ContactManufacturerDto))
                .ThrowsAsync(new ManufacturerService.ConflictException("CNPJ already registered"));

            // Act
            var result = await _controller.AddManufacturer(request);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(409, objectResult.StatusCode);
        }

        [Fact]
        public async Task AddManufacturer_ShouldReturn500_WhenUnexpectedExceptionOccurs()
        {
            // Arrange
            var request = new CreateManufacturerRequest
            {
                ManufacturerDto = new ManufacturerDTO(),
                ContactManufacturerDto = new ContactManufacturerDTO(),
                AddressManufacturerDto = new AddressManufacturerDTO()
            };

            _manufacturerServiceMock
                .Setup(s => s.AddAsync(
                    request.ManufacturerDto,
                    request.AddressManufacturerDto,
                    request.ContactManufacturerDto))
                .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _controller.AddManufacturer(request);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }

        [Fact]
        public async Task UpdateManufacturer_ShouldReturnOk_WhenUpdateSucceeds()
        {
            // Arrange
            var dto = new ManufacturerDTO
            {
                NameManu = "Atualizado",
                Cnpj = 123456789,
                ContactManuId = 10,
                AddressIdManufacturer = 20
            };

            _manufacturerServiceMock
                .Setup(s => s.UpdateAsync(1, It.IsAny<ManufacturerDTO>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateManufacturer(1, dto);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, objectResult.StatusCode);

            _manufacturerServiceMock.Verify(s => s.UpdateAsync(1, It.Is<ManufacturerDTO>(m => m.ManufacId == 1)), Times.Once);
        }

        [Fact]
        public async Task UpdateManufacturer_ShouldReturnNotFound_WhenManufacturerDoesNotExist()
        {
            // Arrange
            var dto = new ManufacturerDTO
            {
                NameManu = "Atualizado",
                Cnpj = 123456789,
                ContactManuId = 10,
                AddressIdManufacturer = 20
            };

            _manufacturerServiceMock
                .Setup(s => s.UpdateAsync(1, It.IsAny<ManufacturerDTO>()))
                .ThrowsAsync(new ManufacturerService.NotFoundException("Not found"));

            // Act
            var result = await _controller.UpdateManufacturer(1, dto);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task UpdateManufacturer_ShouldReturnBadRequest_WhenArgumentNullExceptionOccurs()
        {
            // Arrange
            var dto = new ManufacturerDTO();

            _manufacturerServiceMock
                .Setup(s => s.UpdateAsync(1, It.IsAny<ManufacturerDTO>()))
                .ThrowsAsync(new ArgumentNullException("manufacturerDto", "Invalid data"));

            // Act
            var result = await _controller.UpdateManufacturer(1, dto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task UpdateManufacturer_ShouldReturn500_WhenUnexpectedExceptionOccurs()
        {
            // Arrange
            var dto = new ManufacturerDTO();

            _manufacturerServiceMock
                .Setup(s => s.UpdateAsync(1, It.IsAny<ManufacturerDTO>()))
                .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _controller.UpdateManufacturer(1, dto);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }

        [Fact]
        public async Task DeleteManufacturer_ShouldReturnOk_WhenDeleteSucceeds()
        {
            // Arrange
            _manufacturerServiceMock
                .Setup(s => s.DeleteAsync(1))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteManufacturer(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task DeleteManufacturer_ShouldReturnNotFound_WhenManufacturerDoesNotExist()
        {
            // Arrange
            _manufacturerServiceMock
                .Setup(s => s.DeleteAsync(1))
                .ThrowsAsync(new ManufacturerService.NotFoundException("Not found"));

            // Act
            var result = await _controller.DeleteManufacturer(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task DeleteManufacturer_ShouldReturn500_WhenUnexpectedExceptionOccurs()
        {
            // Arrange
            _manufacturerServiceMock
                .Setup(s => s.DeleteAsync(1))
                .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _controller.DeleteManufacturer(1);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }

        [Fact]
        public async Task Search_ShouldReturnOk_WhenSearchSucceeds()
        {
            // Arrange
            var pagedResult = new PagedResult<ManufacturerDTO>
            {
                Items = new List<ManufacturerDTO>
                {
                    new ManufacturerDTO
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

            _manufacturerServiceMock
                .Setup(s => s.SearchAsync(null, null, null, 1, 10, "manufacId", "asc"))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await _controller.Search(null, null, null, 1, 10, "manufacId", "asc");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task Search_ShouldReturnBadRequest_WhenArgumentExceptionOccurs()
        {
            // Arrange
            _manufacturerServiceMock
                .Setup(s => s.SearchAsync(null, null, null, 1, 10, "manufacId", "asc"))
                .ThrowsAsync(new ArgumentException("Invalid search params"));

            // Act
            var result = await _controller.Search(null, null, null, 1, 10, "manufacId", "asc");

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task Search_ShouldReturn500_WhenUnexpectedExceptionOccurs()
        {
            // Arrange
            _manufacturerServiceMock
                .Setup(s => s.SearchAsync(null, null, null, 1, 10, "manufacId", "asc"))
                .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _controller.Search(null, null, null, 1, 10, "manufacId", "asc");

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }
    }
}