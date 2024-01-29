using System.Diagnostics.CodeAnalysis;

namespace SportRadar.WorldCupFootball.Implementation;

/// <inheritdocs/>
internal class Group()
    : IGroup
{
    private readonly Random _random = new();
    private readonly List<ICountry> _countries = new();
    
    /// <inheritdocs/>
    public string Name { get; } = "" ?? throw new ArgumentNullException(nameof(Group));

    /// <inheritdocs/>
    public IGroup AddCountry([NotNull] ICountry country)
    {
        ArgumentNullException.ThrowIfNull(country, nameof(country));
        _countries.Add(country);
        return this;
    }

    /// <inheritdocs/>
    public IGroup RemoveCountry([NotNull] ICountry country)
    {
        ArgumentNullException.ThrowIfNull(country, nameof(country));
        _countries.Remove(country);
        return this;
    }

    /// <inheritdocs/>
    public IEnumerable<IMatch> Mix()
    {
        Queue<ICountry> availableCountries = new(_countries.OrderByDescending(c => c));

        while (availableCountries.Count > 1)
        {
            var home = availableCountries.Dequeue();
            var away = availableCountries.Dequeue();

            yield return new Match(home, away);
        }
        
        // remaining country gets a bye!!
    }
    
    /// <inheritdocs/>
    public IMatch[] Rank() => throw new NotImplementedException();
}