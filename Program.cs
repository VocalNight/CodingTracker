using System.Configuration;
using System.Collections.Specialized;
using System;
using CodingTracker.Crud;
using CodingTracker.Model;

DbOperations operations = new DbOperations();
CodingSession session = null;
operations.

Console.WriteLine("haha");











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