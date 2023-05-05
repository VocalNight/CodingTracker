using CodingTracker.Model;
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

        public void DeleteEntry(CodingSession session) {
        }
    }
}
