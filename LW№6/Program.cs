using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class Flight
{
    public string FlightNumber { get; set; }
    public string Airline { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public string Gate { get; set; }
    public FlightStatus Status { get; set; }
    public TimeSpan Duration { get; set; }
    public string AircraftType { get; set; }
    public string Terminal { get; set; }
}

public enum FlightStatus
{
    OnTime,
    Delayed,
    Cancelled,
    Boarding,
    InFlight
}

public class FlightInformationSystem
{
    private List<Flight> flights = new List<Flight>();

    public void LoadFlightsFromJson(string jsonFilePath)
    {
        try
        {
            string jsonContent = File.ReadAllText(jsonFilePath);
            var flightsData = JsonConvert.DeserializeObject<FlightData>(jsonContent);

            if (flightsData != null && flightsData.Flights != null)
            {
                flights.AddRange(flightsData.Flights);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading flights data: {ex.Message}");
        }
    }

    public void DisplayFlightsCount()
    {
        Console.WriteLine($"Total number of flights: {flights.Count}");
    }

    public string GetFlightsByAirlineJson(string airline)
    {
        List<Flight> matchingFlights = flights.FindAll(f => f.Airline == airline).OrderBy(f => f.DepartureTime).ToList();
        Console.WriteLine($"Total number of {airline} flights: {matchingFlights.Count}");

        // Serialization of the list of flights into JSON format
        string jsonContent = JsonConvert.SerializeObject(matchingFlights, Formatting.Indented);
        return jsonContent;
    }

    public string GetDelayedFlightsJson()
    {
        List<Flight> matchingFlights = flights.FindAll(f => f.Status == FlightStatus.Delayed).OrderBy(f => f.DepartureTime).ToList();
        Console.WriteLine($"Total number of delayed flights: {matchingFlights.Count}");

        // Serialization of the list of flights into JSON format
        string jsonContent = JsonConvert.SerializeObject(matchingFlights, Formatting.Indented);
        return jsonContent;
    }

    public string GetFlightsByDepartureDayJson(DateTime departureDay)
    {
        List<Flight> matchingFlights = flights
            .FindAll(f => f.DepartureTime.Date == departureDay.Date)
            .OrderBy(f => f.DepartureTime)
            .ToList();

        Console.WriteLine($"Total number of flights on {departureDay.ToShortDateString()}: {matchingFlights.Count}");

        // Serialization of the list of flights into JSON format
        string jsonContent = JsonConvert.SerializeObject(matchingFlights, Formatting.Indented);
        return jsonContent;
    }

    public string GetFlightsByTimeRangeAndDestinationJson(DateTime startTime, DateTime endTime, string destination)
    {
        List<Flight> matchingFlights = flights
            .FindAll(f => f.DepartureTime >= startTime && f.DepartureTime <= endTime && f.Destination == destination)
            .OrderBy(f => f.DepartureTime)
            .ToList();

        Console.WriteLine($"Total number of flights from {startTime} to {endTime} with destination {destination}: {matchingFlights.Count}");

        // Serialization of the list of flights into JSON format
        string jsonContent = JsonConvert.SerializeObject(matchingFlights, Formatting.Indented);
        return jsonContent;
    }

    public string GetFlightsArrivedInTimeRangeJson(DateTime startTime, DateTime endTime)
    {
        List<Flight> matchingFlights = flights
            .FindAll(f => f.ArrivalTime >= startTime && f.ArrivalTime <= endTime)
            .OrderBy(f => f.ArrivalTime)
            .ToList();

        Console.WriteLine($"Total number of flights arrived from {startTime} to {endTime}: {matchingFlights.Count}");

        // Serialization of the list of flights into JSON format
        string jsonContent = JsonConvert.SerializeObject(matchingFlights, Formatting.Indented);
        return jsonContent;
    }

    private class FlightData
    {
        public List<Flight> Flights { get; set; }
    }
}

class Program
{
    static void Main()
    {
        FlightInformationSystem flightSystem = new FlightInformationSystem();
        flightSystem.LoadFlightsFromJson(@"D:\\Download\flights_data.json");

        flightSystem.DisplayFlightsCount();

        string wizAirFlightsJson = flightSystem.GetFlightsByAirlineJson("WizAir");
        Console.WriteLine("WizAir flights:\n" + wizAirFlightsJson);

        string delayedFlights = flightSystem.GetDelayedFlightsJson();
        Console.WriteLine("Delayed flights:\n" + delayedFlights);

        DateTime departureDay = new DateTime(2023, 11, 11);
        string flightsForSpecificDay = flightSystem.GetFlightsByDepartureDayJson(departureDay);
        Console.WriteLine($"Flights for {departureDay.ToShortDateString()} sorted by departure time:\n{flightsForSpecificDay}");

        DateTime startTime = new DateTime(2023, 01, 01, 00, 00, 01);
        DateTime endTime = new DateTime(2023, 01, 31, 23, 59, 59);
        string destination = "Berlin";

        string berlinFlights = flightSystem.GetFlightsByTimeRangeAndDestinationJson(startTime, endTime, destination);
        Console.WriteLine($"Flights from {startTime} to {endTime} with destination {destination}:\n{berlinFlights}");

        DateTime startTimeArrival = new DateTime(2023, 05, 01, 00, 00, 00);
        DateTime endTimeArrival = new DateTime(2023, 05, 31, 23, 59, 59);

        string flightsArrivedInRange = flightSystem.GetFlightsArrivedInTimeRangeJson(startTimeArrival, endTimeArrival);
        Console.WriteLine($"Flights arrived from {startTimeArrival} to {endTimeArrival}:\n{flightsArrivedInRange}");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}