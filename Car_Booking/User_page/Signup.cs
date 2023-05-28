using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Spectre.Console;
using System.Data;


namespace User_page
{
    public class Signup
    {
        SqlConnection con = new SqlConnection("server=IN-333K9S3;database=cab_booking;Integrated Security = true");
        public bool SignUp_User()
        {
            AnsiConsole.MarkupLine("[green]Please Enter the Details to Signup:[/]");

            string firstname = AnsiConsole.Ask<string>("[yellow]Enter First Name:[/]");
            string lastname = AnsiConsole.Ask<string>("[yellow]Enter Last Name:[/]");
            string email = AnsiConsole.Ask<string>("[yellow]Enter Eamil ID:[/]");
            string contact = AnsiConsole.Ask<string>("[yellow]Enter Phone Number:[/]");
            string username = AnsiConsole.Ask<string>("[yellow]Enter username:[/]");
            string password = AnsiConsole.Ask<string>("[yellow]Enter Password:[/]");
            string confirmpassword = AnsiConsole.Ask<string>("[yellow]Enter Confirm Password:[/]");
            if (password != confirmpassword)
            {
                AnsiConsole.MarkupLine("[red]Confirm Password should be same as Password!![/]");
                return false;
            }

            string query = $"select * from user_details";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            var row = ds.Tables[0].NewRow();
            row["firstname"] = firstname;
            row["lastname"] = lastname;
            row["email"] = email;
            row["contact"] = contact;
            row["username"] = username;
            row["password"] = password;

            ds.Tables[0].Rows.Add(row);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(ds);
          
            AnsiConsole.MarkupLine($"[green]User Signup Successfully[/]");
            return true;
        }
    }
}
