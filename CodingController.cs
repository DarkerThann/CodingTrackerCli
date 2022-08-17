using Microsoft.Data.Sqlite;
using System;

namespace CodingTracker
{

    internal class CodingController
    {
        private readonly string connectionString = @"Data Source = CodingTracker.db";

        public void CheckIfTableExists()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var commandTable = connection.CreateCommand())
                {
                    connection.Open();

                    commandTable.CommandText =
                        @"
                            CREATE TABLE IF NOT EXISTS CodingTracker
                            (Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            StartTime TEXT, 
                            EndTime TEXT,
                            Duration TEXT)
                        ";

                    commandTable.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }

        public void GetAllCodingSession()
        {
            List<CodingSession> codingSessions = new List<CodingSession>();

            using (var connection = new SqliteConnection(connectionString))
            {
                using (var CommandTable = connection.CreateCommand())
                {
                    connection.Open();

                    CommandTable.CommandText =
                        @"
                            SELECT Id, StartTime, EndTime, Duration
                            FROM CodingTracker
                        ";

                    SqliteDataReader reader = CommandTable.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CodingSession coding = new CodingSession();


                            coding.Id = Convert.ToInt32(reader["Id"]);
                            coding.StartTime = DateTime.ParseExact((string)reader["StartTime"], "dd/MM/yyyy HH:mm:ss", null);
                            coding.EndTime = DateTime.ParseExact((string)reader["EndTime"], "dd/MM/yyyy HH:mm:ss", null);
                            coding.Duration = TimeSpan.Parse((string)reader["Duration"]);

                            codingSessions.Add(coding);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma sessão foi econtrada");
                    }

                    connection.Close();

                    foreach (var sessions in codingSessions)
                    {
                        Console.WriteLine($"ID: {sessions.Id} | StartTime: {sessions.StartTime} | EndTime: {sessions.EndTime} | Duration {sessions.Duration} |");
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                    }
                }
            }
        }

        public void CreateCodingSession()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var CommandTable = connection.CreateCommand())
                {
                    connection.Open();

                    CommandTable.CommandText =
                        @"
                            INSERT INTO CodingTracker (StartTime,EndTime, Duration) 
                            Values($StartTime, $EndTime, $Duration)
                        ";

                    CodingSession coding = CodingSession.GetInstance();

                    CommandTable.Parameters.AddWithValue("$StartTime", coding.StartTime.ToString());
                    CommandTable.Parameters.AddWithValue("$EndTime", coding.EndTime.ToString());
                    CommandTable.Parameters.AddWithValue("$Duration", coding.Duration.ToString());
                    CommandTable.ExecuteNonQuery();

                    connection.Close();
                }
            }

        }

        public void UpdateCodingSession()
        {
            using (var connection = new SqliteConnection(connectionString))
            {

                using (var CommandTable = connection.CreateCommand())
                {
                    connection.Open();

                    CommandTable.CommandText =
                            @"
                                UPDATE CodingTracker set StartTime = $StartTime, EndTime = $EndTime, Duration = $Duration
                                WHERE Id = $Id
                            ";

                    CodingSession coding = CodingSession.GetInstance();

                    CommandTable.Parameters.AddWithValue("$Id", coding.Id);
                    CommandTable.Parameters.AddWithValue("$StartTime", coding.StartTime.ToString());
                    CommandTable.Parameters.AddWithValue("$EndTime", coding.EndTime.ToString());
                    CommandTable.Parameters.AddWithValue("$Duration", coding.Duration.ToString());

                    CommandTable.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }

        public void DeleteCodingSession()
        {
            using (var connection = new SqliteConnection(connectionString))
            {

                using (var CommandTable = connection.CreateCommand())
                {
                    connection.Open();

                    CommandTable.CommandText =
                        @"
                            DELETE FROM CodingTracker
                            WHERE Id = $Id; 
                        ";

                    CodingSession coding = CodingSession.GetInstance();

                    CommandTable.Parameters.AddWithValue("$Id", coding.Id);

                    CommandTable.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
    }
}
