using AutoMapper;
using Services.SubModules.LogicLayers.Models.Responses.Entities;
using Services.SubModules.Protos;
using System.Security.Claims;

namespace Services.SubModules.LogicLayers.Profiles.Entities
{
    public class ServiceProfile : Profile, IProfile
    {
        private Guid Parse(string value)
        {
            if (Guid.TryParse(value, out var result))
                return result;

            return Guid.Empty;
        }

        public ServiceProfile()
        {
            CreateMap<UserResponse, UserIdentityGrpcResponse>().ForMember(d => d.Id, o => o.MapFrom(s => s.Id.ToString()))
                                                               .ForMember(d => d.Login, o => o.MapFrom(s => s.Login))
                                                               .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
                                                               .ForMember(d => d.ConfirmedEmail, o => o.MapFrom(s => s.ConfirmedEmail))
                                                               .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.PhoneNumber))
                                                               .ForMember(d => d.ConfirmedPhoneNumber, o => o.MapFrom(s => s.ConfirmedPhoneNumber))
                                                               .ForMember(d => d.TwoFactorEnabled, o => o.MapFrom(s => s.TwoFactorEnabled))
                                                               .ForMember(d => d.Roles, o => o.MapFrom(s => s.Roles))
                                                               .ForMember(d => d.Claims, o => o.MapFrom(s => s.Claims))
                                                               .ReverseMap()
                                                               .ForMember(d => d.Id, o => o.MapFrom(s => Parse(s.Id)))
                                                               .ForMember(d => d.Login, o => o.MapFrom(s => s.Login))
                                                               .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
                                                               .ForMember(d => d.ConfirmedEmail, o => o.MapFrom(s => s.ConfirmedEmail))
                                                               .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.PhoneNumber))
                                                               .ForMember(d => d.ConfirmedPhoneNumber, o => o.MapFrom(s => s.ConfirmedPhoneNumber))
                                                               .ForMember(d => d.TwoFactorEnabled, o => o.MapFrom(s => s.TwoFactorEnabled))
                                                               .ForMember(d => d.Roles, o => o.MapFrom(s => s.Roles))
                                                               .ForMember(d => d.Claims, o => o.MapFrom(s => s.Claims));

            CreateMap<RoleResponse, RoleIdentityGrpcResponse>().ForMember(d => d.Id, o => o.MapFrom(s => s.Id.ToString()))
                                                               .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                                                               .ReverseMap()
                                                               .ForMember(d => d.Id, o => o.MapFrom(s => Parse(s.Id)))
                                                               .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));

            CreateMap<ClaimResponse, ClaimRoleIdentityGrpcResponse>().ForMember(d => d.Type, o => o.MapFrom(s => s.Type))
                                                                     .ForMember(d => d.Value, o => o.MapFrom(s => s.Value))
                                                                     .ReverseMap()
                                                                     .ForMember(d => d.Type, o => o.MapFrom(s => s.Type))
                                                                     .ForMember(d => d.Value, o => o.MapFrom(s => s.Value));

            CreateMap<Claim, ClaimResponse>().ForMember(d => d.Type, o => o.MapFrom(s => s.Type))
                                             .ForMember(d => d.Value, o => o.MapFrom(s => s.Value))
                                             .ReverseMap()
                                             .ForMember(d => d.Type, o => o.MapFrom(s => s.Type))
                                             .ForMember(d => d.Value, o => o.MapFrom(s => s.Value));

            CreateMap<CurrencyResponse, CurrencyCommonGrpcResponse>().ReverseMap();
        }
    }
}
