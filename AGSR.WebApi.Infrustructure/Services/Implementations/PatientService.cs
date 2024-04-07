using AGSR.Patients.ServiceContracts.Dtos.Patient;
using AGSR.WebApi.Domain.Entities;
using AGSR.WebApi.Domain.Repositories.Interfaces;
using AGSR.WebApi.Infrustructure.Services.Interfaces;
using AutoMapper;

namespace AGSR.WebApi.Infrustructure.Services.Implementations;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public PatientService(IPatientRepository patientRepository, IMapper mapper)
    {
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
}

