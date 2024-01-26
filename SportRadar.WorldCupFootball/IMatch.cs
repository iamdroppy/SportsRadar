using System.Diagnostics.CodeAnalysis;

namespace SportRadar.WorldCupFootball;

/// <summary>
/// Represents a match between two countries.
/// </summary>
/// <remarks>
/// Each match involves a home country and an away country, and tracks the score for each.
/// </remarks>
public interface IMatch
{
    /// <summary>
    /// Gets the home country.
    /// </summary>
    /// <value>The home country.</value>
    [NotNull]
    ICountry Home { get; }

    /// <summary>
    /// Gets the away country.
    /// </summary>
    /// <value>The away country.</value>
    [NotNull]
    ICountry Away { get; }

    /// <summary>
    /// Gets the score for the home country.
    /// </summary>
    /// <value>The score for the home country.</value>
    int HomeScore { get; }

    /// <summary>
    /// Gets the score for the away country.
    /// </summary>
    /// <value>The score for the away country.</value>
    int AwayScore { get; }

    /// <summary>
    /// Records a goal for the home country.
    /// </summary>
    void HomeGoal();

    /// <summary>
    /// Records a goal for the away country.
    /// </summary>
    void AwayGoal();
}

/// <inheritdocs/>
internal class Match([NotNull] ICountry home, [NotNull] ICountry away)
    : IMatch
{
    /// <inheritdocs/>
    public ICountry Home { get; } = home ?? throw new ArgumentNullException(nameof(home));

    /// <inheritdocs/>
    public ICountry Away { get; } = away ?? throw new ArgumentNullException(nameof(away));

    /// <inheritdocs/>
    public int HomeScore { get; private set; }

    /// <inheritdocs/>
    public int AwayScore { get; private set; }

    /// <inheritdocs/>
    public void HomeGoal() => HomeScore++;

    /// <inheritdocs/>
    public void AwayGoal() => AwayScore++;

    public override string ToString() => $"{Home.Name} {HomeScore} - {AwayScore} {Away.Name}";
}