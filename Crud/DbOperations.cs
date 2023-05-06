using CodingTracker.Model;
using ConsoleTableExt;
using Microsoft.Data.Sqlite;

namespace CodingTracker.Crud
{
    public class DbOperations {

        public DbOperations() {
            connection = DbManagement.GetConnection();
            CreateTable();
        }

        static SqliteConnection connection;


        private void CreateTable() {
            DbManagement.CreateTable();
        }

        public void AddEntry(CodingSession session) {
            using (connection) {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    $"INSERT INTO time_tracking (startTime, endTime, duration)" +
                    $"VALUES ('{session.StartTime}', '{session.EndTime}', '{session.Duration}')";

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void GetSessions() {

            var tableData = new List<CodingSession>();

            using (connection) {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    $"SELECT id, startTime as start, endTime as end from time_tracking";

                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        
                        var id = reader.GetString(0);
                        var start = reader.GetString(1);
                        var end = reader.GetString(2);

                        CodingSession session = new CodingSession(id, start, end);
                        
                        tableData.Add(session);                
                    }
                    ConsoleTableBuilder.From(tableData).ExportAndWriteLine();
                }
                connection.Close();
            }
        }
    }
}
