using System.Diagnostics.CodeAnalysis;

namespace SportRadar.WorldCupFootball.Implementation;

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

    /// <inheritdoc/>
    public int Losses { get; private set; }

    /// <inheritdoc/>
    public int Wins { get; private set; }

    /// <inheritdoc/>
    public int Draws { get; private set; }

    /// <inheritdoc/>
    public int GoalsFor { get; private set; }

    /// <inheritdoc/>
    public int GoalsAgainst { get; private set; }

    /// <inheritdoc/>
    public int GoalDifference => GoalsFor - GoalsAgainst;

    /// <inheritdoc/>
    public void AddLoss() => Losses++;

    /// <inheritdoc/>
    public void AddWin() => Wins++;

    /// <inheritdoc/>
    public void AddDraw() => Draws++;

    /// <inheritdoc/>
    public void AddGoalFor() => GoalsFor++;

    /// <inheritdoc/>
    public void AddGoalAgainst() => GoalsAgainst++;
    
    /// <summary>
    /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
    /// </summary>
    /// <param name="other">An object to compare with this instance.</param>
    /// <returns>
    /// A value that indicates the relative order of the objects being compared. The return value has these meanings: 
    /// Less than zero: This instance precedes `other` in the sort order. 
    /// Zero: This instance occurs in the same position in the sort order as `other`. 
    /// Greater than zero: This instance follows `other` in the sort order.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when the other country is null.</exception>
    /// <remarks>
    /// The comparison is based on a point system where wins are worth 3 points, draws are worth 1 point, losses subtract 1 point, and the goal difference is added directly.
    /// </remarks>
    public int CompareTo([NotNull] ICountry other)
    {
        // Check if the other country is null and throw an exception if it is.
        // This is necessary to prevent null reference errors in the following code.
        ArgumentNullException.ThrowIfNull(other);

        // Calculate the total points for this country.
        // Wins are worth 3 points, draws are worth 1 point, losses subtract 1 point, and the goal difference is added directly.
        // This gives a single integer value representing the performance of the country.
        int thisPoints = Wins * 3 + Draws - Losses + GoalDifference;

        // Calculate the total points for the other country in the same way.
        // This allows us to compare the two countries based on their performance.
        int otherPoints = other.Wins * 3 + other.Draws - other.Losses + other.GoalDifference;

        // Compare the total points of this country and the other country.
        // This will return a negative number if this country has fewer points, zero if they have the same number of points, and a positive number if this country has more points.
        // This value can be used to sort countries by their performance.
        return thisPoints.CompareTo(otherPoints);
    }
}