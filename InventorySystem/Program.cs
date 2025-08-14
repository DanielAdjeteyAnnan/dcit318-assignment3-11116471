using System;

class Program
{
    static void Main()
    {
        string filePath = "inventory.json";
        
        // First session
        var app = new InventoryApp(filePath);
        app.SeedSampleData();
        app.SaveData();

        // Simulate clearing and starting a new session
        app = new InventoryApp(filePath);
        app.LoadData();
        app.PrintAllItems();
    }
}
