using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using SportRadar.WorldCupFootball;
using SportRadar.WorldCupFootball.Implementation;

ServiceCollection services = new();
services.AddWorldCupFootball();

using ServiceProvider provider = services.BuildServiceProvider();
var group = provider.GetRequiredService<IGroup>();

group.AddCountry(new Country("England", "ENG"));
group.AddCountry(new Country("Brazil", "BRA"));
group.AddCountry(new Country("France", "FRA"));
group.AddCountry(new Country("Germany", "GER"));
group.AddCountry(new Country("Italy", "ITA"));
group.AddCountry(new Country("Spain", "ESP"));
group.AddCountry(new Country("Argentina", "ARG"));
group.AddCountry(new Country("Portugal", "POR"));


Random random = new();
while (true)
{
    Table table = new();
    table.AddColumn("Home");
    table.AddColumn("Away");
    
    foreach (var match in group.Mix())
    {
        if (random.Next(0, 2) == 1)
        {
            if (random.Next(0, 2) == 1)
            {
                match.HomeGoal();
            }

            if (random.Next(0, 2) == 1)
            {
                match.AwayGoal();
            }
        }

        if (match.HomeScore > match.AwayScore)
        {
            match.Home.AddWin();
            match.Away.AddLoss();
        }
        else if (match.HomeScore < match.AwayScore)
        {
            match.Home.AddLoss();
            match.Away.AddWin();
        }
        else
        {
            match.Home.AddDraw();
            match.Away.AddDraw();
        }

        table.AddRow(match.Home.Name + " [red on grey underline] " + match.HomeScore + " [/]",
            match.Away.Name + " [red on grey underline] " + match.AwayScore + " [/]");
    }
    AnsiConsole.Write(table);
    await Task.Delay(1000);
    Console.Clear();
}

