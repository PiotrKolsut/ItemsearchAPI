using ItemSearchAPI.Models;

namespace ItemSearchAPI.Services;

public interface IItemService
{
    Item? GetItemByBarcode(string barcode);
    IEnumerable<Item> SearchItemsByName(string name);
    IEnumerable<Item> GetAllItems();
}

public class ItemService : IItemService
{
    private readonly List<Item> _items;

    public ItemService()
    {
        _items = new List<Item>
        {
            new Item { Id = 1, Name = "Laptop", Barcode = "1234567890123", Description = "High-performance laptop", Price = 999.99m },
            new Item { Id = 2, Name = "Mouse", Barcode = "2345678901234", Description = "Wireless mouse", Price = 29.99m },
            new Item { Id = 3, Name = "Keyboard", Barcode = "3456789012345", Description = "Mechanical keyboard", Price = 79.99m },
            new Item { Id = 4, Name = "Monitor", Barcode = "4567890123456", Description = "27-inch 4K monitor", Price = 399.99m },
            new Item { Id = 5, Name = "Headphones", Barcode = "5678901234567", Description = "Noise-canceling headphones", Price = 149.99m },
            new Item { Id = 6, Name = "Webcam", Barcode = "6789012345678", Description = "HD webcam", Price = 89.99m },
            new Item { Id = 7, Name = "USB Cable", Barcode = "7890123456789", Description = "USB-C cable", Price = 9.99m },
            new Item { Id = 8, Name = "Mouse Pad", Barcode = "8901234567890", Description = "Gaming mouse pad", Price = 19.99m },
            new Item { Id = 9, Name = "Laptop Stand", Barcode = "9012345678901", Description = "Adjustable laptop stand", Price = 39.99m },
            new Item { Id = 10, Name = "Phone", Barcode = "0123456789012", Description = "Smartphone", Price = 699.99m }
        };
    }

    public Item? GetItemByBarcode(string barcode)
    {
        return _items.FirstOrDefault(item => 
            item.Barcode.Equals(barcode, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Item> SearchItemsByName(string name)
    {
        return _items.Where(item => 
            item.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Item> GetAllItems()
    {
        return _items;
    }
}
