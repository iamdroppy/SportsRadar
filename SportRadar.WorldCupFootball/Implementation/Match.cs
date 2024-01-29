using System.Diagnostics.CodeAnalysis;

namespace SportRadar.WorldCupFootball.Implementation;

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
    public void HomeGoal(int goals = 1)
    {
        HomeScore += goals;
        Home.AddGoalFor(goals);
        Away.AddGoalAgainst(goals);
    }

    /// <inheritdocs/>
    public void AwayGoal(int goals = 1)
    {
        AwayScore += goals;
        Away.AddGoalFor(goals);
        Home.AddGoalAgainst(goals);
    }

    public override string ToString() => $"{Home.Name} {HomeScore} - {AwayScore} {Away.Name}";
}