namespace SportRadar.WorldCupFootball;

public interface ICountry
{
    string Name { get; }
    string Code { get; }
    float StrengthMultiplier { get; }
}

public interface IMatch
{
    ICountry Home { get; }
    ICountry Away { get; }
    int HomeScore { get; }
    int AwayScore { get; }
    
    void HomeGoal();
    void AwayGoal();
}

public interface IGroup
{
    string Name { get; }
    IGroup AddCountry(ICountry country);
    IEnumerable<IMatch> Mix();
}