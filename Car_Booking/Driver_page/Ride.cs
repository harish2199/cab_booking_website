using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Spectre.Console;

namespace Driver_page
{
    public class Ride
    {
        SqlConnection con = new SqlConnection("server=IN-333K9S3;database=cab_booking;Integrated Security = true");
        public void view_Rides()
        {
            string query = $"select * from ride";
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

        public void Accept_ride()
        {
            string query = $"select * from ride";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            ds.Tables[0].Rows[0]["status"] = "Accepted";

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(ds);
        }

        public void Reject_ride()
        {
            string query = $"select * from ride";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            ds.Tables[0].Rows[0]["status"] = "Rejected";

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(ds);
        }
    }
}
