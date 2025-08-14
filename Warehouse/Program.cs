using System;

class Program
{
    static void Main()
    {
        var manager = new WareHouseManager();
        manager.SeedData();

        Console.WriteLine("=== Grocery Items ===");
        manager.PrintAllItems(manager.GroceriesRepo);

        Console.WriteLine("\n=== Electronic Items ===");
        manager.PrintAllItems(manager.ElectronicsRepo);

        Console.WriteLine("\n=== Testing Exceptions ===");
        try
        {
            manager.ElectronicsRepo.AddItem(new ElectronicItem(1, "Tablet", 5, "Apple", 18));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        manager.RemoveItemById(manager.GroceriesRepo, 99);
        manager.IncreaseStock(manager.ElectronicsRepo, 1, -5);
    }
}
