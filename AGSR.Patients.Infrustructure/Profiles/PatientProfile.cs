using AGSR.Patients.ServiceContracts.Dtos.Patient;
using AGSR.Patients.Domain.Entities;
using AGSR.Patients.Kernel.Extensions;
using AutoMapper;

namespace AGSR.Patients.Infrustructure.Profiles;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<PatientDto, Patient>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Name.Id))
            .ForMember(dest => dest.Family, opt => opt.MapFrom(src => src.Name.Family))
            .ForMember(dest => dest.Given, opt => opt.MapFrom(src => src.Name.Given.ConcatenateStrings()))
            .ForMember(dest => dest.Use, opt => opt.MapFrom(src => src.Name.Use))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));

        CreateMap<Patient, PatientDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new PatientName
            {
                Id = src.Id,
                Family = src.Family,
                Given = src.Given.SplitString(),
                Use = src.Use
            }))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));
    }
}
