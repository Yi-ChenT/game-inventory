using System;
using System.Collections.Generic;

namespace GameInventory
{
    public class Operations
    {
        // Declare a private List of GameTitle objects named Games
        private List<GameTitle> Games = new List<GameTitle>();

        /* 
          METHOD: AddGame
          DESCRIPTION: Adds a new game to the repository based on a GameTitle object
          PARAMETERS:
               GameTitle game: The game object to add
          RETURNS: bool: True if the game was added, false if a duplicate exists
        */
        public bool AddGame(GameTitle game)
        {
            // Iterate over each GameTitle object in the Games list
            foreach (GameTitle g in Games)
            {
                // Check if the current game's Id matches the new game's Id
                if (g.Id == game.Id)
                {
                    // Output an error message and return false if a duplicate is found
                    Console.WriteLine("The game already exists");
                    return false;
                }
            }
            // Add the game to the Games list and return true if no duplicate is found
            Games.Add(game);
            return true;
        }

        /* 
          METHOD: AddGame (Overloaded)
          DESCRIPTION: Creates and adds a new game to the repository using provided details
          PARAMETERS:
               int id: The game identifier
               string title: The title of the game
               string manufacturer: The manufacturer of the game
               decimal listPrice: The list price of the game
               int stock: The stock count of the game
          RETURNS: bool: True if the game was added, false if a duplicate exists
        */
        public bool AddGame(int id, string title, string manufacturer, decimal listPrice, int stock)
        {
            return AddGame(new GameTitle(id, title, manufacturer, listPrice, stock));
        }

        /* 
          METHOD: RemoveGame
          DESCRIPTION: Removes a game from the repository by its ID
          PARAMETERS:
               int id: The game identifier to remove
          RETURNS: bool: True if the game was removed, false if the game was not found
        */
        public bool RemoveGame(int id)
        {
            GameTitle theGame = null;
            // Iterate over each GameTitle object in the Games list
            foreach (GameTitle g in Games)
            {
                // Check if the current game's Id matches the specified id
                if (g.Id == id)
                {
                    theGame = g;
                    break;
                }
            }
            // If no matching game is found, output an error message and return false
            if (theGame == null)
            {
                return false;
            }
            // Remove the found game from the Games list and return true
            Games.Remove(theGame);
            return true;
        }

        /* 
          METHOD: RemoveGame (Overloaded)
          DESCRIPTION: Removes a game from the repository by its title
          PARAMETERS:
               string title: The title of the game to remove
          RETURNS: bool: True if the game was removed, false if the game was not found
        */
        public bool RemoveGame(string title)
        {
            GameTitle theGame = null;
            // Iterate over each GameTitle object in the Games list
            foreach (GameTitle g in Games)
            {
                // Check if the current game's Title matches the specified title (case-insensitive)
                if (g.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    theGame = g;
                    break;
                }
            }
            // If no matching game is found, output an error message and return false
            if (theGame == null)
            {
                return false;
            }
            // Remove the found game from the Games list and return true
            Games.Remove(theGame);
            return true;
        }

        /* 
          METHOD: IncreaseStock
          DESCRIPTION: Increases the stock quantity for a specific game by its ID
          PARAMETERS:
               int id: The game identifier
               int amount: The amount to increase the stock by
          RETURNS: bool: True if the stock was increased, false if the game was not found
        */
        public bool IncreaseStock(int id, int amount)
        {
            GameTitle theGame = null;
            // Iterate over each GameTitle object in the Games list
            foreach (GameTitle g in Games)
            {
                // Check if the current game's Id matches the specified id
                if (g.Id == id)
                {
                    theGame = g;
                    break;
                }
            }
            // If no matching game is found, output an error message and return false
            if (theGame == null)
            {
                return false;
            }
            // Increase the stock of the found game and return true
            theGame.Stock += amount;
            return true;
        }

        /* 
          METHOD: DecreaseStock
          DESCRIPTION: Decreases the stock quantity for a specific game by its ID (stock can be negative)
          PARAMETERS:
               int id: The game identifier
               int amount: The amount to decrease the stock by
          RETURNS: bool: True if the stock was decreased, false if the game was not found
        */
        public bool DecreaseStock(int id, int amount)
        {
            GameTitle theGame = null;
            // Iterate over each GameTitle object in the Games list
            foreach (GameTitle g in Games)
            {
                // Check if the current game's Id matches the specified id
                if (g.Id == id)
                {
                    theGame = g;
                    break;
                }
            }
            // If no matching game is found, output an error message and return false
            if (theGame == null)
            {
                return false;
            }
            // Decrease the stock of the found game and return true
            theGame.Stock -= amount;
            return true;
        }

        /* 
          METHOD: GetAllGames
          DESCRIPTION: Returns a copy of all games in the repository
          PARAMETERS: None
          RETURNS: List<GameTitle>: A new list containing all GameTitle objects
        */
        public List<GameTitle> GetAllGames()
        {
            // Return a new list constructed from the existing Games list
            return new List<GameTitle>(Games);
        }

        /* 
          METHOD: CalculateTotalValue
          DESCRIPTION: Calculates the total inventory value considering only games with positive stock
          PARAMETERS: None
          RETURNS: decimal: The total inventory value
        */
        public decimal CalculateTotalValue()
        {
            // Initialize a variable to accumulate the total value
            decimal total = 0;
            // Iterate over each GameTitle object in the Games list
            foreach (GameTitle game in Games)
            {
                // Check if the game's stock is greater than 0
                if (game.Stock > 0)
                {
                    // Add the product of the game's stock and list price to the total
                    total += game.Stock * game.ListPrice;
                }
            }
            // Return the calculated total inventory value
            return total;
        }

        /* 
          METHOD: Clear
          DESCRIPTION: Clears all game data from the repository
          PARAMETERS: None
          RETURNS: None
        */
        public void Clear()
        {
            // Clear all GameTitle objects from the Games list
            Games.Clear();
        }

        /* 
          METHOD: SetData
          DESCRIPTION: Replaces the current game list in the repository with new data
          PARAMETERS:
               List<GameTitle> newData
        : The new list of game titles to set
          RETURNS: None
        */
        public void SetData(List<GameTitle> newData)
        {
            // Assign the newData list to the Games field
            Games = newData;
        }
    }
}
