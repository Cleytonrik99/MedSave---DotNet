using MedSave.Context;
using MedSave.DTOs.Manufacturer;
using MedSave.Model;
using MedSave.Repositories;
using MedSave.Services.Manufacturer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;

namespace MedSaveTests
{
    public class ManufacturerServiceTests
    {
        private readonly Mock<IManufacturerRepository> _manufacturerRepositoryMock;
        private readonly Mock<IAddressManufacturerRepository> _addressRepositoryMock;
        private readonly Mock<IContactManufacturerRepository> _contactRepositoryMock;

        public ManufacturerServiceTests()
        {
            _manufacturerRepositoryMock = new Mock<IManufacturerRepository>();
            _addressRepositoryMock = new Mock<IAddressManufacturerRepository>();
            _contactRepositoryMock = new Mock<IContactManufacturerRepository>();
        }

        private MedSaveContext CreateInMemoryContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<MedSaveContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var configurationMock = new Mock<IConfiguration>();

            return new MedSaveContext(options, configurationMock.Object);
        }

        private ManufacturerService CreateService(MedSaveContext context)
        {
            return new ManufacturerService(
                context,
                _manufacturerRepositoryMock.Object,
                _addressRepositoryMock.Object,
                _contactRepositoryMock.Object
            );
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCreateManufacturerRequest_WhenManufacturerExists()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(GetByIdAsync_ShouldReturnCreateManufacturerRequest_WhenManufacturerExists));
            var service = CreateService(context);

            var manufacturer = new Manufacturer
            {
                ManufacId = 1,
                NameManu = "ACME Pharma",
                Cnpj = 123456789,
                ContactManuId = 10,
                AddressIdManufacturer = 20
            };

            var contact = new ContactManufacturer
            {
                ContactManuId = 10,
                EmailManu = "contato@acme.com",
                PhoneNumberManu = 11999999999
            };

            var address = new AddressManufacturer
            {
                AddressIdManufacturer = 20,
                Complement = "Bloco A",
                NumberManu = 100,
                AddressDescription = "Rua Central",
                Cep = 12345678,
                NeighId = 5
            };

            _manufacturerRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(manufacturer);

            _contactRepositoryMock
                .Setup(r => r.GetByIdAsync(10))
                .ReturnsAsync(contact);

            _addressRepositoryMock
                .Setup(r => r.GetByIdAsync(20))
                .ReturnsAsync(address);

            // Act
            var result = await service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ManufacturerDto);
            Assert.NotNull(result.ContactManufacturerDto);
            Assert.NotNull(result.AddressManufacturerDto);

            Assert.Equal(1, result.ManufacturerDto.ManufacId);
            Assert.Equal("ACME Pharma", result.ManufacturerDto.NameManu);
            Assert.Equal(123456789, result.ManufacturerDto.Cnpj);

            Assert.Equal(10, result.ContactManufacturerDto.ContactManuId);
            Assert.Equal("contato@acme.com", result.ContactManufacturerDto.EmailManu);

            Assert.Equal(20, result.AddressManufacturerDto.AddressIdManufacturer);
            Assert.Equal("Rua Central", result.AddressManufacturerDto.AddressDescription);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedManufacturerDtos()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(GetAllAsync_ShouldReturnMappedManufacturerDtos));
            var service = CreateService(context);

            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer
                {
                    ManufacId = 1,
                    NameManu = "Fornecedor 1",
                    Cnpj = 111111111,
                    ContactManuId = 10,
                    AddressIdManufacturer = 20
                },
                new Manufacturer
                {
                    ManufacId = 2,
                    NameManu = "Fornecedor 2",
                    Cnpj = 222222222,
                    ContactManuId = 11,
                    AddressIdManufacturer = 21
                }
            };

            _manufacturerRepositoryMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(manufacturers);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            var list = result.ToList();

            Assert.Equal(2, list.Count);
            Assert.Equal("Fornecedor 1", list[0].NameManu);
            Assert.Equal("Fornecedor 2", list[1].NameManu);
            Assert.Equal(111111111, list[0].Cnpj);
            Assert.Equal(222222222, list[1].Cnpj);
        }

        [Fact]
        public async Task AddAsync_ShouldThrowArgumentNullException_WhenManufacturerDtoIsNull()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(AddAsync_ShouldThrowArgumentNullException_WhenManufacturerDtoIsNull));
            var service = CreateService(context);

            var addressDto = new AddressManufacturerDTO
            {
                AddressDescription = "Rua A",
                Cep = 12345678,
                Complement = "Casa",
                NumberManu = 10,
                NeighId = 1
            };

            var contactDto = new ContactManufacturerDTO
            {
                EmailManu = "teste@email.com",
                PhoneNumberManu = 11999999999
            };

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                service.AddAsync(null!, addressDto, contactDto));
        }

        [Fact]
        public async Task AddAsync_ShouldThrowArgumentNullException_WhenAddressDtoIsNull()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(AddAsync_ShouldThrowArgumentNullException_WhenAddressDtoIsNull));
            var service = CreateService(context);

            var manufacturerDto = new ManufacturerDTO
            {
                NameManu = "Novo Fornecedor",
                Cnpj = 123456789
            };

            var contactDto = new ContactManufacturerDTO
            {
                EmailManu = "teste@email.com",
                PhoneNumberManu = 11999999999
            };

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                service.AddAsync(manufacturerDto, null!, contactDto));
        }

        [Fact]
        public async Task AddAsync_ShouldThrowArgumentNullException_WhenContactDtoIsNull()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(AddAsync_ShouldThrowArgumentNullException_WhenContactDtoIsNull));
            var service = CreateService(context);

            var manufacturerDto = new ManufacturerDTO
            {
                NameManu = "Novo Fornecedor",
                Cnpj = 123456789
            };

            var addressDto = new AddressManufacturerDTO
            {
                AddressDescription = "Rua A",
                Cep = 12345678,
                Complement = "Casa",
                NumberManu = 10,
                NeighId = 1
            };

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                service.AddAsync(manufacturerDto, addressDto, null!));
        }

        [Fact]
        public async Task AddAsync_ShouldThrowConflictException_WhenCnpjAlreadyExists()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(AddAsync_ShouldThrowConflictException_WhenCnpjAlreadyExists));

            context.Manufacturer.Add(new Manufacturer
            {
                ManufacId = 1,
                NameManu = "Existente",
                Cnpj = 123456789,
                ContactManuId = 10,
                AddressIdManufacturer = 20
            });
            await context.SaveChangesAsync();

            var service = CreateService(context);

            var manufacturerDto = new ManufacturerDTO
            {
                NameManu = "Novo Fornecedor",
                Cnpj = 123456789
            };

            var addressDto = new AddressManufacturerDTO
            {
                AddressDescription = "Rua A",
                Cep = 12345678,
                Complement = "Casa",
                NumberManu = 10,
                NeighId = 1
            };

            var contactDto = new ContactManufacturerDTO
            {
                EmailManu = "novo@email.com",
                PhoneNumberManu = 11999999999
            };

            // Act + Assert
            await Assert.ThrowsAsync<ManufacturerService.ConflictException>(() =>
                service.AddAsync(manufacturerDto, addressDto, contactDto));
        }

        [Fact]
        public async Task AddAsync_ShouldAddAddressContactAndManufacturer_WhenDataIsValid()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(AddAsync_ShouldAddAddressContactAndManufacturer_WhenDataIsValid));
            var service = CreateService(context);

            var manufacturerDto = new ManufacturerDTO
            {
                NameManu = "Novo Fornecedor",
                Cnpj = 987654321
            };

            var addressDto = new AddressManufacturerDTO
            {
                AddressDescription = "Rua Nova",
                Cep = 12345678,
                Complement = "Sala 1",
                NumberManu = 200,
                NeighId = 3
            };

            var contactDto = new ContactManufacturerDTO
            {
                EmailManu = "novo@fornecedor.com",
                PhoneNumberManu = 11988887777
            };

            _addressRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<AddressManufacturer>()))
                .Callback<AddressManufacturer>(address => address.AddressIdManufacturer = 50)
                .Returns(Task.CompletedTask);

            _contactRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<ContactManufacturer>()))
                .Callback<ContactManufacturer>(contact => contact.ContactManuId = 60)
                .Returns(Task.CompletedTask);

            _manufacturerRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Manufacturer>()))
                .Callback<Manufacturer>(manufacturer => manufacturer.ManufacId = 70)
                .Returns(Task.CompletedTask);

            // Act
            var result = await service.AddAsync(manufacturerDto, addressDto, contactDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(70, result.ManufacId);
            Assert.Equal(50, result.AddressIdManufacturer);
            Assert.Equal(60, result.ContactManuId);
            Assert.Equal("Novo Fornecedor", result.NameManu);
            Assert.Equal(987654321, result.Cnpj);

            _addressRepositoryMock.Verify(r => r.AddAsync(It.IsAny<AddressManufacturer>()), Times.Once);
            _contactRepositoryMock.Verify(r => r.AddAsync(It.IsAny<ContactManufacturer>()), Times.Once);
            _manufacturerRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Manufacturer>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateManufacturer_WhenDataIsValid()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(UpdateAsync_ShouldUpdateManufacturer_WhenDataIsValid));
            var service = CreateService(context);

            var existingManufacturer = new Manufacturer
            {
                ManufacId = 1,
                NameManu = "Antigo Nome",
                Cnpj = 111111111,
                ContactManuId = 10,
                AddressIdManufacturer = 20
            };

            var updateDto = new ManufacturerDTO
            {
                ManufacId = 1,
                NameManu = "Novo Nome",
                Cnpj = 222222222,
                ContactManuId = 11,
                AddressIdManufacturer = 21
            };

            _manufacturerRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(existingManufacturer);

            _manufacturerRepositoryMock
                .Setup(r => r.UpdateAsync(It.IsAny<Manufacturer>()))
                .Returns(Task.CompletedTask);

            // Act
            await service.UpdateAsync(1, updateDto);

            // Assert
            _manufacturerRepositoryMock.Verify(r => r.UpdateAsync(It.Is<Manufacturer>(m =>
                m.ManufacId == 1 &&
                m.NameManu == "Novo Nome" &&
                m.Cnpj == 222222222 &&
                m.ContactManuId == 11 &&
                m.AddressIdManufacturer == 21
            )), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowArgumentNullException_WhenDtoIsNull()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(UpdateAsync_ShouldThrowArgumentNullException_WhenDtoIsNull));
            var service = CreateService(context);

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                service.UpdateAsync(1, null!));
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowArgumentNullException_WhenAddressIdManufacturerIsZero()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(UpdateAsync_ShouldThrowArgumentNullException_WhenAddressIdManufacturerIsZero));
            var service = CreateService(context);

            var existingManufacturer = new Manufacturer
            {
                ManufacId = 1,
                NameManu = "Fornecedor",
                Cnpj = 111111111,
                ContactManuId = 10,
                AddressIdManufacturer = 20
            };

            var updateDto = new ManufacturerDTO
            {
                ManufacId = 1,
                NameManu = "Fornecedor",
                Cnpj = 111111111,
                ContactManuId = 10,
                AddressIdManufacturer = 0
            };

            _manufacturerRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(existingManufacturer);

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                service.UpdateAsync(1, updateDto));
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowArgumentNullException_WhenContactManuIdIsZero()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(UpdateAsync_ShouldThrowArgumentNullException_WhenContactManuIdIsZero));
            var service = CreateService(context);

            var existingManufacturer = new Manufacturer
            {
                ManufacId = 1,
                NameManu = "Fornecedor",
                Cnpj = 111111111,
                ContactManuId = 10,
                AddressIdManufacturer = 20
            };

            var updateDto = new ManufacturerDTO
            {
                ManufacId = 1,
                NameManu = "Fornecedor",
                Cnpj = 111111111,
                ContactManuId = 0,
                AddressIdManufacturer = 20
            };

            _manufacturerRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(existingManufacturer);

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                service.UpdateAsync(1, updateDto));
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowNotFoundException_WhenManufacturerDoesNotExist()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(UpdateAsync_ShouldThrowNotFoundException_WhenManufacturerDoesNotExist));
            var service = CreateService(context);

            var updateDto = new ManufacturerDTO
            {
                ManufacId = 1,
                NameManu = "Fornecedor",
                Cnpj = 111111111,
                ContactManuId = 10,
                AddressIdManufacturer = 20
            };

            _manufacturerRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ThrowsAsync(new ManufacturerRepository.NotFoundException("Not found"));

            // Act + Assert
            await Assert.ThrowsAsync<ManufacturerService.NotFoundException>(() =>
                service.UpdateAsync(1, updateDto));
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteManufacturerAddressAndContact_WhenManufacturerExists()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(DeleteAsync_ShouldDeleteManufacturerAddressAndContact_WhenManufacturerExists));
            var service = CreateService(context);

            var manufacturer = new Manufacturer
            {
                ManufacId = 1,
                NameManu = "Fornecedor",
                Cnpj = 123456789,
                ContactManuId = 10,
                AddressIdManufacturer = 20
            };

            _manufacturerRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(manufacturer);

            _manufacturerRepositoryMock
                .Setup(r => r.DeleteAsync(1))
                .Returns(Task.CompletedTask);

            _addressRepositoryMock
                .Setup(r => r.DeleteAsync(20))
                .Returns(Task.CompletedTask);

            _contactRepositoryMock
                .Setup(r => r.DeleteAsync(10))
                .Returns(Task.CompletedTask);

            // Act
            await service.DeleteAsync(1);

            // Assert
            _manufacturerRepositoryMock.Verify(r => r.DeleteAsync(1), Times.Once);
            _addressRepositoryMock.Verify(r => r.DeleteAsync(20), Times.Once);
            _contactRepositoryMock.Verify(r => r.DeleteAsync(10), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowNotFoundException_WhenManufacturerDoesNotExist()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(DeleteAsync_ShouldThrowNotFoundException_WhenManufacturerDoesNotExist));
            var service = CreateService(context);

            _manufacturerRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ThrowsAsync(new ManufacturerRepository.NotFoundException("Not found"));

            // Act + Assert
            await Assert.ThrowsAsync<ManufacturerService.NotFoundException>(() =>
                service.DeleteAsync(1));
        }

        [Fact]
        public async Task SearchAsync_ShouldReturnPagedResultWithMappedItems()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(SearchAsync_ShouldReturnPagedResultWithMappedItems));
            var service = CreateService(context);

            var repositoryItems = new List<Manufacturer>
            {
                new Manufacturer
                {
                    ManufacId = 1,
                    NameManu = "Fornecedor 1",
                    Cnpj = 111111111,
                    ContactManuId = 10,
                    AddressIdManufacturer = 20
                },
                new Manufacturer
                {
                    ManufacId = 2,
                    NameManu = "Fornecedor 2",
                    Cnpj = 222222222,
                    ContactManuId = 11,
                    AddressIdManufacturer = 21
                }
            };

            _manufacturerRepositoryMock
                .Setup(r => r.SearchAsync(null, null, null, 1, 10, "manufacId", "asc"))
                .ReturnsAsync((repositoryItems, 2));

            // Act
            var result = await service.SearchAsync(null, null, null, 1, 10, "manufacId", "asc");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Items.Count());
            Assert.Equal(1, result.PageInfo.Page);
            Assert.Equal(10, result.PageInfo.PageSize);
            Assert.Equal(2, result.PageInfo.TotalItems);
            Assert.Equal(1, result.PageInfo.TotalPages);

            var items = result.Items.ToList();
            Assert.Equal("Fornecedor 1", items[0].NameManu);
            Assert.Equal("Fornecedor 2", items[1].NameManu);
        }

        [Fact]
        public async Task SearchAsync_ShouldNormalizeInvalidPageAndPageSize()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(SearchAsync_ShouldNormalizeInvalidPageAndPageSize));
            var service = CreateService(context);

            _manufacturerRepositoryMock
                .Setup(r => r.SearchAsync(null, null, null, 1, 10, "manufacId", "asc"))
                .ReturnsAsync((new List<Manufacturer>(), 0));

            // Act
            var result = await service.SearchAsync(null, null, null, 0, 0, "manufacId", "asc");

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.Items);
            Assert.Equal(1, result.PageInfo.Page);
            Assert.Equal(10, result.PageInfo.PageSize);
            Assert.Equal(0, result.PageInfo.TotalItems);
            Assert.Equal(0, result.PageInfo.TotalPages);
        }

        [Fact]
        public async Task SearchAsync_ShouldLimitPageSizeTo100()
        {
            // Arrange
            using var context = CreateInMemoryContext(nameof(SearchAsync_ShouldLimitPageSizeTo100));
            var service = CreateService(context);

            _manufacturerRepositoryMock
                .Setup(r => r.SearchAsync(null, null, null, 1, 100, "manufacId", "asc"))
                .ReturnsAsync((new List<Manufacturer>(), 0));

            // Act
            var result = await service.SearchAsync(null, null, null, 1, 150, "manufacId", "asc");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.PageInfo.Page);
            Assert.Equal(100, result.PageInfo.PageSize);
            Assert.Equal(0, result.PageInfo.TotalItems);
            Assert.Equal(0, result.PageInfo.TotalPages);
        }
    }
}