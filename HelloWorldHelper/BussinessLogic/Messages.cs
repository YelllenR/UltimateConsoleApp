using HelloWorldHelper.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace HelloWorldHelper.BussinessLogic;


//The Messages class proceed to put a logger for messages, checks for languages and errors. 
public class Messages : IMessages
{
    private readonly ILogger<Messages> _log;

    public Messages(ILogger<Messages> log)
    {
        _log = log;
    }

    // Public helper methode
    public string Greeting(string language)
    {
        string output = LookUpCustomTextJson("Greeting", language);
        return output;
    }

    //Creating a private methode to look up the json file
    private string LookUpCustomTextJson(string key, string language)
    {
        //Removing case sensitive to get access to both style typed in json file and in this file.
        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        try
        {
            //Get the list of CustomTextJson from the file and if not null proceed to serialize and deserialize. 
            //In json file are camel case but in the code syntax is pascal case. 
            List<CustomTextJson>? messageSets = JsonSerializer.Deserialize<List<CustomTextJson>>
                (
                File.ReadAllText(path: "CustomTextJson.json"), options
                );

            //Search for the first language in the json file if not null (?)
            CustomTextJson? messages = messageSets?.Where(x => x.Language == language).First();

            //Doing an if statement to see if it exist and if not throw an exception message. 

            if (messages is null)
            {
                throw new NullReferenceException("The specified language was not found in the json file");
            }

            // After the check, return the value of the translation in the json file.
            return messages.Translations[key];
        }
        catch (Exception exception)
        {
            _log.LogError("Error looking up the custom text", exception);
            throw;
        }
    }
}
