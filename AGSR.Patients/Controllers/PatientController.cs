using AGSR.Patients.ServiceContracts.Dtos.Patient;
using AGSR.Patients.Infrustructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AGSR.Patients.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
        => _patientService = patientService;

    [HttpGet]
    public ActionResult<IEnumerable<PatientDto>> GetPatients()
    {
        try
        {
            var patients = _patientService.Query().ToList();

            return Ok(patients);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while retrieving the patients.");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PatientDto>> GetPatientById(Guid id)
    {
        try
        {
            var patient = await _patientService.GetAsync(id);

            if (patient != null)
            {
                return Ok(patient);
            }

            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while retrieving the patient.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddPatient(PatientDto patientDto)
    {
        try
        {
            await _patientService.AddAsync(patientDto);

            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while adding the patient.");
        }
    }

    [HttpPost("add-batch")]
    public async Task<IActionResult> AddPatients(IEnumerable<PatientDto> patientDtos)
    {
        try
        {
            await _patientService.AddAsync(patientDtos);

            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while adding the patients.");
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePatient(PatientDto patientDto)
    {
        try
        {
            await _patientService.UpdateAsync(patientDto);
        }
        catch (Exception)
        {
            if (await PatientExists(patientDto.Name.Id))
            {
                return NotFound();
            }
            else
            {
                return BadRequest();
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(Guid id)
    {
        try
        {
            var patient = await _patientService.GetAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            await _patientService.DeleteAsync(id);

            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while deleting the patient.");
        }
    }

    private async Task<bool> PatientExists(Guid id)
    {
        var patient = await _patientService.GetAsync(id);

        return patient != null;
    }
}

