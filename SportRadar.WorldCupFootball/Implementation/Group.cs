using System.Diagnostics.CodeAnalysis;

namespace SportRadar.WorldCupFootball.Implementation;

/// <inheritdocs/>
internal class Group([NotNull] string name)
    : IGroup
{
    private readonly List<ICountry> _countries = new();
    
    /// <inheritdocs/>
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));

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

        // for a O(n) solution, we could use a circular buffer here
        // meaning we could just rotate the buffer to get the next match
        // instead of removing the "away" country from a list
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