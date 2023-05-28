using User_page;
using Spectre.Console;

namespace User_page
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Signup signup = new Signup();
            Login login = new Login();
            Cab_Booking booking = new Cab_Booking();

            AnsiConsole.Write(new FigletText("Welcome to Uber").Centered().Color(Color.DeepSkyBlue2));
            string res = AnsiConsole.Ask<string>("Do you have any account?(y/n)");
            int user_id = 0;
            bool _sign_up = false;
            if (res.ToLower() == "y")
            {
                while (user_id == 0)
                {
                    user_id = login.LoginUser();
                }
            }
            else
            {
                while (!_sign_up)
                {
                    _sign_up = signup.SignUp_User();
                }
                while (user_id == 0)
                {
                    user_id = login.LoginUser();
                }
            }

            Console.WriteLine();
            var rule = new Rule("[green]WELCOME UBER APP[/]");
            rule.Style = Style.Parse("red dim");
            AnsiConsole.Write(rule);
            Console.WriteLine(user_id);
            while (user_id != 0)
            {
                Console.WriteLine();
                var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("[green]Select your choice :[/]")
                    .AddChoices(new[] {
                        "view cars for ride",
                        "Book ride",
                        "View status"
                   }));

                switch (choice)
                {
                    case "view cars for ride":
                        {
                            Cab_Booking.view_cars();
                            break;
                        }
                    case "Book ride":
                        {
                            booking.book_ride(user_id);
                            break;
                        }
                    case "View status":
                        {
                            booking.booking_status(user_id);
                            break;
                        }
                }
            }

        }
    }
}