using AutoMapper;
using MAS.FloraFire.ClientPortal.Customers;
using MAS.FloraFire.ClientPortal.Countries;
using MAS.FloraFire.ClientPortal.StateProvinces;
using MAS.FloraFire.ClientPortal.EmailDirectories;
using MAS.FloraFire.ClientPortal.PhoneDirectories;

using MAS.FloraFire.ClientPortal.CustomerComments;
using MAS.FloraFire.ClientPortal.StoreWorkHours;
using MAS.FloraFire.ClientPortal.Values;
using MAS.FloraFire.ClientPortal.Stores;
using MAS.FloraFire.ClientPortal.Vehicles;
using MAS.FloraFire.ClientPortal.Shops;
using MAS.FloraFire.ClientPortal.Logs;

namespace MAS.FloraFire.ClientPortal;

public class ClientPortalApplicationAutoMapperProfile : Profile
{
    public ClientPortalApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Country, CountryLookupDto>().ReverseMap();
        CreateMap<StateProvince, StateProvinceDto>().ReverseMap();
        CreateMap<StateProvince, StateProvinceLookupDto>().ReverseMap();

        CreateMap<CustomerComment, CustomerCommentDto>().ReverseMap();
        CreateMap<CreateUpdateCustomerCommentDto, CustomerComment>().ReverseMap();
        CreateMap<CustomerCommentDto, CreateUpdateCustomerCommentDto>().ReverseMap();

        CreateMap<ValueType, ValueTypeDto>().ReverseMap();
        CreateMap<ValueTypeDto, CreateUpdateValueTypeDto>().ReverseMap();
        CreateMap<CreateUpdateValueTypeDto, ValueType>().ReverseMap();
        CreateMap<ValueType, ValueTypeLookupDto>().ReverseMap();
        CreateMap<Value, ValueDto>().ReverseMap();
        CreateMap<CreateUpdateValueDto, Value>().ReverseMap();

        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<CustomerDto, CreateUpdateCustomerDto>().ReverseMap();
        CreateMap<CreateUpdateCustomerDto, Customer>().ReverseMap();

        CreateMap<StoreWorkHour, StoreWorkHourDto>().ReverseMap();
        CreateMap<StoreWorkHourDto, CreateUpdateStoreWorkHourDto>().ReverseMap();
        CreateMap<CreateUpdateStoreWorkHourDto, StoreWorkHour>().ReverseMap();
        CreateMap<StoreWorkHour, StoreWorkHourLookupDto>().ReverseMap();

        CreateMap<EmailDirectory, EmailDirectoryDto>().ReverseMap();
        CreateMap<CreateUpdateEmailDirectoryDto, EmailDirectory>().ReverseMap();
        CreateMap<EmailDirectoryDto, CreateUpdateEmailDirectoryDto>().ReverseMap();

        CreateMap<PhoneDirectory, PhoneDirectoryDto>().ReverseMap();
        CreateMap<CreateUpdatePhoneDirectoryDto, PhoneDirectory>().ReverseMap();
        CreateMap<PhoneDirectoryDto, CreateUpdatePhoneDirectoryDto>().ReverseMap();

        CreateMap<Vehicle, VehicleDto>().ReverseMap();
        CreateMap<CreateUpdateVehicleDto, Vehicle>().ReverseMap();
        CreateMap<VehicleDto, CreateUpdateVehicleDto>().ReverseMap();

        CreateMap<Shop, ShopDto>().ReverseMap();
        CreateMap<Shop, CreateUpdateShopDto>().ReverseMap();

        CreateMap<Store, StoreDto>()
            .ForMember(model => model.StoreWorkHours, options => options.Ignore());
        CreateMap<CreateUpdateStoreDto, Store>();
        CreateMap<StoreDto, CreateUpdateStoreDto>()
            .ForMember(model => model.StoreWorkHours, options => options.Ignore());
        CreateMap<Store, StoreLookupDto>();

        CreateMap<AuditType, AuditTypeDto>().ReverseMap();
        CreateMap<AuditType, AuditTypeLookupDto>().ReverseMap();
        CreateMap<AuditTypeDto, CreateUpdateAuditTypeDto>().ReverseMap();
        CreateMap<AuditType, CreateUpdateAuditTypeDto>().ReverseMap();
        CreateMap<AuditLog, AuditLogDto>()
            .ForMember(
                dest => dest.AuditType,
                opt => opt.MapFrom(src => src.AuditType != null ? src.AuditType.Name : null)
            ).ReverseMap();
        CreateMap<AuditLogDto, CreateUpdateAuditLogDto>().ReverseMap();
        CreateMap<AuditLog, CreateUpdateAuditLogDto>().ReverseMap();

        CreateMap<ErrorLog, ErrorLogDto>().ReverseMap();
        CreateMap<ErrorLogDto, CreateUpdateErrorLogDto>().ReverseMap();
        CreateMap<ErrorLog, CreateUpdateErrorLogDto>().ReverseMap();
    }
}
