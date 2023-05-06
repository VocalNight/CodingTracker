using System.Configuration;
using System.Collections.Specialized;
using System;
using CodingTracker.Crud;
using CodingTracker.Model;
using System.Globalization;

DbOperations operations = new DbOperations();


GetMainInput();

/*
    DateTime.ParseExact("25-12-2023 12-, "dd-MM-yyyy HH:mm", null);
} catch (Exception ex) {
    Console.Write(ex.ToString());
}

*/
void GetMainInput() {

    Console.Clear();
    bool isRunning = true;
    while (isRunning) {

        Console.WriteLine($@"What would you like to do:
    1 - Insert a new session
    0 - Exit the program");

        string op = Console.ReadLine();

        switch (op) {
            case "1":
                try {
                    InsertSession();
                } catch (Exception ex) {
                    DealWithError(ex);
                }
                break;
            case "0":
                Console.WriteLine("\nGoodbye");
                isRunning = false;
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }

        Console.WriteLine("-------------------------------------------\n");
    }
}

void DealWithError( Exception ex ) {
    Console.WriteLine(ex);
    Console.WriteLine("Something Went wrong! Check what you typed, you might have typed the something incorrectly!");
}

void InsertSession() {
    

    Console.WriteLine("\n--------------------------------\n Start Time");
    string dateStart = GetDateInput();

    string timeStart = GetTimeInput();

    Console.WriteLine("\n--------------------------------\n Finish Time");
    string dateEnd = GetDateInput();

    string timeEnd = GetTimeInput();

    CodingSession session = new CodingSession($"{dateStart} {timeStart}", $"{dateEnd} {timeEnd}");

    operations.AddEntry(session);
}

string GetTimeInput() {
    Console.WriteLine("\nPlease insert the time in the format HH:mm. Type 0 to return to the main menu");

    string timeInput = Console.ReadLine();

    if (timeInput == "0") {
        GetMainInput();
    }

    while (!DateTime.TryParseExact(timeInput, "HH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out _)) {
        Console.WriteLine("\nInvalid time. Type 0 to return to the main menu or try again:\n");
        timeInput = Console.ReadLine();
    }

    return timeInput;
}



string GetDateInput() {
    Console.WriteLine("\nPlease insert the date in the format dd-mm-yyyy. Type 0 to return to the main menu");

    string dateInput = Console.ReadLine();

    if (dateInput == "0") {
        GetMainInput();
    }

    while (!DateTime.TryParseExact(dateInput, "dd-MM-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out _)) {
        Console.WriteLine("\nInvalid date. Type 0 to return to the main menu or try again:\n");
        dateInput = Console.ReadLine();
    }

    return dateInput;
}



/* string sAttr;
sAttr = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

Console.WriteLine("The value of key0 is "+sAttr);

NameValueCollection sAll;
sAll = ConfigurationManager.AppSettings;

foreach (string s in sAll.AllKeys)
    Console.WriteLine("Key: "+ s + " Value: " + sAll.Get(s));
*/
/* try {
    var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    var settings = configFile.AppSettings.Settings;
    if (settings["Key4"] == null) {
        settings.Add("Key4", "test");
    } else {
        settings["Key1"].Value = "test";
    }

    configFile.Save(ConfigurationSaveMode.Modified);
    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
} catch (ConfigurationErrorsException) {
    Console.WriteLine("Error");
} */