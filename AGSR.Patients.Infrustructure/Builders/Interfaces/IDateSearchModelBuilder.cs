using AGSR.Patients.Infrustructure.SearchModels.DateSearch;

namespace AGSR.Patients.Infrustructure.Builders.Interfaces;

public interface IDateSearchModelBuilder
{
    /// <summary>
    /// Builds a DateSearchModel based on the provided full date string.
    /// </summary>
    /// <param name="fullDate">The full date string to build the DateSearchModel from.</param>
    /// <returns>The built DateSearchModel, if successful; otherwise, null.</returns>
    DateSearchModel? Build(string fullDate);
}
