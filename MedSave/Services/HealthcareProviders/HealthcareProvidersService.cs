using MedSave.Context;
using MedSave.DTOs;
using MedSave.DTOs.HealthcareProviders;
using MedSave.Model;
using MedSave.Repositories.Healthcare_Providers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedSave.Services.HealthcareProviders;

public class HealthcareProvidersService : IHealthcareProvidersService
{
    private readonly MedSaveContext _context;
    private readonly IHealthcareProvidersRepository _healthcareProvidersRepository;
    private readonly IAddressStockRepository _addressStockRepository;
    private readonly IProviderTypeRepository _providerTypeRepository;
    
    public HealthcareProvidersService(MedSaveContext context, IHealthcareProvidersRepository healthcareProvidersRepository, IAddressStockRepository addressStockRepository, IProviderTypeRepository providerTypeRepository)
    {
        _context = context;
        _healthcareProvidersRepository = healthcareProvidersRepository;
        _addressStockRepository = addressStockRepository;
        _providerTypeRepository = providerTypeRepository;
    }
    
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message) {}
    }
    
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) {}
    }
    
    public async Task<CreateHealthcareProviderRequest?> GetByIdAsync(long id)
    {
        var hcp = await _healthcareProvidersRepository.GetByIdAsync(id);

        if (hcp == null)
        {
            throw new NotFoundException($"Healthcare Providers with Id {id} not found");
        }

        var addStock = await _addressStockRepository.GetByIdAsync(hcp.AddressIdStock);

        if (addStock == null)
        {
            throw new NotFoundException($"Address Stock with Id {id} not found");
        }

        var provType = await _providerTypeRepository.GetByIdAsync(hcp.ProviderTypeId);

        if (provType == null)
        {
            throw new NotFoundException($"Provider Type with Id {id} not found");
        }

        var hcpDTO = new HealthcareProvidersDTO
        {
            AddressIdStock = hcp.AddressIdStock,
            HealthcareProviderId = hcp.HealthcareProviderId,
            HealthcareProviderName = hcp.HealthcareProviderName,
            ProviderName = hcp.ProviderName,
            ProviderTypeId = hcp.ProviderTypeId
        };

        var addStockDTO = new AddressStockDTO
        {
            AddressDescription = addStock.AddressDescription,
            AddressIdStock = addStock.AddressIdStock,
            Cep = addStock.Cep,
            Complement = addStock.Complement,
            NeighId = addStock.NeighId,
            NumberStock = addStock.NumberStock
        };

        var provTypeDTO = new ProviderTypeDTO
        {
            ProviderName = provType.ProviderName,
            ProviderTypeId = provType.ProviderTypeId
        };

        return new CreateHealthcareProviderRequest
        {
            AddressStockDto = addStockDTO,
            HealthcareProvidersDto = hcpDTO,
            ProviderTypeDto = provTypeDTO
        };
    }

    public async Task<IEnumerable<HealthcareProvidersDTO>> GetAllAsync()
    {
        var hcproviders = await _healthcareProvidersRepository.GetAllAsync();

        return hcproviders.Select(hcprovider => new HealthcareProvidersDTO
        {
            AddressIdStock = hcprovider.AddressIdStock,
            HealthcareProviderId = hcprovider.HealthcareProviderId,
            HealthcareProviderName = hcprovider.HealthcareProviderName,
            ProviderName = hcprovider.ProviderName,
            ProviderTypeId = hcprovider.ProviderTypeId
        }).ToList();
    }

    public async Task<HealthcareProvidersDTO?> AddAsync(HealthcareProvidersDTO healthcareProvidersDto, AddressStockDTO addressStockDto, ProviderTypeDTO providerTypeDto)
    {
        if (healthcareProvidersDto == null) throw new ArgumentNullException(nameof(healthcareProvidersDto));
        if (addressStockDto == null) throw new ArgumentNullException(nameof(addressStockDto));
        if (providerTypeDto == null) throw new ArgumentNullException(nameof(providerTypeDto));

        var address = new AddressStock
        {
            AddressDescription = addressStockDto.AddressDescription,
            AddressIdStock = addressStockDto.AddressIdStock,
            Cep = addressStockDto.Cep,
            Complement = addressStockDto.Complement,
            NeighId = addressStockDto.NeighId,
            NumberStock = addressStockDto.NumberStock
        };

        await _addressStockRepository.AddAsync(address);

        var providerType = new ProviderType
        {
            ProviderName = providerTypeDto.ProviderName,
            ProviderTypeId = providerTypeDto.ProviderTypeId
        };

        await _providerTypeRepository.AddAsync(providerType);

        var healthcareProvider = new Model.HealthcareProviders
        {
            AddressIdStock = address.AddressIdStock,
            ProviderTypeId = providerType.ProviderTypeId,
            HealthcareProviderName = healthcareProvidersDto.HealthcareProviderName,
            ProviderName = healthcareProvidersDto.ProviderName,
        };

        await _healthcareProvidersRepository.AddAsync(healthcareProvider);

        return new HealthcareProvidersDTO
        {
            HealthcareProviderId = healthcareProvider.HealthcareProviderId,
            AddressIdStock = healthcareProvider.AddressIdStock,
            HealthcareProviderName = healthcareProvider.HealthcareProviderName,
            ProviderName = healthcareProvider.ProviderName,
            ProviderTypeId = healthcareProvider.ProviderTypeId
        };
    }

    public async Task UpdateAsync(long id, HealthcareProvidersDTO healthcareProvidersDto)
    {
        if (healthcareProvidersDto == null) throw new ArgumentNullException(nameof(healthcareProvidersDto));

        var existingHCProvider = await _healthcareProvidersRepository.GetByIdAsync(id);

        if (existingHCProvider == null) throw new NotFoundException($"Healthcare Provider with Id {id} not found");

        healthcareProvidersDto.HealthcareProviderId = id;

        throw new NotImplementedException();
    }

    public Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<HealthcareProvidersDTO>> SearchAsync(string? healthcareProviderName, long? providerTypeId, long? addressIdStock, int page, int pageSize, string sortBy, string sortDir)
    {
        throw new NotImplementedException();
    }
}