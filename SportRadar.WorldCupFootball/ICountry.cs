using System.Diagnostics.CodeAnalysis;

namespace SportRadar.WorldCupFootball;

/// <summary>
/// Represents a country participating in the World Cup.
/// </summary>
/// <remarks>
/// Each country has a unique name and code, and a strength multiplier that affects its performance in matches.
/// </remarks>
public interface ICountry : IComparable<ICountry>
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
    /// Gets the number of losses of the country.
    /// </summary>
    /// <value>The number of losses of the country.</value>
    int Losses { get; }

    /// <summary>
    /// Gets the number of wins of the country.
    /// </summary>
    /// <value>The number of wins of the country.</value>
    int Wins { get; }

    /// <summary>
    /// Gets the number of draws of the country.
    /// </summary>
    /// <value>The number of draws of the country.</value>
    int Draws { get; }

    /// <summary>
    /// Gets the number of goals scored by the country.
    /// </summary>
    /// <value>The number of goals scored by the country.</value>
    int GoalsFor { get; }

    /// <summary>
    /// Gets the number of goals scored against the country.
    /// </summary>
    /// <value>The number of goals scored against the country.</value>
    int GoalsAgainst { get; }

    /// <summary>
    /// Gets the goal difference of the country.
    /// </summary>
    /// <value>The goal difference of the country.</value>
    int GoalDifference { get; }
        
    /// <summary>
    /// Records a loss for the country.
    /// </summary>
    void AddLoss();

    /// <summary>
    /// Records a win for the country.
    /// </summary>
    void AddWin();

    /// <summary>
    /// Records a draw for the country.
    /// </summary>
    void AddDraw();

    /// <summary>
    /// Adds a goal for to the country's goals.
    /// </summary>
    void AddGoalFor(int goals = 1);

    /// <summary>
    /// Adds a goal against to the country's goals against.
    /// </summary>
    void AddGoalAgainst(int goals = 1);
}