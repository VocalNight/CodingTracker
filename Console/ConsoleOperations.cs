using CodingTracker.Crud;
using CodingTracker.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Console {
    public class ConsoleOperations {

        public ConsoleOperations(DbOperations operation) { 
            operations = operation;
        }

        DbOperations operations;

        public void GetMainInput() {

            bool isRunning = true;
            while (isRunning) {

                System.Console.WriteLine($@"What would you like to do:
    1 - Insert a new session
    2 - Show sessions
    0 - Exit the program");

                string op = System.Console.ReadLine();

                switch (op) {
                    case "1":
                        try {
                            InsertSession();
                        } catch (Exception ex) {
                            DealWithError(ex);
                        }
                        break;
                    case "2":
                        GetAllSessions();
                        break;
                    case "0":
                        System.Console.WriteLine("\nGoodbye");
                        isRunning = false;
                        Environment.Exit(0);
                        break;
                    default:
                        System.Console.WriteLine("Invalid input");
                        break;
                }

                System.Console.WriteLine("-------------------------------------------\n");
            }
        }

        void InsertSession() {

            System.Console.WriteLine("\n--------------------------------\n Start Time");
            string dateStart = GetDateInput();

            string timeStart = GetTimeInput();

            System.Console.WriteLine("\n--------------------------------\n Finish Time");
            string dateEnd = GetDateInput();

            string timeEnd = GetTimeInput();

            System.Console.Clear();
            ValidateDates(dateStart, dateEnd);
            ValidateTime(timeStart, timeEnd);

            CodingSession session = new CodingSession("", $"{dateStart} {timeStart}", $"{dateEnd} {timeEnd}");

            operations.AddEntry(session);
        }

        void ValidateDates( string start, string end ) {
            var dateStart = DateTime.ParseExact(start, "dd-MM-yyyy", null);
            var dateEnd = DateTime.ParseExact(end, "dd-MM-yyyy", null);

            int difference = DateTime.Compare(dateStart, dateEnd);

            if (difference > 0) {
                System.Console.WriteLine("\n-----------\n");
                System.Console.WriteLine(@$"You inserted an invalid date pair. 
The end time ({dateEnd}) is earlier than the start time ({dateStart}), try again");
                System.Console.WriteLine("\n-----------\n");

                GetMainInput();
            }
        }

        void ValidateTime( string start, string end ) {
            var timeStart = DateTime.ParseExact(start, "HH:mm", null);
            var timeEnd = DateTime.ParseExact(end, "HH:mm", null);

            int difference = DateTime.Compare(timeStart, timeEnd);

            if (difference > 0) {
                System.Console.WriteLine("\n-----------\n");
                System.Console.WriteLine(@$"You inserted an invalid time pair. 
The end time ({timeEnd}) is earlier than the start time ({timeStart}), try again");
                System.Console.WriteLine("\n-----------\n");

                GetMainInput();
            }
        }
        string GetTimeInput() {
            System.Console.WriteLine("\nPlease insert the time in the format HH:mm. Type 0 to return to the main menu");

            string timeInput = System.Console.ReadLine();

            if (timeInput == "0") {
                GetMainInput();
            }

            while (!DateTime.TryParseExact(timeInput, "HH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out _)) {
                System.Console.WriteLine("\nInvalid time. Type 0 to return to the main menu or try again:\n");
                timeInput = System.Console.ReadLine();
            }

            return timeInput;
        }



        string GetDateInput() {
            System.Console.WriteLine("\nPlease insert the date in the format dd-mm-yyyy. Type 0 to return to the main menu");

            string dateInput = System.Console.ReadLine();

            if (dateInput == "0") {
                GetMainInput();
            }

            while (!DateTime.TryParseExact(dateInput, "dd-MM-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out _)) {
                System.Console.WriteLine("\nInvalid date. Type 0 to return to the main menu or try again:\n");
                dateInput = System.Console.ReadLine();
            }

            return dateInput;
        }

        void GetAllSessions() {
            operations.GetSessions();
        }

        void DealWithError( Exception ex ) {
            System.Console.WriteLine(ex);
            System.Console.WriteLine("Something Went wrong! Check what you typed, you might have typed the something incorrectly!");
        }

    }
}
