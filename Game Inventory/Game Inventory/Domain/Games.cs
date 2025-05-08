namespace GameInventory 
{
    public class GameTitle
    {
        // Property: Id - the game identifier
        public int Id { get; set; }
        // Property: Title - the title of the game
        public string Title { get; set; }
        // Property: Manufacturer - the manufacturer of the game
        public string Manufacturer { get; set; }
        // Property: ListPrice - the list price of the game
        public decimal ListPrice { get; set; }
        // Property: Stock - the stock quantity of the game
        public int Stock { get; set; }

        /* 
          CONSTRUCTOR: GameTitle
          DESCRIPTION: Initializes a new instance of the GameTitle class with the specified values
          PARAMETERS:
               int id: The game identifier
               string title: The title of the game
               string manufacturer: The manufacturer of the game
               decimal listPrice: The list price of the game
               int stock: The stock count of the game
          RETURNS: None
        */
        public GameTitle(int id, string title, string manufacturer, decimal listPrice, int stock)
        {
            // Assign the provided id to the Id property
            Id = id;
            // Assign the provided title to the Title property
            Title = title;
            // Assign the provided manufacturer to the Manufacturer property
            Manufacturer = manufacturer;
            // Assign the provided list price to the ListPrice property
            ListPrice = listPrice;
            // Assign the provided stock count to the Stock property
            Stock = stock;
        }

        /* 
          METHOD: ToString
          DESCRIPTION: Provides a default formatted string representation of the GameTitle object
          PARAMETERS: None
          RETURNS: string: The formatted string representation of the object
        */
        public override string ToString()
        {
            // Return a formatted string with columns for Id, Title, Manufacturer, ListPrice, and Stock
            return $"{Id,-5} {Title,-30} {Manufacturer,-20} {ListPrice,-12} {Stock,8}";
        }
    }
}
