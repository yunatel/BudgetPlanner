using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using BudgetPlanner.Models;

namespace BudgetPlanner.Services
{
    public class DBService
    {
        public DBService()
        {
            InitializeDB();
        }

        public async static void InitializeDB()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("operations.db", CreationCollisionOption.OpenIfExists);
            string pathToDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "operations.db");

            using (SqliteConnection connection = new SqliteConnection($"FileName={pathToDB}"))
            {
                connection.Open();
                string InitCMD = "CREATE TABLE IF NOT EXISTS " +
                    "operations ( " +
                    "operationDate string, " +
                    "operationSum float, " +
                    "operationType string, " +
                    "operationCategory string, " +
                    "operationComment string )";
                SqliteCommand CMDcreateTable = new SqliteCommand(InitCMD, connection);
                CMDcreateTable.ExecuteReader();
                connection.Close();
            }
        }

        public static void addRecord(float sum, string type, string category, string comment)
        {
            if (sum != 0f)
            {
                string pathToDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "operations.db");
                using (SqliteConnection connection = new SqliteConnection($"Filename={pathToDB}"))
                {
                    connection.Open();
                    SqliteCommand CMD_Insert = new SqliteCommand();
                    CMD_Insert.Connection = connection;

                    CMD_Insert.CommandText = "INSERT INTO operations VALUES(@operationDate, @operationSum, @operationType, @operationCategory, @operationComment)";
                    CMD_Insert.Parameters.AddWithValue("@operationDate", DateTime.Now.ToString());
                    CMD_Insert.Parameters.AddWithValue("@operationSum", sum);
                    CMD_Insert.Parameters.AddWithValue("@operationType", type);
                    CMD_Insert.Parameters.AddWithValue("@operationCategory", category);
                    CMD_Insert.Parameters.AddWithValue("@operationComment", comment);

                    CMD_Insert.ExecuteReader();

                    connection.Close();
                }
            }
        }

        public static List<SampleOperation> GetRecords()
        {
            List<SampleOperation> records = new List<SampleOperation>();
            string pathToDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "operations.db");

            using (SqliteConnection connection = new SqliteConnection($"Filename={pathToDB}"))
            {
                connection.Open();
                String selectedCmd = "SELECT operationDate, operationSum, operationType, operationCategory, operationComment FROM operations";
                SqliteCommand cmd_getRec = new SqliteCommand(selectedCmd, connection);
                SqliteDataReader reader = cmd_getRec.ExecuteReader();

                while (reader.Read())
                {
                    records.Add(new SampleOperation(reader.GetString(0), reader.GetFloat(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                }
                connection.Close();
            }
            return records;
        }


    }
}
