using MedSave.Context;
using MedSave.DTOs;
using MedSave.DTOs.Manufacturer;
using MedSave.Model;
using MedSave.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedSave.Services.Manufacturer;

public class ManufacturerService : IManufacturerService
{
    private readonly MedSaveContext _context;
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IAddressManufacturerRepository _addressManufacturerRepository;
    private readonly IContactManufacturerRepository _contactManufacturerRepository;

    public ManufacturerService(MedSaveContext context, IManufacturerRepository manufacturerRepository, IAddressManufacturerRepository addressManufacturerRepository, IContactManufacturerRepository contactManufacturerRepository)
    {
        _context = context;
        _manufacturerRepository = manufacturerRepository;
        _addressManufacturerRepository = addressManufacturerRepository;
        _contactManufacturerRepository = contactManufacturerRepository;
    }

    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message) {}
    }
    
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) {}
    }

    public async Task<CreateManufacturerRequest?> GetByIdAsync(long id)
    {
        var manufac = await _manufacturerRepository.GetByIdAsync(id);

        var contact = await _contactManufacturerRepository.GetByIdAsync(manufac.ContactManuId);

        var address = await _addressManufacturerRepository.GetByIdAsync(manufac.AddressIdManufacturer);
        
        var manuDTO = new ManufacturerDTO
        {
            ManufacId = manufac.ManufacId,
            AddressIdManufacturer = manufac.AddressIdManufacturer,
            Cnpj = manufac.Cnpj,
            ContactManuId = manufac.ContactManuId,
            NameManu = manufac.NameManu
        };

        var contactDTO = new ContactManufacturerDTO
        {
            ContactManuId = contact.ContactManuId,
            EmailManu = contact.EmailManu,
            PhoneNumberManu = contact.PhoneNumberManu
        };

        var addressDTO = new AddressManufacturerDTO
        {
            AddressDescription = address.AddressDescription,
            AddressIdManufacturer = address.AddressIdManufacturer,
            Cep = address.Cep,
            Complement = address.Complement,
            NeighId = address.NeighId,
            NumberManu = address.NumberManu
        };

        return new CreateManufacturerRequest
        {
            ManufacturerDto = manuDTO,
            ContactManufacturerDto = contactDTO,
            AddressManufacturerDto = addressDTO
        };
    }

    public async Task<IEnumerable<ManufacturerDTO>> GetAllAsync()
    {
        var manufacs = await _manufacturerRepository.GetAllAsync();

        return manufacs.Select(manufac => new ManufacturerDTO
        {
            AddressIdManufacturer = manufac.AddressIdManufacturer,
            Cnpj = manufac.Cnpj,
            ContactManuId = manufac.ContactManuId,
            ManufacId = manufac.ManufacId,
            NameManu = manufac.NameManu
        }).ToList();
    }

    public async Task<ManufacturerDTO?> AddAsync(ManufacturerDTO manufacturerDto, AddressManufacturerDTO addressManufacturerDto, ContactManufacturerDTO contactManufacturerDto)
    {
        if (manufacturerDto == null) throw new ArgumentNullException(nameof(manufacturerDto));
        if (addressManufacturerDto == null) throw new ArgumentNullException(nameof(addressManufacturerDto));
        if (contactManufacturerDto == null) throw new ArgumentNullException(nameof(contactManufacturerDto));

        var search = await _context.Manufacturer.FirstOrDefaultAsync(m => m.Cnpj == manufacturerDto.Cnpj);

        if (search != null) throw new ConflictException("CNPJ Already registered");

        var address = new AddressManufacturer
        {
            AddressDescription = addressManufacturerDto.AddressDescription,
            Cep = addressManufacturerDto.Cep,
            Complement = addressManufacturerDto.Complement,
            NeighId = addressManufacturerDto.NeighId,
            NumberManu = addressManufacturerDto.NumberManu
        };

        await _addressManufacturerRepository.AddAsync(address);

        var contact = new ContactManufacturer
        {
            EmailManu = contactManufacturerDto.EmailManu,
            PhoneNumberManu = contactManufacturerDto.PhoneNumberManu
        };

        await _contactManufacturerRepository.AddAsync(contact);

        var manufacturer = new Model.Manufacturer
        {
            AddressIdManufacturer = address.AddressIdManufacturer,
            ContactManuId = contact.ContactManuId,
            Cnpj = manufacturerDto.Cnpj,
            NameManu = manufacturerDto.NameManu
        };

        await _manufacturerRepository.AddAsync(manufacturer);

        return new ManufacturerDTO
        {
            ManufacId = manufacturer.ManufacId,
            AddressIdManufacturer = manufacturer.AddressIdManufacturer,
            ContactManuId = manufacturer.ContactManuId,
            Cnpj = manufacturer.Cnpj,
            NameManu = manufacturer.NameManu
        };
    }

    public async Task UpdateAsync(long id, ManufacturerDTO manufacturerDto)
    {
        if (manufacturerDto == null)
        {
            throw new ArgumentNullException(nameof(manufacturerDto), "Manufacturer Object can't be null.");
        }

        try
        {
            var existingManufacturer = await _manufacturerRepository.GetByIdAsync(id);

            if (manufacturerDto.AddressIdManufacturer == 0)
            {
                throw new ArgumentNullException(nameof(manufacturerDto), "Address Id Manufacturer can't be null or zero");
            }

            if (manufacturerDto.ContactManuId == 0)
            {
                throw new ArgumentNullException(nameof(manufacturerDto), "Contact Manu Id can't be null or zero.");
            }

            existingManufacturer.AddressIdManufacturer = manufacturerDto.AddressIdManufacturer;
            existingManufacturer.Cnpj = manufacturerDto.Cnpj;
            existingManufacturer.ContactManuId = manufacturerDto.ContactManuId;
            existingManufacturer.ManufacId = manufacturerDto.ManufacId;
            existingManufacturer.NameManu = manufacturerDto.NameManu;

            await _manufacturerRepository.UpdateAsync(existingManufacturer);
        }
        
        catch (ManufacturerRepository.NotFoundException ex)
        {
            throw new NotFoundException($"Manufacturer with Id {id} not found.");
        }
    }

    public async Task DeleteAsync(long id)
    {
        try
        {
            var manu = await _manufacturerRepository.GetByIdAsync(id);
            
            await _manufacturerRepository.DeleteAsync(id);
            await _addressManufacturerRepository.DeleteAsync(manu.AddressIdManufacturer);
            await _contactManufacturerRepository.DeleteAsync(manu.ContactManuId);
        }
        catch (ManufacturerRepository.NotFoundException ex)
        {
            throw new NotFoundException($"Manufacturer with ID {id} not found.");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error when Trying to delete the manufacturer with id {id}: {ex.Message}");
        }
    }

    public async Task<PagedResult<ManufacturerDTO>> SearchAsync(int? cnpj, long? contactManuId, long? addressIdManufacturer, int page, int pageSize, string sortBy, string sortDir)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;
        if (pageSize > 100) pageSize = 100;

        var (items, total) = await _manufacturerRepository.SearchAsync(cnpj, contactManuId, addressIdManufacturer, page, pageSize, sortBy ?? "manufacId", sortDir ?? "asc");

        var dtoItems = items.Select(manufacturer => new ManufacturerDTO
        {
            AddressIdManufacturer = manufacturer.AddressIdManufacturer,
            Cnpj = manufacturer.Cnpj,
            ContactManuId = manufacturer.ContactManuId,
            ManufacId = manufacturer.ManufacId,
            NameManu = manufacturer.NameManu
        }).ToList();

        var totalPages = (int)Math.Ceiling(total / (double)pageSize);

        return new PagedResult<ManufacturerDTO>
        {
            Items = dtoItems,
            PageInfo = new PageInfo
            {
                Page = page,
                PageSize = pageSize,
                TotalItems = total,
                TotalPages = totalPages
            }
        };
    }
}