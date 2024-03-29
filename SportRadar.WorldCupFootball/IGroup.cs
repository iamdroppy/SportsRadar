using System.Diagnostics.CodeAnalysis;

namespace SportRadar.WorldCupFootball;

/// <summary>
/// Represents a group of countries in the World Cup.
/// </summary>
/// <remarks>
/// Each group has a unique name and contains a set of countries. Matches can be generated within the group.
/// </remarks>
public interface IGroup
{
    /// <summary>
    /// Gets the name of the group.
    /// </summary>
    /// <value>The name of the group.</value>
    string Name { get; }

    /// <summary>
    /// Adds a country to the group.
    /// </summary>
    /// <param name="country">The country to add.</param>
    /// <returns>The current group (fluent).</returns>
    /// <exception cref="ArgumentNullException">Thrown when the country is null.</exception>
    IGroup AddCountry([NotNull] ICountry country);

    /// <summary>
    /// Removes a country from the group.
    /// </summary>
    /// <param name="country">The country to remove.</param>
    /// <returns>The current group (fluent).</returns>
    /// <exception cref="ArgumentNullException">Thrown when the country is null.</exception>
    IGroup RemoveCountry([NotNull] ICountry country);
    
    /// <summary>
    /// Generates a set of matches within the group and gives them random scores.
    /// </summary>
    /// <returns>An enumerable of matches.</returns>
    IEnumerable<IMatch> Mix();
}