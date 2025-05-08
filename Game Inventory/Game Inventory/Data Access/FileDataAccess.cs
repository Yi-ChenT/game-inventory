/*
* FILE : FileDataAccess.cs
* PROJECT : PROG1385 - Assignment 6
* PROGRAMMER : YI-CHEN TSAI Student
* FIRST VERSION : 2025-03-19
* CLASS NAME: FileDataAccess
* PURPOSE : This class provides a concrete implementation for reading and writing game data from/to CSV files as part of the Data Access layer
*/


using System.Collections.Generic;
using System.IO;


namespace GameInventory
{
    public class FileDataAccess : DAL
    {
        // Declare a constant to store the maximum number of game headers
        private const int maxNumberOfGameHeaders = 5;

        /* 
          METHOD: ParseData
          DESCRIPTION: Helper method that converts lines into a list of GameTitle objects
          PARAMETERS:
               string[] lines: Array of lines to be parsed
          RETURNS: List<GameTitle>: A list of GameTitle objects parsed from the lines
        */
        private List<GameTitle> ParseData(string[] lines)
        {
            // Create a new list to store the parsed GameTitle objects
            List<GameTitle> list = new List<GameTitle>();

            // Iterate over each line in the input array
            foreach (string line in lines)
            {
                // Check if the line is null or contains only whitespace and skip it if true
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Split the line by commas into an array of parts
                string[] parts = line.Split(',');

                // Check if the number of parts matches the expected header count and skip the line if not
                if (parts.Length != maxNumberOfGameHeaders)
                    continue;

                // Attempt to parse the first part as an integer for the game ID; skip the line if conversion fails
                if (!int.TryParse(parts[0], out int id))
                    continue;

                // Store the second part as the game title
                string title = parts[1];

                // Store the third part as the manufacturer
                string manufacturer = parts[2];

                // Attempt to parse the fourth part as a decimal for the list price; skip the line if conversion fails
                if (!decimal.TryParse(parts[3], out decimal listPrice))
                    continue;

                // Attempt to parse the fifth part as an integer for the stock; skip the line if conversion fails
                if (!int.TryParse(parts[4], out int stock))
                    continue;

                // Create a new GameTitle object with the parsed values and add it to the list
                list.Add(new GameTitle(id, title, manufacturer, listPrice, stock));
            }

            // Return the list of parsed GameTitle objects
            return list;
        }

        /* 
          METHOD: LoadData
          DESCRIPTION: Loads game data from a file and returns a list of GameTitle objects
          PARAMETERS:
               string filename: The name of the file to load data from
          RETURNS: List<GameTitle>: A list of GameTitle objects loaded from the file
        */
        public override List<GameTitle> LoadData(string filename)
        {
            // Read all lines from the specified file into a string array
            string[] lines = File.ReadAllLines(filename);

            // Parse the lines into a list of GameTitle objects and return the list
            return ParseData(lines);
        }

        /* 
          METHOD: TransformData
          DESCRIPTION: Helper method that transforms the list of games into format
          PARAMETERS:
               List<GameTitle> games: The list of GameTitle objects to be transformed
          RETURNS: string: A formatted string representing the game data
        */
        private string TransformData(List<GameTitle> games)
        {
            // Initialize an empty string to accumulate the data
            string theData = "";

            // Iterate over each GameTitle in the list
            foreach (GameTitle game in games)
            {
                // Append the game details in format followed by a newline character
                theData += $"{game.Id},{game.Title},{game.Manufacturer},{game.ListPrice},{game.Stock}\n";
            }

            // Return the constructed formatted string
            return theData;
        }

        /* 
          METHOD: SaveData
          DESCRIPTION: Saves game data to a file
          PARAMETERS:
               string filename: The name of the file to save data to
               List<GameTitle> games: The list of GameTitle objects to save
          RETURNS: None
        */
        public override void SaveData(string filename, List<GameTitle> games)
        {
            // Transform the list of games into a formatted string
            string theData = TransformData(games);

            // Write the formatted string to the specified file
            File.WriteAllText(filename, theData);
        }
    }
}
