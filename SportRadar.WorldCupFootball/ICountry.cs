using System.Diagnostics.CodeAnalysis;

namespace SportRadar.WorldCupFootball;

/// <summary>
/// Represents a country participating in the World Cup.
/// </summary>
/// <remarks>
/// Each country has a unique name and code, and a strength multiplier that affects its performance in matches.
/// </remarks>
public interface ICountry
{
    /// <summary>
    /// Gets the name of the country.
    /// </summary>
    /// <value>The name of the country.</value>
    [NotNull]
    string Name { get; }

    /// <summary>
    /// Gets the code of the country.
    /// </summary>
    /// <value>The code of the country.</value>
    [NotNull]
    string Code { get; }

    /// <summary>
    /// Gets the strength multiplier of the country.
    /// </summary>
    /// <value>The strength multiplier of the country.</value>
    float StrengthMultiplier { get; }
}

/// <inheritdocs/>
internal class Country([NotNull] string name, [NotNull] string code, float strengthMultiplier)
    : ICountry
{
    /// <inheritdocs/>
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
    
    /// <inheritdocs/>
    public string Code { get; } = code ?? throw new ArgumentNullException(nameof(code));

    /// <inheritdocs/>
    public float StrengthMultiplier { get; } = strengthMultiplier;
}