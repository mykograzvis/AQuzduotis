using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQuzduotis.Models;

namespace AQuzduotis.Tasks
{
    public class InOutUtils
    {
        public List<Harness> ReadDrawings()
        {
            List<Harness> drawings = new List<Harness>();
            string connectionString = "Data Source=AQ.db";
            var con = new SQLiteConnection(connectionString);
            con.Open();
            string query = "SELECT * FROM Harness_drawing";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("ID"));
                string harness = reader.GetString(reader.GetOrdinal("Harness"));
                string harness_version = reader.GetString(reader.GetOrdinal("Harness_version"));
                string drawing = reader.GetString(reader.GetOrdinal("Drawing"));
                string drawing_version = reader.GetString(reader.GetOrdinal("Drawing_version"));

                Harness temp = new Harness(id, harness, harness_version, drawing, drawing_version);
                drawings.Add(temp);
            }

            return drawings;
        }

        public List<Wires> ReadWires()
        {
            List<Wires> wires = new List<Wires>();
            string connectionString = "Data Source=AQ.db";
            var con = new SQLiteConnection(connectionString);
            con.Open();
            string query = "SELECT * FROM Harness_wires";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("ID"));
                int harness = reader.GetInt32(reader.GetOrdinal("Harness_ID"));
                float length = reader.GetFloat(reader.GetOrdinal("Length"));
                string color = reader.GetString(reader.GetOrdinal("Color"));
                string housing1 = reader.GetString(reader.GetOrdinal("Housing_1"));
                string housing2 = reader.GetString(reader.GetOrdinal("Housing_2"));

                Wires temp = new Wires(id, harness, length, color, housing1, housing2);
                wires.Add(temp);
            }

            return wires;
        }
    }
}
