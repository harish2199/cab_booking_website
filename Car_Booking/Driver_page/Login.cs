using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using System.Data.SqlClient;
using System.Data;

namespace Driver_page
{
    public class Login
    {
        SqlConnection con = new SqlConnection("server=IN-333K9S3;database=cab_booking;Integrated Security = true");
        public int LoginUser()
        {
            AnsiConsole.MarkupLine("[green]Please Enter the Login Details:[/]");

            string username = AnsiConsole.Ask<string>("[yellow]Enter UserName:[/]");
            string password = AnsiConsole.Ask<string>("[yellow]Enter Password:[/]");
            string query = $"select * from driver_details where username = '{username}' and password = '{password}'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                AnsiConsole.MarkupLine("[green]Login successfully!![/]");
                return count;
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Invalid username or password. Please try again.[/]");
                return 0;
            }
        }
    }
}
