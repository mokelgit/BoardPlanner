using Microsoft.Extensions.Options;
using ScrumApp.Models;
using ScrumApp.Services;

class Test
{
    public async Task Run()
    {
        // Set up the MongoDBSettings
        var mongoDBSettings = new MongoDBSettings
        {
            ConnectionURI = "mongodb+srv://maym2018:5Drk1xLLSr9st1L5@project.jm9cxak.mongodb.net/",
            DatabaseName = "planner",
        };
        // Instantiate MongoDBService
        var mongoDBService = new MongoDBService(Options.Create(mongoDBSettings));

        // Create a sample user
        var user = new User
        {
            User_Name = "Crombopulus"
        };

        try
        {
            // Insert the user into the database
            await mongoDBService.CreateAsync<User>("Users", user);
            System.Diagnostics.Debug.WriteLine("User Inserted Successfully");

            // Retrieve the list of users
            var users = await mongoDBService.GetAsync<User>("Users");
            System.Diagnostics.Debug.WriteLine("We pass");

            // Print the list of users
            foreach (var u in users)
            {
                System.Diagnostics.Debug.WriteLine($"Name: {u.User_Name}");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
        }
    }
}
