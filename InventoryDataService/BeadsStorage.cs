using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sql;
namespace InventoryDataService
{
    public class BeadsStorage
    {
        // JSON file paths
        //private const string BeadsFileJson = "beadStocks.json";
        //private const string CharmsFileJson = "charmStocks.json";

        // TXT file paths (commented out)
        // private const string BeadsFileTxt = "beadStocks.txt";
        // private const string CharmsFileTxt = "charmStocks.txt";

        private static readonly string connectionString = "Data Source = LAPTOP-9O352VAE\\SQLEXPRESS; Initial Catalog = charmBeads; Integrated Security = True; TrustServerCertificate = True;";

        public static List<string> Beads()
        {
            return LoadBeads();
        }

        private static List<string> LoadBeads()
        {
            // JSON loading
            //if (File.Exists(BeadsFileJson))
            //{
            //    var json = File.ReadAllText(BeadsFileJson);
            //    return JsonSerializer.Deserialize<List<string>>(json);
            //}

            //// TXT loading (commented out)
            //// return File.Exists(BeadsFileTxt) ? new List<string>(File.ReadAllLines(BeadsFileTxt)) : new List<string>();
            //return new List<string>();

            List<string> beads = new();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Name, Quantity FROM BeadStocks", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    beads.Add($"{reader["Name"]}: {reader["Quantity"]}");
                }
                conn.Close();   
            }
            return beads;
        }

        public static List<string> Charms()
        {
            return LoadCharms();
        }

        public static List<string> LoadCharms()
        {
            //// JSON loading
            //if (File.Exists(CharmsFileJson))
            //{
            //    var json = File.ReadAllText(CharmsFileJson);
            //    return JsonSerializer.Deserialize<List<string>>(json);
            //}

            //// TXT loading (commented out)
            //// return File.Exists(CharmsFileTxt) ? new List<string>(File.ReadAllLines(CharmsFileTxt)) : new List<string>();
            //return new List<string>();

            List<string> charms = new();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Name, Quantity FROM CharmStocks", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    charms.Add($"{reader["Name"]}: {reader["Quantity"]}");
                }
                conn.Close();
            }
            return charms;

        }

        public static void SaveBeads(List<string> beads)
        {
            //// JSON saving
            //var json = JsonSerializer.Serialize(beads, new JsonSerializerOptions { WriteIndented = true });
            //File.WriteAllText(BeadsFileJson, json);

            //// TXT saving (commented out)
            //// File.WriteAllLines(BeadsFileTxt, beads);

            using var conn = new SqlConnection(connectionString);
            conn.Open();
            new SqlCommand("DELETE FROM BeadStocks", conn).ExecuteNonQuery();

            foreach (var bead in beads)
            {
                var parts = bead.Split(':');
                string name = parts[0].Trim();
                int qty = int.Parse(parts[1].Trim());

                var cmd = new SqlCommand("INSERT INTO BeadStocks (Name, Quantity) VALUES (@name, @qty)", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.ExecuteNonQuery();
            }

            conn.Close(); 
        }


        public static void SaveCharms(List<string> charms)
        {
            //// JSON saving
            //var json = JsonSerializer.Serialize(charms, new JsonSerializerOptions { WriteIndented = true });
            //File.WriteAllText(CharmsFileJson, json);

            //// TXT saving (commented out)
            //// File.WriteAllLines(CharmsFileTxt, charms);

            using var conn = new SqlConnection(connectionString);
            conn.Open();
            new SqlCommand("DELETE FROM CharmStocks", conn).ExecuteNonQuery();

            foreach (var charm in charms)
            {
                var parts = charm.Split(':');
                string name = parts[0].Trim();
                int qty = int.Parse(parts[1].Trim());

                var cmd = new SqlCommand("INSERT INTO CharmStocks (Name, Quantity) VALUES (@name, @qty)", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.ExecuteNonQuery();
            }

            conn.Close();

        }
    }
}