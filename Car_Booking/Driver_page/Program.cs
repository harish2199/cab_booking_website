using Driver_page;
using Spectre.Console;

namespace Driver_page
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Login login = new Login();
            Ride ride = new Ride();

            AnsiConsole.Write(new FigletText("Welcome to Uber").Centered().Color(Color.DeepSkyBlue2));
            int res = 0;
            while (res == 0)
            {
                res = login.LoginUser();
            }

            Console.WriteLine();
            var rule = new Rule("[green]WELCOME UBER APP[/]");
            rule.Style = Style.Parse("red dim");
            AnsiConsole.Write(rule);

            while(res != 0)
            {
                Console.WriteLine();
                var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("[green]Select your choice :[/]")
                    .AddChoices(new[] {
                        "view rides",
                        "Accept ride",
                        "Reject ride"
                   }));

                switch(choice)
                {
                    case "view rides":
                        {
                            ride.view_Rides(); break;   
                        }
                    case "Accept ride":
                        {
                            ride.Accept_ride(); break;
                        }
                    case "Reject ride":
                        {
                            ride.Reject_ride(); break; 
                        }
                }
            }
        }
    }
}