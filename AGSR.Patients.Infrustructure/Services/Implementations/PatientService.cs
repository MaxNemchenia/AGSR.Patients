using AGSR.Patients.Application.Repositories;
using AGSR.Patients.Domain.Entities;
using AGSR.Patients.Infrustructure.Builders.Interfaces;
using AGSR.Patients.Infrustructure.Enums;
using AGSR.Patients.Infrustructure.Requests;
using AGSR.Patients.Infrustructure.Services.Interfaces;
using AGSR.Patients.ServiceContracts.Dtos.Patient;
using AutoMapper;

namespace AGSR.Patients.Infrustructure.Services.Implementations;

public class PatientService : IPatientService
{
    private readonly IDateSearchModelBuilder _dateSearchModelBuilder;
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public PatientService(
        IDateSearchModelBuilder dateSearchModelBuilder,
        IPatientRepository patientRepository,
        IMapper mapper)
    {
        _dateSearchModelBuilder = dateSearchModelBuilder;
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public IEnumerable<PatientDto> Query()
    {
        var patients = _patientRepository.Query();

        return _mapper.Map<List<PatientDto>>(patients);
    }

    /// <inheritdoc />
    public async Task<PatientDto> GetAsync(Guid id)
    {
        var patient = await _patientRepository.ReadAsync(id);

        return _mapper.Map<PatientDto>(patient);
    }

    /// <inheritdoc />
    public async Task AddAsync(PatientDto patientDto)
    {
        var patient = _mapper.Map<Patient>(patientDto);
        await _patientRepository.AddAsync(patient);
    }

    /// <inheritdoc />
    public async Task AddAsync(IEnumerable<PatientDto> patientDtos)
    {
        var patients = _mapper.Map<List<Patient>>(patientDtos);
        await _patientRepository.AddAsync(patients);
    }

    /// <inheritdoc />
    public async Task UpdateAsync(PatientDto patientDto)
    {
        var patient = _mapper.Map<Patient>(patientDto);
        await _patientRepository.UpdateAsync(patient);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Guid id)
    {
        var patient = await _patientRepository.ReadAsync(id);

        await _patientRepository.DeleteAsync(patient);
    }

    /// <inheritdoc />
    public IEnumerable<PatientDto> Search(DateSearchRequest dateSearch)
    {
        var searchModels = dateSearch.Dates.Select(data => _dateSearchModelBuilder.Build(data));
        var patients = _patientRepository.Query();

        foreach (var searchModel in searchModels)
        {
            patients = searchModel.Prefix switch
            {
                DatePrefix.eq => patients.Where(patient => patient.BirthDate >= searchModel.DatePeriod.StartDate
                    && patient.BirthDate <= searchModel.DatePeriod.EndDate),
                DatePrefix.ne => patients.Where(patient => patient.BirthDate > searchModel.DatePeriod.EndDate
                    || patient.BirthDate < searchModel.DatePeriod.StartDate),
                DatePrefix.gt => patients.Where(patient => patient.BirthDate > searchModel.DatePeriod.EndDate),
                DatePrefix.ge => patients.Where(patient => patient.BirthDate >= searchModel.DatePeriod.StartDate),
                DatePrefix.lt => patients.Where(patient => patient.BirthDate < searchModel.DatePeriod.StartDate),
                DatePrefix.le => patients.Where(patient => patient.BirthDate <= searchModel.DatePeriod.EndDate),
                DatePrefix.sa => patients.Where(patient => patient.BirthDate > searchModel.DatePeriod.EndDate),
                DatePrefix.eb => patients.Where(patient => patient.BirthDate < searchModel.DatePeriod.StartDate),
                DatePrefix.ap => patients.Where(patient
                    => (patient.BirthDate >= searchModel.DatePeriod.StartDate.AddDays(-1)
                    && patient.BirthDate <= searchModel.DatePeriod.StartDate.AddDays(1))),
                _ => throw new NotImplementedException($"Unsupported date prefix: {searchModel.Prefix}"),
            };
        }

        return _mapper.Map<List<PatientDto>>(patients);
    }
}

