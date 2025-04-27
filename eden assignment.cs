
using System;
using System.Collections.Generic;

public abstract class EmergencyUnit
{
    // Properties
    public string Name { get; set; }
    public int Speed { get; set; }

    // Constructor
    public EmergencyUnit(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    // Abstract Methods
    public abstract bool CanHandle(string incidentType);
    public abstract void RespondToIncident(Incident incident);
}

public class Police : EmergencyUnit
{
    // Constructor
    public Police(string name, int speed) : base(name, speed) { }

    // Overriding CanHandle method
    public override bool CanHandle(string incidentType) => incidentType == "Crime";

    // Overriding RespondToIncident method
    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is handling crime at {incident.Location}.");
    }
}

public class Firefighter : EmergencyUnit
{
    // Constructor
    public Firefighter(string name, int speed) : base(name, speed) { }

    // Overriding CanHandle method
    public override bool CanHandle(string incidentType) => incidentType == "Fire";

    // Overriding RespondToIncident method
    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is extinguishing fire at {incident.Location}.");
    }
}

public class Ambulance : EmergencyUnit
{
    // Constructor
    public Ambulance(string name, int speed) : base(name, speed) { }

    // Overriding CanHandle method
    public override bool CanHandle(string incidentType) => incidentType == "Medical";

    // Overriding RespondToIncident method
    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is treating patients at {incident.Location}.");
    }
}

public class Incident
{
    // Properties
    public string Type { get; set; }
    public string Location { get; set; }

    // Constructor
    public Incident(string type, string location)
    {
        Type = type;
        Location = location;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a list of emergency units
        List<EmergencyUnit> units = new List<EmergencyUnit>
        {
            new Police("Police Unit 1", 80),
            new Firefighter("Firefighter Unit 1", 70),
            new Ambulance("Ambulance Unit 1", 90)
        };

        // Incident types and locations
        string[] incidentTypes = { "Crime", "Fire", "Medical" };
        string[] locations = { "City Hall", "Central Park", "Main Street", "River Side", "Downtown" };
        Random rand = new Random();
        int score = 0;

        // Game loop for 5 rounds
        for (int round = 1; round <= 5; round++)
        {
            Console.WriteLine($"\n-- Turn {round} ---");

            // Generate a random incident type and location
            string incidentType = incidentTypes[rand.Next(incidentTypes.Length)];
            string location = locations[rand.Next(locations.Length)];
            Incident incident = new Incident(incidentType, location);

            // Display the incident information
            Console.WriteLine($"Incident: {incident.Type} at {incident.Location}");

            bool handled = false;

            // Find and use the correct unit to handle the incident
            foreach (var unit in units)
            {
                if (unit.CanHandle(incident.Type))
                {
                    unit.RespondToIncident(incident);
                    score += 10;
                    handled = true;
                    Console.WriteLine("+10 points");
                    break;
                }
            }

            // If no unit is available to handle the incident
            if (!handled)
            {
                Console.WriteLine("No available unit to handle this incident.");
                score -= 5;
                Console.WriteLine("-5 points");
            }

            // Display the current score
            Console.WriteLine($"Current Score: {score}");
        }

        // Display the final score after 5 rounds
        Console.WriteLine($"\nFinal Score: {score}");
    }
}
