using System;
using System.Collections.Generic;
using System.IO;

namespace GameInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the repository to manage game data
            Operations repository = new Operations();
            // Create an instance of FileDataAccess for reading/writing CSV files
            FileDataAccess dataAccess = new FileDataAccess();
            // Declare a bool variable to control the main loop execution
            bool run = true;

            // Main loop: execute the program until the user chooses to exit
            while (run)
            {
                try
                {
                    // Display the main menu to the user
                    GameInventoryView.DisplayMenu();
                    // Get user's choice from input
                    string choice = GameInventoryView.GetInput("Enter your choice: ");
                    Console.WriteLine();

                    // Process user's choice using a switch statement
                    switch (choice)
                    {
                        case "1":
                            // Call the OptionLoadData method
                            OptionLoadData(repository, dataAccess);
                            break;
                        case "2":
                            // Call the OptionSaveData method
                            OptionSaveData(repository, dataAccess);
                            break;
                        case "3":
                            // Call the OptionAddGame method
                            OptionAddGame(repository);
                            break;
                        case "4":
                            // Call the OptionRemoveGame method
                            OptionRemoveGame(repository);
                            break;
                        case "5":
                            // Call the OptionIncreaseStock method
                            OptionIncreaseStock(repository);
                            break;
                        case "6":
                            // Call the OptionDecreaseStock method
                            OptionDecreaseStock(repository);
                            break;
                        case "7":
                            // Call the OptionListGames method
                            OptionListGames(repository);
                            break;
                        case "8":
                            // Set run to false to exit the program
                            run = false;
                            // Display a goodbye message
                            GameInventoryView.DisplayMessage("Thank you for using, have a good day!");
                            break;
                        default:
                            throw new ArgumentException("Invalid input. Please try again");
                    }
                }
                catch (Exception ex)
                {
                    // Display the exception message to the user
                    GameInventoryView.DisplayError(ex.Message);
                }
            }
        }

        /* 
          METHOD: OptionLoadData
          DESCRIPTION: Loads inventory data from a file and updates the repository. Checks if the file exists before attempting to load data
          PARAMETERS:
               Operations repository: The game repository instance
               FileDataAccess dataAccess: The file data access instance
          RETURNS: None
        */
        static void OptionLoadData(Operations repository, FileDataAccess dataAccess)
        {
            // Prompt user for the filename to load
            string filename = GameInventoryView.GetInput("Enter the filename to load: ");
            // Check if the file exists; if not, throw an exception
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("File not found");
            }
            // If repository already contains games, confirm if user wants to overwrite
            if (repository.GetAllGames().Count > 0)
            {
                string confirm = GameInventoryView.GetInput("Loading new data will clear current data. Do you want to continue? (Y/N): ");
                // Convert input to uppercase and compare; if not "Y", throw an exception
                if (confirm.ToUpper() != "Y")
                {
                    throw new OperationCanceledException("Operation cancelled");
                }
            }
            // Load game data from file
            List<GameTitle> newData = dataAccess.LoadData(filename);
            // Check if newData is null; if so, throw an exception
            if (newData == null)
            {
                throw new Exception("Failed to load data from file");
            }
            // Update the repository with the new data
            repository.SetData(newData);
            // Display a success message to the user
            GameInventoryView.DisplayMessage("Successfully loaded the data");
        }

        /* 
          METHOD: OptionSaveData
          DESCRIPTION: Saves the current inventory data from the repository to a file. Checks if the filename is valid and prompts for overwrite if necessary
          PARAMETERS:
               Operations repository: The game repository instance
               FileDataAccess dataAccess: The file data access instance
          RETURNS: None
        */
        static void OptionSaveData(Operations repository, FileDataAccess dataAccess)
        {
            // Prompt user for the filename to save data
            string filename = GameInventoryView.GetInput("Enter the filename to save: ");
            // Check if the filename is null or empty; if so, throw an exception
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentException("Filename cannot be empty");
            }
            // Check if the file already exists; if so, prompt for confirmation
            if (File.Exists(filename))
            {
                string confirm = GameInventoryView.GetInput("File already exists. Do you want to overwrite? (Y/N): ");
                if (confirm.ToUpper() != "Y")
                {
                    throw new OperationCanceledException("Operation cancelled");
                }
            }
            // Save game data to the specified file
            dataAccess.SaveData(filename, repository.GetAllGames());
            // Display a success message to the user
            GameInventoryView.DisplayMessage("Successfully saved the data");
        }

        /* 
          METHOD: OptionAddGame
          DESCRIPTION: Adds a new game to the repository based on user input
          PARAMETERS:
               Operations repository: The game repository instance
          RETURNS: None
        */
        static void OptionAddGame(Operations repository)
        {
            // Prompt for the game ID and validate input
            if (!int.TryParse(GameInventoryView.GetInput("Enter the game ID: "), out int id))
            {
                throw new FormatException("Invalid game ID input");
            }
            // Prompt for the game title
            string title = GameInventoryView.GetInput("Enter the game title: ");
            // Prompt for the manufacturer
            string manufacturer = GameInventoryView.GetInput("Enter the manufacturer: ");
            // Prompt for the price and validate input
            if (!decimal.TryParse(GameInventoryView.GetInput("Enter the price: "), out decimal listPrice))
            {
                throw new FormatException("Invalid price input");
            }
            // Prompt for the stock count and validate input
            if (!int.TryParse(GameInventoryView.GetInput("Enter the number of stocks: "), out int stock))
            {
                throw new FormatException("Invalid stock input");
            }
            // Call AddGame and capture the result
            bool added = repository.AddGame(new GameTitle(id, title, manufacturer, listPrice, stock));
            if (!added)
            {
                throw new InvalidOperationException("The game already exists");
            }
            GameInventoryView.DisplayMessage("Successfully added a game");
        }

        /* 
          METHOD: OptionRemoveGame
          DESCRIPTION: Removes a game from the repository by ID or title based on user input
          PARAMETERS:
               Operations repository: The game repository instance
          RETURNS: None
        */
        static void OptionRemoveGame(Operations repository)
        {
            // Prompt user for game ID or title to remove
            string input = GameInventoryView.GetInput("Enter game ID or Title to remove: ");
            bool removed = false;
            if (int.TryParse(input, out int id))
            {
                removed = repository.RemoveGame(id);
            }
            else
            {
                removed = repository.RemoveGame(input);
            }
            if (!removed)
            {
                throw new InvalidOperationException("Game not found");
            }
            GameInventoryView.DisplayMessage("Successfully removed a game");
        }

        /* 
          METHOD: OptionIncreaseStock
          DESCRIPTION: Increases the stock quantity of a specific game based on user input
          PARAMETERS:
               Operations repository: The game repository instance
          RETURNS: None
        */
        static void OptionIncreaseStock(Operations repository)
        {
            // Prompt for the game ID to increase stock and validate input
            if (!int.TryParse(GameInventoryView.GetInput("Enter the game ID to increase stock: "), out int id))
            {
                throw new FormatException("Invalid game ID input");
            }
            // Prompt for the amount to increase and validate input
            if (!int.TryParse(GameInventoryView.GetInput("Enter the amount to increase: "), out int amount))
            {
                throw new FormatException("Invalid amount input");
            }
            bool success = repository.IncreaseStock(id, amount);
            if (!success)
            {
                throw new InvalidOperationException("Game not found");
            }
            GameInventoryView.DisplayMessage("Successfully increased stock");
        }

        /* 
          METHOD: OptionDecreaseStock
          DESCRIPTION: Decreases the stock quantity of a specific game based on user input
          PARAMETERS:
               Operations repository: The game repository instance
          RETURNS: None
        */
        static void OptionDecreaseStock(Operations repository)
        {
            // Prompt for the game ID to decrease stock and validate input
            if (!int.TryParse(GameInventoryView.GetInput("Enter the game ID to decrease stock: "), out int id))
            {
                throw new FormatException("Invalid game ID input");
            }
            // Prompt for the amount to decrease and validate input
            if (!int.TryParse(GameInventoryView.GetInput("Enter the amount to decrease: "), out int amount))
            {
                throw new FormatException("Invalid amount input");
            }
            bool success = repository.DecreaseStock(id, amount);
            if (!success)
            {
                throw new InvalidOperationException("Game not found");
            }
            GameInventoryView.DisplayMessage("Successfully decreased stock");
        }

        /* 
          METHOD: OptionListGames
          DESCRIPTION: Displays a list of all games in the repository along with the total inventory value
          PARAMETERS:
               Operations repository: The game repository instance
          RETURNS: None
        */
        static void OptionListGames(Operations repository)
        {
            // Retrieve all game entries from the repository
            List<GameTitle> games = repository.GetAllGames();
            if (games.Count == 0)
            {
                GameInventoryView.DisplayMessage("No game data available");
                return;
            }
            // Display table header with proper formatting
            Console.WriteLine($"{"ID",-5} {"Title",-30} {"Manufacturer",-20} {"List Price",-12} {"Stock",-8}");
            Console.WriteLine(new string('-', 100));
            // Iterate through each game and display its information
            foreach (var game in games)
            {
                Console.WriteLine(game.ToString());
            }
            Console.WriteLine(new string('-', 100));
            // Calculate and display the total inventory value
            decimal totalValue = repository.CalculateTotalValue();
            Console.WriteLine($"Total Inventory Value: {totalValue}");
        }
    }
}
