using System;

namespace GameInventory 
{
    public static class GameInventoryView
    {
        /* 
          METHOD: DisplayMenu
          DESCRIPTION: Displays the main menu to the user
          PARAMETERS: None
          RETURNS: None
        */
        public static void DisplayMenu()
        {
            Console.WriteLine();
            // Print out the header to the screen
            Console.WriteLine("----- Game Inventory Management System -----");
            Console.WriteLine("1. Load data from file");
            Console.WriteLine("2. Save data to file");
            Console.WriteLine("3. Add a new game");
            Console.WriteLine("4. Remove a game");
            Console.WriteLine("5. Increase stock");
            Console.WriteLine("6. Decrease stock");
            Console.WriteLine("7. List all games");
            Console.WriteLine("8. Exit");
        }

        /* 
          METHOD: GetInput
          DESCRIPTION: Prompts the user for input and returns the entered string
          PARAMETERS:
               string prompt: The prompt message to display
          RETURNS: string: The user's input
        */
        public static string GetInput(string prompt)
        {
            // Display the prompt message
            Console.Write(prompt);
            // Read and return the user input
            return Console.ReadLine();
        }

        /* 
          METHOD: DisplayMessage
          DESCRIPTION: Displays a standard message to the console
          PARAMETERS:
               string message: The message to display
          RETURNS: None
        */
        public static void DisplayMessage(string message)
        {
            // Print message to the screen
            Console.WriteLine(message);
        }

        /* 
          METHOD: DisplayMessage (Overloaded)
          DESCRIPTION: Displays a message with a title to the console
          PARAMETERS:
               string title: The title to be displayed
               string message: The message to display
          RETURNS: None
        */
        public static void DisplayMessage(string title, string message)
        {
            // Print the title and message in a formatted string to the screen
            Console.WriteLine($"{title}: {message}");
        }

        /* 
          METHOD: DisplayError
          DESCRIPTION: Displays an error message to the console
          PARAMETERS:
               string errorMessage: The error message to display
          RETURNS: None
        */
        public static void DisplayError(string errorMessage)
        {
            // Print the error message to the screen
            Console.WriteLine("Error: " + errorMessage);
        }
    }
}
