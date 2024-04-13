namespace AGSR.Patients.Kernel.Builders.Interfaces;

public interface IConnectionStringBuilder
{
    /// <summary>
    /// Builds the connection string.
    /// </summary>
    /// <returns>The constructed connection string.</returns>
    string BuildConnectionString();
}

