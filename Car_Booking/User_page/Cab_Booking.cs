using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Spectre.Console;

namespace User_page
{
    public class Cab_Booking
    {
        SqlConnection con = new SqlConnection("server=IN-333K9S3;database=cab_booking;Integrated Security = true");
        
        public static void view_cars()
        {
            SqlConnection con = new SqlConnection("server=IN-333K9S3;database=cab_booking;Integrated Security = true");
            string query = $"select * from car";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            int res = adapter.Fill(ds);

            var table = new Table();
            table.AddColumn("Car ID");
            table.AddColumn("Model");
            table.AddColumn("Size");
            table.AddColumn("Driver ID");
            table.Title("[underline rgb(131,111,255)]CARS DETAILS[/]");
            table.BorderColor(Color.LightSlateGrey);
            foreach (var column in table.Columns)
            {
                column.Centered();
            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                table.AddRow(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString(), ds.Tables[0].Rows[i][3].ToString());
            }
            AnsiConsole.Write(table);
        }

        public static void view_driver_details(int driver_id)
        {
            SqlConnection con = new SqlConnection("server=IN-333K9S3;database=cab_booking;Integrated Security = true");
            string query = $"select * from driver_details where driver_id = {driver_id}";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            int res = adapter.Fill(ds);

            var table = new Table();
            table.AddColumn("driver_id");
            table.AddColumn("name");
            table.AddColumn("age");
            table.AddColumn("contact");
            table.AddColumn("gender");
            table.Title("[underline rgb(131,111,255)]Driver DETAILS[/]");
            table.BorderColor(Color.LightSlateGrey);
            foreach (var column in table.Columns)
            {
                column.Centered();
            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                table.AddRow(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString(), ds.Tables[0].Rows[i][3].ToString(), ds.Tables[0].Rows[i][4].ToString());
            }
            AnsiConsole.Write(table);
        }
        public void book_ride(int user_id) 
        {

            AnsiConsole.MarkupLine("[blue]Select Car by ID from the list:[/]");
            Cab_Booking.view_cars();
            int car_id = AnsiConsole.Ask<int>("Enter the car ID:");
            string source = AnsiConsole.Ask<string>("Enter souce:");
            string destination = AnsiConsole.Ask<string>("Enter destination");
            string res = AnsiConsole.Ask<string>("[yellow]Do u want see the driver details?(y/n)[/]");
            if(res.ToLower() == "y")
            {
                int driver_id = AnsiConsole.Ask<int>("[yellow]Enter the driver ID:[/]");
                Cab_Booking.view_driver_details(driver_id);
            }
            string result = AnsiConsole.Ask<string>("[yellow]Do you want to book the ride?(y/n)[/]");

            if(result.ToLower() == "y")
            {
                string query = "select * from ride";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                var row = ds.Tables[0].NewRow();
                row["user_id"] = user_id;
                row["car_id"] = car_id;
                row["source"] = source;
                row["destination"] = destination;
                row["status"] = "Booked";
                ds.Tables[0].Rows.Add(row);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
                AnsiConsole.MarkupLine("[green]Cab Booked Successfully with estimated Fare[/] [blue]350/-[/]");
                AnsiConsole.MarkupLine("[blue]Waiting for Accepting[/]");
            }
            else
            {
                return;
            }
        }

        public void booking_status(int user_id)
        {
            string query = $"select * from ride where user_id = {user_id}";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            var table = new Table();
            table.AddColumn("Ride ID");
            table.AddColumn("User ID");
            table.AddColumn("Car ID");
            table.AddColumn("Source");
            table.AddColumn("Destination");
            table.AddColumn("Status");
            table.Title("[underline rgb(131,111,255)]CARS DETAILS[/]");
            table.BorderColor(Color.LightSlateGrey);
            foreach (var column in table.Columns)
            {
                column.Centered();
            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                table.AddRow(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString(), ds.Tables[0].Rows[i][3].ToString(), ds.Tables[0].Rows[i][4].ToString(), ds.Tables[0].Rows[i][5].ToString());
            }
            AnsiConsole.Write(table);
        }
    }
}
