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
    /// Generates a set of matches within the group.
    /// </summary>
    /// <returns>An enumerable of matches.</returns>
    IEnumerable<IMatch> Mix();
    
    /// <summary>
    /// Rank the countries in the group.
    /// </summary>
    /// <returns>An array of countries, ordered by rank.</returns>
    public IMatch[] Rank();
}

/// <inheritdocs/>
internal class Group([NotNull] string name)
    : IGroup
{
    /// <inheritdocs/>
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));

    /// <inheritdocs/>
    public IGroup AddCountry([NotNull] ICountry country) => throw new NotImplementedException();

    /// <inheritdocs/>
    public IGroup RemoveCountry([NotNull] ICountry country) => throw new NotImplementedException();
    
    /// <inheritdocs/>
    public IEnumerable<IMatch> Mix() => throw new NotImplementedException();
    
    /// <inheritdocs/>
    public IMatch[] Rank() => throw new NotImplementedException();
}