namespace AGSR.Patients.Infrustructure.Requests;

public class DateSearchRequest
{
    public DateSearchRequest()
    {
        Dates = new List<string>();
    }

    public IEnumerable<string> Dates { get; set; }
}
